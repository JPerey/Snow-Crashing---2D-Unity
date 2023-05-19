using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    // Start is called before the first frame update
    public SurfaceEffector2D floorSurface;
    int floorSpeed = 150;
    void Start()
    {
        floorSurface = GetComponent<SurfaceEffector2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDirection(int direction)
    {
        if (direction == 0)
        {
            Debug.Log("in changing direction 0");
            floorSurface.speed = -floorSpeed;
        }
        else if (direction == 1)
        {
            Debug.Log("in changing direction 1");
            floorSurface.speed = floorSpeed;
        }

    }
}
