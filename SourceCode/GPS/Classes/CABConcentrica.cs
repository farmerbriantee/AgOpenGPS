using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

/*
La clase debe ser declarada en FormGPS y luego inicializada en FormGPS

declaracion    --> public CABConcentrica ABConcentrica;
inicializacion --> ABConcentrica = new CABConcentrica(this); 
 
*/

namespace AgOpenGPS
{
    public class CABConcentrica
    {
        private readonly FormGPS mf;
        public CABConcentrica(FormGPS _f)
        {
            //constructor. Aca se inicializan las varibles cuando se declara una clase
            mf = _f;
            lineWidth = Properties.Settings.Default.setDisplay_lineWidth;

        }

        public vec2 punto_central = new vec2(0.0, 0.0);
        public double passNumber;
        public double distanceFromCurrentLine;
        public double steerAngleAB;
        public int lineWidth;
        public bool isOnRightSideCurrentLine = true;

        public bool isABSameAsVehicleHeading = true;
        public double lc_centro_rover_heading;
        double lc_distancia_centro;
        double lc_distancia_pasada;
        double lc_widthMinusOverlap;
        double lc_gp_easting;
        double lc_gp_northing;
        public double avance_circunferencia = 0;
        public bool isConcentricSet = false;

        public vec2[] puntos_circulo = new vec2[3];
        public byte c_puntos_circulo = 0;
        public bool punto_central_error = false;
        public bool espiral= false;
        public bool antihorario = false;

        // usamos la lista de curva AB para guardar los puntos para determinar el centro del circulo en AddSectionOrContourPathPoints() en Position.Designer.cs
        // ---> curve.refList.Add(pt)

