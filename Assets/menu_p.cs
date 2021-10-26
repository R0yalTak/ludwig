using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_p : MonoBehaviour
{
    public float roto_offset;
    public bool tracking =true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tracking)
            lookat_mouse();

    }
    void lookat_mouse()
    {



        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + roto_offset);
    }
}
