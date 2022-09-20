using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public struct MiVector
{
    public float x;
    public float y;

    public float magnitud => Mathf.Sqrt(x * x + y * y);
    public MiVector normal
    {
        get
        {
            float m = magnitud;

            if(m <= 0.0001)
            {
                return new MiVector(0, 0);
            }
            return new MiVector(x / m, y / m);
        }
    }

    public MiVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color);
    }
    public void Draw(MiVector newOrigin, Color color)
    {
        Debug.DrawLine(new Vector3(newOrigin.x, newOrigin.y), new Vector3(newOrigin.x + x, newOrigin.y + y), color);
    }

    public void Normalizar()
    {
        float cuenta = 0.0001f;
        float m = magnitud;

        if(m <= cuenta)
        {
            x = 0; y = 0;
            return;
        }

        x /= m; y /= m;
    }

    public static MiVector operator -(MiVector a, MiVector b)
    {
        return new MiVector(a.x - b.x, a.y - b.y);
    }
    public static MiVector operator +(MiVector a, MiVector b)
    {
        return new MiVector(a.x + b.x, a.y + b.y);
    }
    public static MiVector operator *(MiVector a, float b)
    {
        return new MiVector(a.x * b, a.y * b);
    }
  
    public static MiVector operator /(MiVector a, float b)
    {
        return new MiVector(a.x / b, a.y / b);
    }
    
    public static MiVector operator *(float b, MiVector a)
    {
        return new MiVector(a.x * b, a.y * b);
    }
}

