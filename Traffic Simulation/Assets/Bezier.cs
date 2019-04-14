using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform p0, p1;
    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = numPoints;
        DrawLinearCurve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawLinearCurve()
    {
        for (int i = 1; i <= numPoints; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = CalculateLinearBizierPoint(t, p0.position, p1.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateLinearBizierPoint(float t, Vector3 p0, Vector3 p1)
    {
        return p0 + t * (p1 - p0);
    }
}
