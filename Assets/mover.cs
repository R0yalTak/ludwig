using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    [SerializeField] float holding_time = 3f;
    [SerializeField] float increment = 0.001f;
    [SerializeField] bool decreasing = false;

    [SerializeField] GameObject rope;
    [SerializeField] Material rope_material;
    [SerializeField] GrapplingGun grapl;
    SpriteRenderer renderer;
    [SerializeField] Sprite grappling_sprite;
    public float speed = 1.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        rope_material = rope.GetComponent<Renderer>().material;
        startsprite = renderer.sprite;
    }
    [SerializeField] float startval = 1;
    Sprite startsprite;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        { shootweb();  }
        

    }
    public Color current_color;
    public Camera m_camera;

    public float roto_offset = 0f;
    void lookat_mouse()
    {



        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z+roto_offset);
    }
    public GameObject webOBJ = null;
    public Rigidbody2D web_rb;
    public float multiplyer = 1f;


    public Vector2 direction;
    void shootweb()
    {

        GameObject web =null;
       

        Vector2 Mouse_FirePoint_DistanceVector;
        Mouse_FirePoint_DistanceVector = m_camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit;
        if (hit=Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y), Mouse_FirePoint_DistanceVector.normalized, Mathf.Infinity))
        {
          //  RaycastHit2D _hit = Physics2D.Raycast(this.transform.position, Mouse_FirePoint_DistanceVector.normalized, Mathf.Infinity);
            web = Instantiate(webOBJ, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            web_rb = web.GetComponent<Rigidbody2D>();

            //  web_rb.AddForce((_hit.point - new Vector2(transform.position.x, transform.position.y)*multiplyer),ForceMode2D.Impulse);
            direction = (m_camera.ScreenToWorldPoint(Input.mousePosition) - transform.position) * multiplyer;

            web_rb.AddForce(direction, ForceMode2D.Impulse);

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            lookat_mouse();
            renderer.sprite = grappling_sprite;
            decreasing = true;
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            }

        }
        else
        {
            renderer.sprite = startsprite;
            decreasing = false;
        }
        if (Input.GetKeyDown("p"))
        {
            Time.timeScale = 0.9f;
        }

        if (startval <= 0f)
        {
            grapl.grappleRope.enabled = false;
            grapl.m_springJoint2D.enabled = false;
            grapl.ballRigidbody.gravityScale = 1;
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            //transform.eulerAngles = new Vector3(this.transform.rotation.x,transform.rotation.y,0);
        }









        // Debug.Log("FixedUpdate Called");
        current_color = rope_material.color;
        if (decreasing)
        {
            startval = startval - increment;
            rope_material.color = new Color(1, startval - increment, startval - increment);
        }
        else
        {
            startval = 1;
            rope_material.color = new Color(255, 255, 255);
        }
    }
}
