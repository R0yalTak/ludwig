using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else { this.GetComponent<SpriteRenderer>().color = Color.white; }
    }
}