        public List<vec2> list_circulo = new List<vec2>();
        public void GetLineaConcentrica(bool espiral = true, bool antihorario = true)
        {

            //el espiral se agranda en sentido horario cuando antihorario es false

            double toolOffset = mf.tool.offset;

            lc_widthMinusOverlap = mf.tool.width - mf.tool.overlap;

            lc_centro_rover_heading = Math.Atan2(mf.pivotAxlePos.easting - punto_central.easting, mf.pivotAxlePos.northing - punto_central.northing); //  angulo que forma la linea entre el rover y el centro respecto del norte
            if (lc_centro_rover_heading < 0) lc_centro_rover_heading += glm.twoPI;

            lc_distancia_centro = glm.Distance(punto_central.easting, punto_central.northing, mf.pivotAxlePos.easting, mf.pivotAxlePos.northing);

            if (espiral)
            {
                if (!antihorario)
                {
                    passNumber = Convert.ToInt32((lc_distancia_centro - (lc_widthMinusOverlap * (lc_centro_rover_heading / glm.twoPI))) / lc_widthMinusOverlap);
                }
                else
                {
                    passNumber = Convert.ToInt32((lc_distancia_centro + (lc_widthMinusOverlap * (lc_centro_rover_heading / glm.twoPI))) / lc_widthMinusOverlap);
                }
            }
            else
            {
                passNumber = Convert.ToInt32(lc_distancia_centro / lc_widthMinusOverlap);
            }

            lc_distancia_pasada = Math.Round(passNumber, 0, MidpointRounding.AwayFromZero) * lc_widthMinusOverlap;

            if (espiral)
            {
                if (!antihorario)
                {
                    lc_distancia_pasada += lc_widthMinusOverlap * (lc_centro_rover_heading / glm.twoPI);
                }
                else
                {
                    lc_distancia_pasada -= lc_widthMinusOverlap * (lc_centro_rover_heading / glm.twoPI);
                }
            }


            if (isABSameAsVehicleHeading)
            {
                lc_distancia_pasada += toolOffset;
            }
            else
            {
                lc_distancia_pasada -= toolOffset;
            }

            distanceFromCurrentLine = lc_distancia_centro - lc_distancia_pasada;
            isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

            //mf.vehicle.UpdateGoalPointDistance();

            double goalPointDistance = UpdateGoalPointDistance_Concentrica(Math.Abs(distanceFromCurrentLine));
            //mf.lookaheadActual = goalPointDistance;

            avance_circunferencia = 0;

            if (Math.Abs(distanceFromCurrentLine) < goalPointDistance)
            {
                avance_circunferencia = Math.Sqrt(Math.Abs((goalPointDistance * goalPointDistance) - (distanceFromCurrentLine * distanceFromCurrentLine)));
            }
            double circunferencia = lc_distancia_pasada * 2 * Math.PI;

            double angulo_avance = (avance_circunferencia / circunferencia) * glm.twoPI;

            double localHeading = glm.twoPI - mf.fixHeading;

            if (!isABSameAsVehicleHeading)
            {
                lc_gp_easting = punto_central.easting + (Math.Sin(angulo_avance + lc_centro_rover_heading) * lc_distancia_pasada);
                lc_gp_northing = punto_central.northing + (Math.Cos(angulo_avance + lc_centro_rover_heading) * lc_distancia_pasada);
            }
            else
            {
                lc_gp_easting = punto_central.easting + (Math.Sin(lc_centro_rover_heading - angulo_avance) * lc_distancia_pasada);
                lc_gp_northing = punto_central.northing + (Math.Cos(lc_centro_rover_heading - angulo_avance) * lc_distancia_pasada);
            }

            double goalPointDistanceDSquared = glm.DistanceSquared(lc_gp_northing, lc_gp_easting, mf.pivotAxlePos.northing, mf.pivotAxlePos.easting);

            steerAngleAB = glm.toDegrees(Math.Atan(2 * (((lc_gp_easting - mf.pivotAxlePos.easting) * Math.Cos(localHeading)) + ((lc_gp_northing - mf.pivotAxlePos.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceDSquared));
            if (steerAngleAB < -mf.vehicle.maxSteerAngle) steerAngleAB = -mf.vehicle.maxSteerAngle;
            if (steerAngleAB > mf.vehicle.maxSteerAngle) steerAngleAB = mf.vehicle.maxSteerAngle;

            distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

            //mf.guidanceLineDistanceOff = mf.distanceDisplay = (Int16)distanceFromCurrentLine;
            mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
            mf.guidanceLineSteerAngle = (Int16)(steerAngleAB * 100);

            if (lc_distancia_pasada < lc_widthMinusOverlap) { lc_distancia_pasada = lc_widthMinusOverlap; }

            double angulo = glm.twoPI * 1 / lc_distancia_pasada; //amplitud del angulo que ocupa cada trazo que forma la curva a dibujar
            if (angulo > (glm.twoPI / 40)) { angulo = glm.twoPI / 40; } // controlo el tamaño del angulo para no graficar de mas

        }

        vec2[] vec_buff = new vec2[3];

        public void DrawLineaConcentrica(bool espiral = true, bool antihorario = true)
        {
            //dibujar punto central
            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.95f, 0.0f, 0.0f);
            GL.Vertex3(punto_central.easting, punto_central.northing, 0.0);
            GL.End();

            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.95f, 0.95, 0.0f);
            GL.Vertex3(lc_gp_easting, lc_gp_northing, 0.0);
            GL.End();

            double angulo = glm.twoPI / lc_distancia_pasada; //amplitud del angulo que ocupa cada trazo que forma la curva a dibujar
            if (angulo > (glm.twoPI / 40)) { angulo = glm.twoPI / 40; } // controlo el tamaño del angulo para no graficar de mas

            GL.LineWidth(lineWidth);
            GL.Color3(0.95f, 0.0f, 0.950f);

            double toolOffset = mf.tool.offset;
            double cosH2 = 0;
            double sinH2 = 0;
            byte c_puntos = 0;

            for (Int16 punto = -10; punto < 10; punto++)
            {
                c_puntos++;

                double angulo_total = (angulo * punto) + lc_centro_rover_heading; // genera la rotacion de las lineas que se estan dibujando

                double dist_pass_draw = passNumber * lc_widthMinusOverlap;

                if (espiral)
                {
                    if (!antihorario)
                    {
                        dist_pass_draw += lc_widthMinusOverlap * (angulo_total / glm.twoPI);
                    }
                    else
                    {
                        dist_pass_draw -= lc_widthMinusOverlap * (angulo_total / glm.twoPI);
                    }
                }

                if (isABSameAsVehicleHeading)
                {
                    dist_pass_draw += toolOffset;
                }
                else
                {
                    dist_pass_draw -= toolOffset;
                }

                double sinH = Math.Sin(angulo_total) * dist_pass_draw;
                double cosH = Math.Cos(angulo_total) * dist_pass_draw;

                if (punto == 0)
                {
                    double concentrica_Heading = Math.Atan2(sinH2 - sinH, cosH2 - cosH);
                    if (concentrica_Heading < 0) concentrica_Heading += glm.twoPI;

                    double abFixHeadingDelta_concentrica = (Math.Abs(mf.fixHeading - concentrica_Heading));
                    if (abFixHeadingDelta_concentrica >= Math.PI) abFixHeadingDelta_concentrica = Math.Abs(abFixHeadingDelta_concentrica - glm.twoPI);

                    isABSameAsVehicleHeading = abFixHeadingDelta_concentrica < glm.PIBy2;

                }

                /*

                if (punto == -8)
                {
                    vec_buff[0].easting = punto_central.easting + sinH;
                    vec_buff[0].northing = punto_central.northing + cosH;
                }
                if (punto == 0)
                {
                    vec_buff[1].easting = punto_central.easting + sinH;
                    vec_buff[1].northing = punto_central.northing + cosH;
                }
                if (punto == 8)
                {
                    vec_buff[2].easting = punto_central.easting + sinH;
                    vec_buff[2].northing = punto_central.northing + cosH;
                }

                */

                if (c_puntos > 1)
                {
                    GL.Begin(PrimitiveType.Lines);
                    GL.Vertex3(punto_central.easting + sinH, punto_central.northing + cosH, 0.0);
                    GL.Vertex3(punto_central.easting + sinH2, punto_central.northing + cosH2, 0.0);
                    GL.End();
                }

                sinH2 = sinH;
                cosH2 = cosH;
            }

            //vec2 centro;
            //centro = centro_circulo_tres_puntos(vec_buff[0], vec_buff[1], vec_buff[2]);

            GL.PointSize(8.0f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0.5f, 0.5, 0.5f);
            //GL.Vertex3(centro.easting, centro.northing, 0.0);
            GL.Vertex3(punto_central.easting, punto_central.northing, 0.0);
            GL.End();
        }

        public double UpdateGoalPointDistance_Concentrica(double dfcl)
        {
            double xTE = Math.Abs(dfcl);

            mf.vehicle.modeActualXTE = dfcl; 

            //how far should goal point be away  - speed * seconds * kmph -> m/s then limit min value
            double goalPointDistance = mf.avgSpeed * mf.vehicle.goalPointLookAhead * 0.05 * mf.vehicle.goalPointLookAheadMult;
            goalPointDistance += mf.vehicle.goalPointLookAhead;

            if (xTE < (mf.vehicle.modeXTE))
            {
                if (mf.vehicle.modeTimeCounter > mf.vehicle.modeTime * 10)
                {
                    goalPointDistance = mf.avgSpeed * mf.vehicle.goalPointLookAheadHold * 0.05 * mf.vehicle.goalPointLookAheadMult;
                    goalPointDistance += mf.vehicle.goalPointLookAheadHold;
                }
                else
                {
                    mf.vehicle.modeTimeCounter++;
                }
            }
            else
            {
                mf.vehicle.modeTimeCounter = 0;
            }

            if (goalPointDistance < 1) goalPointDistance = 1;
            mf.vehicle.goalDistance = goalPointDistance;

            return goalPointDistance;
        }

        public double pendiente_recta(vec2 p1, vec2 p2)
        {

            // eq recta --> y=ax + b, donde a es la pendiente y b la ordenada al origen
            double pendiente = (p2.northing - p1.northing) / (p2.easting - p1.easting);
            return pendiente;
        }

        public double pendiente_recta_perpendicular(vec2 p1, vec2 p2)
        {
            double perpendicular = 1 / pendiente_recta(p1, p2);
            perpendicular *= -1;
            return perpendicular;
        }

        public vec2 centro_circulo_tres_puntos(vec2 p1, vec2 p2, vec2 p3)
        {
            //recta 1:  y = 3x - 3
            //recta 2:  y = -x + 1

            //igualo 3x - 3 = -x + 1
            //       3x + x = 1 + 3
            //           4x = 4
            //            x = 4/4
            punto_central_error = false;
            double pend_1 = pendiente_recta_perpendicular(p1, p2);
            double pend_2 = pendiente_recta_perpendicular(p2, p3);
            vec2 p_medio_1;
            p_medio_1.easting = (p1.easting + p2.easting) / 2;
            p_medio_1.northing = (p1.northing + p2.northing) / 2;
            double p1_ordenada = p_medio_1.northing - (p_medio_1.easting * pend_1);
            vec2 p_medio_2;
            p_medio_2.easting = (p2.easting + p3.easting) / 2;
            p_medio_2.northing = (p2.northing + p3.northing) / 2;
            double p2_ordenada = p_medio_2.northing - (p_medio_2.easting * pend_2);
            vec2 res;
            double termino_izquierdo = pend_1 - pend_2;
            if (termino_izquierdo < 0.00001)
            {
                mf.TimedMessageBox(2000, "AB Concentrica", "El punto central que intenta establecer se encuentra demasiado lejos");
                punto_central_error = true;
                return punto_central; 
            }
            double termino_derecho = p2_ordenada - p1_ordenada;
            double x_medio = termino_derecho / termino_izquierdo;
            double y_medio = pend_1 * x_medio + p1_ordenada;
            
            res.easting = x_medio;
            res.northing = y_medio;
            return res;
        }
    }
}