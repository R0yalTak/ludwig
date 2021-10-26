using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class butttton : MonoBehaviour
{
    public float offset = 1f;
    public Sprite sprite;
    public bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>().sprite;
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().sprite != sprite&&down==false)
        {
            down = true;
            

        }

        else if (down)
        {
        }
    }
     void iiii()
    {
        // Do something.
       
    }
}
