using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        if (Input.GetKey(KeyCode.Space))
        {
            InstantiateSegments(this.transform.position, new Vector3(-2, 1, 0));

        }
    }

    float moveVelocity;
    float horizontal;
    float vertical;
    public void movement()
    {
        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);


    }


    //ROPE INSTANTIATE TEST
    public GameObject ropePrefab;

    public Vector3 instantiatePosition;
    public float lerpValue;
    public float distance;
    public int segmentsToCreate;
    void InstantiateSegments(Vector3 pointA,Vector3 pointB)
    {
        //Here we calculate how many segments will fit between the two points
        segmentsToCreate = Mathf.RoundToInt(Vector3.Distance(pointA, pointB) / 0.5f);
        //As we'll be using vector3.lerp we want a value between 0 and 1, and the distance value is the value we have to add
        distance = 1 / segmentsToCreate;
        for (int i = 0; i < segmentsToCreate; i++)
        {
            //We increase our lerpValue
            lerpValue += distance;
            //Get the position
            instantiatePosition = Vector3.Lerp(pointA, pointB, lerpValue);
            //Instantiate the object
            Instantiate(ropePrefab, instantiatePosition, transform.rotation);
        }
    }
}
