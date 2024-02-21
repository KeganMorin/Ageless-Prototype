using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonWall;
    public GameObject bigButton;
    public bool ispressed;
    public bool bigpressed;
    private float timer;
    public AudioSource puzzlesound;

    // Start is called before the first frame update
    void Start()
    {
        ispressed = false;
        bigpressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bigpressed == true)
        {
            bigButton.transform.position = new Vector3(bigButton.transform.position.x, 0.03f, bigButton.transform.position.z);
            Debug.Log(timer);
            timer += Time.deltaTime;
            buttonWall.transform.Translate(Vector3.right * 4 * Time.deltaTime);
            if (timer >= 15)
            {
                Destroy(buttonWall);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("thrownRock"))
        {
            button.transform.position = new Vector3(-239.72f, button.transform.position.y, button.transform.position.z);
            ispressed = true;
            puzzlesound.Play();
        }
        if (collision.gameObject.CompareTag("bigRock"))
        {
            bigpressed = true;
            puzzlesound.Play();

        }            

    }
}
