using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_passthrough : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float step = 3f;
    BoxCollider2D collider;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        try
        {
            if (player.transform.position.y < this.transform.position.y)
            {
                collider.enabled = false;
            }
            else if (player.transform.position.y > this.transform.position.y+step)
            {
                collider.enabled = true;
            }
        }
        catch 
        {

        }
    }
}
