using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMoving : TungMonoBehaviour
{
    [SerializeField] protected List<Point> points = new List<Point>();
    public List<Point> Points => points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        Point point;
        foreach (Transform child in transform)
        {
            point = child.GetComponent<Point>();   
            if( point == null ) continue;
            points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }
    public Point GetPoint(int pointIndex)
    {
        return points[pointIndex];
    }
}
