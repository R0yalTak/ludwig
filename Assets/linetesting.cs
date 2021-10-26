using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linetesting : MonoBehaviour
{
    public GameObject player;
    public Vector3[] points;
    public Line_Controller line;
    public float Pull_speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        line.SetupLine(points);
    }

    // Update is called once per frame
    void Update()
    {
        points[0] = player.transform.position;
        if (Input.GetMouseButton(0))
        {
            var screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPoint.z = 0;
            points[1] = screenPoint;

            /* was for physics swinging but changing entire system, no physics in here
            float step = Pull_speed * Time.deltaTime;
            var target = screenPoint;
            player.GetComponent<Rigidbody2D>().AddForce((target - player.transform.position)* Pull_speed, ForceMode2D.Force);*/
          //  player.transform.position = Vector3.MoveTowards(player.transform.position, screenPoint,step);
        }
        else 
        {
            points[1] = player.transform.position;
        }
    }
    
}
