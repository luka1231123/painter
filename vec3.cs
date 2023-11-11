using SFML.Graphics.Glsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter;

public class vec3
{
    public double[] e;

    public vec3()
    {
        e = new double[3] { 0, 0, 0 };
    }

    public vec3(double e0, double e1, double e2)
    {
        e = new double[3] { e0, e1, e2 };
    }
    public double x
    {
        get { return e[0]; }
        set { e[0] = value; }
    }

    public double y
    {
        get { return e[1]; }
        set { e[1] = value; }
    }

    public double z
    {
        get { return e[2]; }
        set { e[2] = value; }
    }


    public double this[int i]
    {
        get { return e[i]; }
        set { e[i] = value; }
    }

    public static vec3 operator +(vec3 v1, vec3 v2)
    {
        return new vec3(v1.e[0] + v2.e[0], v1.e[1] + v2.e[1], v1.e[2] + v2.e[2]);
    }

    public static vec3 operator -(vec3 v1, vec3 v2)
    {
        return new vec3(v1.e[0] - v2.e[0], v1.e[1] - v2.e[1], v1.e[2] - v2.e[2]);
    }

    public static vec3 operator *(vec3 v, double t)
    {
        return new vec3(v.e[0] * t, v.e[1] * t, v.e[2] * t);
    }

    public static vec3 operator *(double t, vec3 v)
    {
        return v * t;
    }

    public static vec3 operator /(vec3 v, double t)
    {
        return v * (1 / t);
    }

    public double Length()
    {
        return Math.Sqrt(LengthSquared());
    }

    public double LengthSquared()
    {
        return e[0] * e[0] + e[1] * e[1] + e[2] * e[2];
    }

}
