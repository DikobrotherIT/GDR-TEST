using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private List<Vector2> points;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetupPath(Vector2 startPonint, Vector2 endPoint)
    {
        points.Add(startPonint);
        points.Add(endPoint);
        _lineRenderer.positionCount = 2;  
    }

    public void ResetPath()
    {
        points.Clear();
        _lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        if (points.Count > 0)
        {
            for (int i = 0; i < points.Count; i++)
            {
                _lineRenderer.SetPosition(i, points[i]);
            }
        }
    }
}
