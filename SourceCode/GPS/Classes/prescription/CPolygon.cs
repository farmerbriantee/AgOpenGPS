using SharpKml.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgOpenGPS.prescription
{
    /// <summary>
    /// Polygon helper class
    /// all credits go to Rod Stephaens http://csharphelper.com/blog/2014/07/perform-geometric-operations-on-polygons-in-c/
    /// </summary>
    public class CPolygon
    {
        public CPolygon()
        {
        }
        public CPolygon(PointF[] points)
        {
            Points = points;
        }

        public CPolygon(List<Vector> vecs)
        {
            List<PointF> points = new List<PointF>();
            foreach(Vector v in vecs)
            {
                PointF p = new PointF((float)v.Latitude, (float)v.Longitude);
                points.Add(p);
            }
            Points = points.ToArray();
        }

        public PointF[] Points;

        // Find the polygon's centroid.
        public PointF FindCentroid()
        {
            // Add the first point at the end of the array.
            int num_points = Points.Length;
            PointF[] pts = new PointF[num_points + 1];
            Points.CopyTo(pts, 0);
            pts[num_points] = Points[0];

            // Find the centroid.
            float X = 0;
            float Y = 0;
            float second_factor;
            for (int i = 0; i < num_points; i++)
            {
                second_factor =
                    pts[i].X * pts[i + 1].Y -
                    pts[i + 1].X * pts[i].Y;
                X += (pts[i].X + pts[i + 1].X) * second_factor;
                Y += (pts[i].Y + pts[i + 1].Y) * second_factor;
            }

            // Divide by 6 times the polygon's area.
            float polygon_area = PolygonArea();
            X /= (6 * polygon_area);
            Y /= (6 * polygon_area);

            // If the values are negative, the polygon is
            // oriented counterclockwise so reverse the signs.
            if (X < 0)
            {
                X = -X;
                Y = -Y;
            }

            return new PointF(X, Y);
        }

        // Return true if the point is in the polygon.
        public bool PointInPolygon(float X, float Y)
        {
            // Get the angle between the point and the
            // first and last vertices.
            int max_point = Points.Length - 1;
            float total_angle = GetAngle(
                Points[max_point].X, Points[max_point].Y,
                X, Y,
                Points[0].X, Points[0].Y);

            // Add the angles from the point
            // to each other pair of vertices.
            for (int i = 0; i < max_point; i++)
            {
                total_angle += GetAngle(
                    Points[i].X, Points[i].Y,
                    X, Y,
                    Points[i + 1].X, Points[i + 1].Y);
            }

            // The total angle should be 2 * PI or -2 * PI if
            // the point is in the polygon and close to zero
            // if the point is outside the polygon.
            return (Math.Abs(total_angle) > 1);
        }

        #region "Orientation Routines"
        // Return true if the polygon is oriented clockwise.
        public bool PolygonIsOrientedClockwise()
        {
            return (SignedPolygonArea() < 0);
        }

        // If the polygon is oriented counterclockwise,
        // reverse the order of its points.
        private void OrientPolygonClockwise()
        {
            if (!PolygonIsOrientedClockwise())
                Array.Reverse(Points);
        }
        #endregion // Orientation Routines

        #region "Area Routines"
        // Return the polygon's area in "square units."
        // Add the areas of the trapezoids defined by the
        // polygon's edges dropped to the X-axis. When the
        // program considers a bottom edge of a polygon, the
        // calculation gives a negative area so the space
        // between the polygon and the axis is subtracted,
        // leaving the polygon's area. This method gives odd
        // results for non-simple polygons.
        public float PolygonArea()
        {
            // Return the absolute value of the signed area.
            // The signed area is negative if the polygon is
            // oriented clockwise.
            return Math.Abs(SignedPolygonArea());
        }

        // Return the polygon's area in "square units."
        // Add the areas of the trapezoids defined by the
        // polygon's edges dropped to the X-axis. When the
        // program considers a bottom edge of a polygon, the
        // calculation gives a negative area so the space
        // between the polygon and the axis is subtracted,
        // leaving the polygon's area. This method gives odd
        // results for non-simple polygons.
        //
        // The value will be negative if the polygon is
        // oriented clockwise.
        private float SignedPolygonArea()
        {
            // Add the first point to the end.
            int num_points = Points.Length;
            PointF[] pts = new PointF[num_points + 1];
            Points.CopyTo(pts, 0);
            pts[num_points] = Points[0];

            // Get the areas.
            float area = 0;
            for (int i = 0; i < num_points; i++)
            {
                area +=
                    (pts[i + 1].X - pts[i].X) *
                    (pts[i + 1].Y + pts[i].Y) / 2;
            }

            // Return the result.
            return area;
        }
        #endregion // Area Routines

        // Return true if the polygon is convex.
        public bool PolygonIsConvex()
        {
            // For each set of three adjacent points A, B, C,
            // find the dot product AB · BC. If the sign of
            // all the dot products is the same, the angles
            // are all positive or negative (depending on the
            // order in which we visit them) so the polygon
            // is convex.
            bool got_negative = false;
            bool got_positive = false;
            int num_points = Points.Length;
            int B, C;
            for (int A = 0; A < num_points; A++)
            {
                B = (A + 1) % num_points;
                C = (B + 1) % num_points;

                float cross_product =
                    CrossProductLength(
                        Points[A].X, Points[A].Y,
                        Points[B].X, Points[B].Y,
                        Points[C].X, Points[C].Y);
                if (cross_product < 0)
                {
                    got_negative = true;
                }
                else if (cross_product > 0)
                {
                    got_positive = true;
                }
                if (got_negative && got_positive) return false;
            }

            // If we got this far, the polygon is convex.
            return true;
        }

        #region "Cross and Dot Products"
        // Return the cross product AB x BC.
        // The cross product is a vector perpendicular to AB
        // and BC having length |AB| * |BC| * Sin(theta) and
        // with direction given by the right-hand rule.
        // For two vectors in the X-Y plane, the result is a
        // vector with X and Y components 0 so the Z component
        // gives the vector's length and direction.
        public static float CrossProductLength(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        // Return the dot product AB · BC.
        // Note that AB · BC = |AB| * |BC| * Cos(theta).
        private static float DotProduct(float Ax, float Ay,
            float Bx, float By, float Cx, float Cy)
        {
            // Get the vectors' coordinates.
            float BAx = Ax - Bx;
            float BAy = Ay - By;
            float BCx = Cx - Bx;
            float BCy = Cy - By;

            // Calculate the dot product.
            return (BAx * BCx + BAy * BCy);
        }
        #endregion // Cross and Dot Products

        // Return the angle ABC.
        // Return a value between PI and -PI.
        // Note that the value is the opposite of what you might
        // expect because Y coordinates increase downward.
        public static float GetAngle(float Ax, float Ay, float Bx, float By, float Cx, float Cy)
        {
            // Get the dot product.
            float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

            // Get the cross product.
            float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

            // Calculate the angle.
            return (float)Math.Atan2(cross_product, dot_product);
        }

        #region "Triangulation"
        /*
        // Find the indexes of three points that form an "ear."
        private void FindEar(ref int A, ref int B, ref int C)
        {
            int num_points = Points.Length;

            for (A = 0; A < num_points; A++)
            {
                B = (A + 1) % num_points;
                C = (B + 1) % num_points;

                if (FormsEar(Points, A, B, C)) return;
            }

            // We should never get here because there should
            // always be at least two ears.
            Debug.Assert(false);
        }

        // Return true if the three points form an ear.
        private static bool FormsEar(PointF[] points, int A, int B, int C)
        {
            // See if the angle ABC is concave.
            if (GetAngle(
                points[A].X, points[A].Y,
                points[B].X, points[B].Y,
                points[C].X, points[C].Y) > 0)
            {
                // This is a concave corner so the triangle
                // cannot be an ear.
                return false;
            }

            // Make the triangle A, B, C.
            Triangle triangle = new Triangle(
                points[A], points[B], points[C]);

            // Check the other points to see 
            // if they lie in triangle A, B, C.
            for (int i = 0; i < points.Length; i++)
            {
                if ((i != A) && (i != B) && (i != C))
                {
                    if (triangle.PointInPolygon(points[i].X, points[i].Y))
                    {
                        // This point is in the triangle 
                        // do this is not an ear.
                        return false;
                    }
                }
            }

            // This is an ear.
            return true;
        }

        // Remove an ear from the polygon and
        // add it to the triangles array.
        private void RemoveEar(List<Triangle> triangles)
        {
            // Find an ear.
            int A = 0, B = 0, C = 0;
            FindEar(ref A, ref B, ref C);

            // Create a new triangle for the ear.
            triangles.Add(new Triangle(Points[A], Points[B], Points[C]));

            // Remove the ear from the polygon.
            RemovePointFromArray(B);
        }

        // Remove point target from the array.
        private void RemovePointFromArray(int target)
        {
            PointF[] pts = new PointF[Points.Length - 1];
            Array.Copy(Points, 0, pts, 0, target);
            Array.Copy(Points, target + 1, pts, target, Points.Length - target - 1);
            Points = pts;
        }

        // Triangulate the polygon.
        //
        // For a nice, detailed explanation of this method,
        // see Ian Garton's Web page:
        // http://www-cgrl.cs.mcgill.ca/~godfried/teaching/cg-projects/97/Ian/cutting_ears.html
        public List<Triangle> Triangulate()
        {
            // Copy the points into a scratch array.
            PointF[] pts = new PointF[Points.Length];
            Array.Copy(Points, pts, Points.Length);

            // Make a scratch polygon.
            Polygon pgon = new Polygon(pts);

            // Orient the polygon clockwise.
            pgon.OrientPolygonClockwise();

            // Make room for the triangles.
            List<Triangle> triangles = new List<Triangle>();

            // While the copy of the polygon has more than
            // three points, remove an ear.
            while (pgon.Points.Length > 3)
            {
                // Remove an ear from the polygon.
                pgon.RemoveEar(triangles);
            }

            // Copy the last three points into their own triangle.
            triangles.Add(new Triangle(pgon.Points[0], pgon.Points[1], pgon.Points[2]));

            return triangles;
        }
        */
        #endregion // Triangulation

        #region "Bounding Rectangle"
        private int NumPoints = 0;

        // The points that have been used in test edges.
        private bool[] m_EdgeChecked;

        // The four caliper control points. They start:
        //       m_ControlPoints(0)      Left edge       xmin
        //       m_ControlPoints(1)      Bottom edge     ymax
        //       m_ControlPoints(2)      Right edge      xmax
        //       m_ControlPoints(3)      Top edge        ymin
        private int[] ControlPoints = new int[4];

        // The line from this point to the next one forms
        // one side of the next bounding rectangle.
        private int m_CurrentControlPoint = -1;

        // The area of the current and best bounding rectangles.
        private float CurrentArea = float.MaxValue;
        private PointF[] CurrentRectangle = null;
        private float BestArea = float.MaxValue;
        private PointF[] BestRectangle = null;

        // Get ready to start.
        private void ResetBoundingRect()
        {
            NumPoints = Points.Length;

            // Find the initial control points.
            FindInitialControlPoints();

            // So far we have not checked any edges.
            m_EdgeChecked = new bool[NumPoints];

            // Start with this bounding rectangle.
            m_CurrentControlPoint = 1;
            BestArea = float.MaxValue;

            // Find the initial bounding rectangle.
            FindBoundingRectangle();

            // Remember that we have checked this edge.
            m_EdgeChecked[ControlPoints[m_CurrentControlPoint]] = true;
        }

        // Find the initial control points.
        private void FindInitialControlPoints()
        {
            for (int i = 0; i < NumPoints; i++)
            {
                if (CheckInitialControlPoints(i)) return;
            }
            Debug.Assert(false, "Could not find initial control points.");
        }

        // See if we can use segment i --> i + 1 as the base for the initial control points.
        private bool CheckInitialControlPoints(int i)
        {
            // Get the i -> i + 1 unit vector.
            int i1 = (i + 1) % NumPoints;
            float vix = Points[i1].X - Points[i].X;
            float viy = Points[i1].Y - Points[i].Y;

            // The candidate control point indexes.
            for (int num = 0; num < 4; num++)
            {
                ControlPoints[num] = i;
            }

            // Check backward from i until we find a vector
            // j -> j+1 that points opposite to i -> i+1.
            for (int num = 1; num < NumPoints; num++)
            {
                // Get the new edge vector.
                int j = (i - num + NumPoints) % NumPoints;
                int j1 = (j + 1) % NumPoints;
                float vjx = Points[j1].X - Points[j].X;
                float vjy = Points[j1].Y - Points[j].Y;

                // Project vj along vi. The length is vj dot vi.
                float dot_product = vix * vjx + viy * vjy;

                // If the dot product < 0, then j1 is
                // the index of the candidate control point.
                if (dot_product < 0)
                {
                    ControlPoints[0] = j1;
                    break;
                }
            }

            // If j == i, then i is not a suitable control point.
            if (ControlPoints[0] == i) return false;

            // Check forward from i until we find a vector
            // j -> j+1 that points opposite to i -> i+1.
            for (int num = 1; num < NumPoints; num++)
            {
                // Get the new edge vector.
                int j = (i + num) % NumPoints;
                int j1 = (j + 1) % NumPoints;
                float vjx = Points[j1].X - Points[j].X;
                float vjy = Points[j1].Y - Points[j].Y;

                // Project vj along vi. The length is vj dot vi.
                float dot_product = vix * vjx + viy * vjy;

                // If the dot product <= 0, then j is
                // the index of the candidate control point.
                if (dot_product <= 0)
                {
                    ControlPoints[2] = j;
                    break;
                }
            }

            // If j == i, then i is not a suitable control point.
            if (ControlPoints[2] == i) return false;

            // Check forward from m_ControlPoints[2] until
            // we find a vector j -> j+1 that points opposite to
            // m_ControlPoints[2] -> m_ControlPoints[2]+1.

            i = ControlPoints[2] - 1;
            float temp = vix;
            vix = viy;
            viy = -temp;

            for (int num = 1; num < NumPoints; num++)
            {
                // Get the new edge vector.
                int j = (i + num) % NumPoints;
                int j1 = (j + 1) % NumPoints;
                float vjx = Points[j1].X - Points[j].X;
                float vjy = Points[j1].Y - Points[j].Y;

                // Project vj along vi. The length is vj dot vi.
                float dot_product = vix * vjx + viy * vjy;

                // If the dot product <=, then j is
                // the index of the candidate control point.
                if (dot_product <= 0)
                {
                    ControlPoints[3] = j;
                    break;
                }
            }

            // If j == i, then i is not a suitable control point.
            if (ControlPoints[0] == i) return false;

            // These control points work.
            return true;
        }

        // Find the next bounding rectangle and check it.
        private void CheckNextRectangle()
        {
            // Increment the current control point.
            // This means we are done with using this edge.
            if (m_CurrentControlPoint >= 0)
            {
                ControlPoints[m_CurrentControlPoint] =
                    (ControlPoints[m_CurrentControlPoint] + 1) % NumPoints;
            }

            // Find the next point on an edge to use.
            float dx0, dy0, dx1, dy1, dx2, dy2, dx3, dy3;
            FindDxDy(out dx0, out dy0, ControlPoints[0]);
            FindDxDy(out dx1, out dy1, ControlPoints[1]);
            FindDxDy(out dx2, out dy2, ControlPoints[2]);
            FindDxDy(out dx3, out dy3, ControlPoints[3]);

            // Switch so we can look for the smallest opposite/adjacent ratio.
            float opp0 = dx0;
            float adj0 = dy0;
            float opp1 = -dy1;
            float adj1 = dx1;
            float opp2 = -dx2;
            float adj2 = -dy2;
            float opp3 = dy3;
            float adj3 = -dx3;

            // Assume the first control point is the best point to use next.
            float bestopp = opp0;
            float bestadj = adj0;
            int best_control_point = 0;

            // See if the other control points are better.
            if (opp1 * bestadj < bestopp * adj1)
            {
                bestopp = opp1;
                bestadj = adj1;
                best_control_point = 1;
            }
            if (opp2 * bestadj < bestopp * adj2)
            {
                bestopp = opp2;
                bestadj = adj2;
                best_control_point = 2;
            }
            if (opp3 * bestadj < bestopp * adj3)
            {
                bestopp = opp3;
                bestadj = adj3;
                best_control_point = 3;
            }

            // Use the new best control point.
            m_CurrentControlPoint = best_control_point;

            // Remember that we have checked this edge.
            m_EdgeChecked[ControlPoints[m_CurrentControlPoint]] = true;

            // Find the current bounding rectangle
            // and see if it is an improvement.
            FindBoundingRectangle();
        }

        // Find the current bounding rectangle and
        // see if it is better than the previous best.
        private void FindBoundingRectangle()
        {
            // See which point has the current edge.
            int i1 = ControlPoints[m_CurrentControlPoint];
            int i2 = (i1 + 1) % NumPoints;
            float dx = Points[i2].X - Points[i1].X;
            float dy = Points[i2].Y - Points[i1].Y;

            // Make dx and dy work for the first line.
            switch (m_CurrentControlPoint)
            {
                case 0: // Nothing to do.
                    break;
                case 1: // dx = -dy, dy = dx
                    float temp1 = dx;
                    dx = -dy;
                    dy = temp1;
                    break;
                case 2: // dx = -dx, dy = -dy
                    dx = -dx;
                    dy = -dy;
                    break;
                case 3: // dx = dy, dy = -dx
                    float temp2 = dx;
                    dx = dy;
                    dy = -temp2;
                    break;
            }

            float px0 = Points[ControlPoints[0]].X;
            float py0 = Points[ControlPoints[0]].Y;
            float dx0 = dx;
            float dy0 = dy;
            float px1 = Points[ControlPoints[1]].X;
            float py1 = Points[ControlPoints[1]].Y;
            float dx1 = dy;
            float dy1 = -dx;
            float px2 = Points[ControlPoints[2]].X;
            float py2 = Points[ControlPoints[2]].Y;
            float dx2 = -dx;
            float dy2 = -dy;
            float px3 = Points[ControlPoints[3]].X;
            float py3 = Points[ControlPoints[3]].Y;
            float dx3 = -dy;
            float dy3 = dx;

            // Find the points of intersection.
            CurrentRectangle = new PointF[4];
            FindIntersection(px0, py0, px0 + dx0, py0 + dy0, px1, py1, px1 + dx1, py1 + dy1, ref CurrentRectangle[0]);
            FindIntersection(px1, py1, px1 + dx1, py1 + dy1, px2, py2, px2 + dx2, py2 + dy2, ref CurrentRectangle[1]);
            FindIntersection(px2, py2, px2 + dx2, py2 + dy2, px3, py3, px3 + dx3, py3 + dy3, ref CurrentRectangle[2]);
            FindIntersection(px3, py3, px3 + dx3, py3 + dy3, px0, py0, px0 + dx0, py0 + dy0, ref CurrentRectangle[3]);

            // See if this is the best bounding rectangle so far.
            // Get the area of the bounding rectangle.
            float vx0 = CurrentRectangle[0].X - CurrentRectangle[1].X;
            float vy0 = CurrentRectangle[0].Y - CurrentRectangle[1].Y;
            float len0 = (float)Math.Sqrt(vx0 * vx0 + vy0 * vy0);

            float vx1 = CurrentRectangle[1].X - CurrentRectangle[2].X;
            float vy1 = CurrentRectangle[1].Y - CurrentRectangle[2].Y;
            float len1 = (float)Math.Sqrt(vx1 * vx1 + vy1 * vy1);

            // See if this is an improvement.
            CurrentArea = len0 * len1;
            if (CurrentArea < BestArea)
            {
                BestArea = CurrentArea;
                BestRectangle = CurrentRectangle;
            }
        }

        // Find the slope of the edge from point i to point i + 1.
        private void FindDxDy(out float dx, out float dy, int i)
        {
            int i2 = (i + 1) % NumPoints;
            dx = Points[i2].X - Points[i].X;
            dy = Points[i2].Y - Points[i].Y;
        }

        // Find the point of intersection between two lines.
        private bool FindIntersection(float X1, float Y1, float X2, float Y2, float A1, float B1, float A2, float B2, ref PointF intersect)
        {
            float dx = X2 - X1;
            float dy = Y2 - Y1;
            float da = A2 - A1;
            float db = B2 - B1;
            float s, t;

            // If the segments are parallel, return False.
            if (Math.Abs(da * dy - db * dx) < 0.001) return false;

            // Find the point of intersection.
            s = (dx * (B1 - Y1) + dy * (X1 - A1)) / (da * dy - db * dx);
            t = (da * (Y1 - B1) + db * (A1 - X1)) / (db * dx - da * dy);
            intersect = new PointF(X1 + t * dx, Y1 + t * dy);
            return true;
        }

        // Find a smallest bounding rectangle.
        public PointF[] FindSmallestBoundingRectangle()
        {
            // This algorithm assumes the polygon
            // is oriented counter-clockwise.
            Debug.Assert(!this.PolygonIsOrientedClockwise());

            // Get ready;
            ResetBoundingRect();

            // Check all possible bounding rectangles.
            for (int i = 0; i < Points.Length; i++)
            {
                CheckNextRectangle();
            }

            // Return the best result.
            return BestRectangle;
        }
        #endregion // Bounding Rectangle

    }
}
