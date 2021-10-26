using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heightbar : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject heightcounter;

    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = heightcounter.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            this.transform.position = new Vector3(0, player.transform.position.y,0);
            text.text = Math.Round((this.transform.position.y/3),2) +"m";
        }
    }
}
