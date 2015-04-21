using UnityEngine;
using System;

public class BezierSpline : MonoBehaviour 
{
    [SerializeField]
    private BezierControlPointMode[] modes;

    [SerializeField]
    public Vector3[] points;

    public void Reset()
    {
        points = new Vector3[] 
        {
            new Vector3(1.0f, 0.0f, 0.0f),
            new Vector3(2.0f, 0.0f, 0.0f),
            new Vector3(3.0f, 0.0f, 0.0f),
            new Vector3(4.0f, 0.0f, 0.0f)
        };

        modes = new BezierControlPointMode[] 
        {
            BezierControlPointMode.Free,
            BezierControlPointMode.Free
        };
    }
    
    // Control points:
    public int ControlPointCount
    {
        get
        {
            return points.Length;
        }
    }

    public Vector3 GetControlPoint(int index)
    {
        return points[index];
    }

    public void SetControlPoint(int index, Vector3 point)
    {
        points[index] = point;
    }

    public BezierControlPointMode GetControlPointMode(int index)
    {
        return modes[(index + 1) / 3];
    }

    public void SetControlPointMode(int index, BezierControlPointMode mode)
    {
        modes[(index + 1) / 3] = mode;
    }

    // Get-methods for displaying spline:
    public Vector3 GetPoint(float t)
    {
        int i;

        if (t >= 1.0f)
        {
            t = 1.0f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }

        return transform.TransformPoint(Bezier.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t));
    }

    public Vector3 GetVelocity(float t)
    {
        int i;

        if (t >= 1.0f)
        {
            t = 1.0f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }

        return transform.TransformPoint(Bezier.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }


    // Misc:
    public int CurveCount
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }

    public void AddCurve()
    {
        Vector3 point = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        point.x += 1.0f;
        points[points.Length - 3] = point;
        point.x += 1.0f;
        points[points.Length - 2] = point;
        point.x += 1.0f;
        points[points.Length - 1] = point;

        Array.Resize(ref modes, modes.Length + 1);
        modes[modes.Length - 1] = modes[modes.Length - 2];
    }
}
