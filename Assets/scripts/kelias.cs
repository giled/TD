
using System.Collections.Generic;
using UnityEngine;

public class kelias : MonoBehaviour {
    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for(int i =0;i<points.Length; i++)
        {
           points[i] = transform.GetChild(i);
           /* if (points[i])
                points[i].transform.position = points[i].position;*/
        }

    }

	
}
