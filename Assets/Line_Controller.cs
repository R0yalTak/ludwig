using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Controller : MonoBehaviour
{

    [SerializeField]private LineRenderer lr;
    [SerializeField]private Vector3[] points;

    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }
    public void SetupLine(Vector3[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
}
