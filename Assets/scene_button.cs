using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scene_button : MonoBehaviour
{
    public string scene=null;

    public GameObject cover;
    public GameObject canvas;

    public bool second = false;
    public float waittime = 3f;

    //IGNORED IF FIRST
    private void Awake()
    {
        if (second)
        { StartCoroutine(instructs()); }
    }
    IEnumerator instructs()
    {
        yield return new WaitForSeconds(waittime);
        canvas.SetActive(false);

        fading = true;
    }


    void Start()
    {

    }

    // Update is called once per frame
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float speed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public SpriteRenderer sprite;
    public bool fading = false;
    public bool reverse = false;

    void Update()
    {
        if (fading)
        {
            float step = speed * Time.deltaTime;

            if (faded)
            {
                
                sprite.color = new Color(0,0,0, Mathf.Lerp(sprite.color.a, maximum, step));
                if (Mathf.Abs(maximum - sprite.color.a) <= threshold)
                {
                    faded = false;

                }

            }
            else
            {
                sprite.color = new Color(0, 0, 0, Mathf.Lerp(sprite.color.a, minimum, step));

                if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                {
                    faded = true;
                }
            }
        }

       
    }
    public GameObject info;
    public void infoscreen()
    {
        info.SetActive(!info.activeInHierarchy);

    }

    void colorchange()
    {
        

       

    }

    public void loadscene()
    {
        fading = true;

        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        // SceneManager.LoadScene(scene);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
      //  yield return SceneManager.LoadSceneAsync(scene);
    }
}
