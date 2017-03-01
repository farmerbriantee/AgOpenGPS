using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security;

namespace SharpGL.Tesselators
{
    /// <summary>
    /// Begins tesselation.
    /// </summary>
    /// <param name="mode">The mode.</param>
    public delegate void Begin(uint mode);

    /// <summary>
    /// Set the edge flag.
    /// </summary>
    /// <param name="flag">if set to <c>true</c> [flag].</param>
    public delegate void EdgeFlag(bool flag);

    /// <summary>
    /// Vertex data.
    /// </summary>
    /// <param name="data">The data.</param>
    public delegate void Vertex(IntPtr data);

    /// <summary>
    /// End tesselation.
    /// </summary>
    public delegate void End();

    /// <summary>
    /// Combine data.
    /// </summary>
    /// <param name="coords">The coords.</param>
    /// <param name="vertexData">The vertex data.</param>
    /// <param name="weight">The weight.</param>
    /// <param name="outData">The out data.</param>
    public delegate void Combine(double[] coords, IntPtr vertexData, float[] weight, double[] outData);

    /// <summary>
    /// Error function.
    /// </summary>
    /// <param name="error">The error.</param>
    public delegate void Error(uint error);

    /// <summary>
    /// Begin with user data.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="userData">The user data.</param>
    public delegate void BeginData(uint mode, IntPtr userData);

    /// <summary>
    /// Edge flag with user data.
    /// </summary>
    /// <param name="flag">if set to <c>true</c> [flag].</param>
    /// <param name="userData">The user data.</param>
    public delegate void EdgeFlagData(bool flag, IntPtr userData);

    /// <summary>
    /// Vertex with user data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="userData">The user data.</param>
    public delegate void VertexData(IntPtr data, IntPtr userData);

    /// <summary>
    /// End with data.
    /// </summary>
    /// <param name="userData">The user data.</param>
    public delegate void EndData(IntPtr userData);

    /// <summary>
    /// Combine with data.
    /// </summary>
    /// <param name="coords">The coords.</param>
    /// <param name="vertexData">The vertex data.</param>
    /// <param name="weight">The weight.</param>
    /// <param name="outData">The out data.</param>
    /// <param name="userData">The user data.</param>
    public delegate void CombineData(double[] coords, IntPtr vertexData, float[] weight, double[] outData, IntPtr userData);

    /// <summary>
    /// Error with data.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <param name="userData">The user data.</param>
    public delegate void ErrorData(uint error, IntPtr userData);
}