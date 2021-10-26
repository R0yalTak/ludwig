using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endgame : MonoBehaviour
{
    public GameObject player;
    public GameObject winnertext;

    public float endposY = 100f;
    public float step = 0.5f;

    public bool END = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool started = false;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y>transform.position.y&&!started&&player.GetComponent<Rigidbody2D>().velocity==new Vector2(0,0))
        {
            started = true;
            GetComponent<CapsuleCollider2D>().enabled = true;
           // StartCoroutine(moveup());
        }

        if (started && transform.position.y < endposY)
        {
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + step, player.transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
        }
        else if (started && transform.position.y > endposY)
        {
            if (END == false)
            {
                StartCoroutine(winner());
            }
            END = true;
        }
    }
    public IEnumerator winner()
    {
        while (true)
        {
            winnertext.GetComponent<TextMesh>().color = Color.yellow;
            yield return new WaitForSeconds(1);
            winnertext.GetComponent<TextMesh>().color = Color.white;
            yield return new WaitForSeconds(1);


        }

    }
}
