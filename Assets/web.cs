using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "player"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //   rb.velocity = new Vector2(0, 0);
            this.transform.position = this.transform.position;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        

    }
}
