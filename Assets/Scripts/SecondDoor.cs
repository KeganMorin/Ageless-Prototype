using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondDoor : MonoBehaviour
{
    public GameObject Sign1;
    public GameObject Sign2;
    public GameObject Sign3;
    public GameObject Holder1;
    public GameObject Holder2;
    public GameObject Holder3;
    private float timer;
    public bool correctposition1 = false;
    public bool correctposition2 = false;
    public bool correctposition3 = false;
    public SignPuzzle signPuzzle;

    public GameObject[] signtext;




    // Start is called before the first frame update
    void Start()
    {
        signtext = GameObject.FindGameObjectsWithTag("text");
    }

    // Update is called once per frame
    void Update()
    {
        if(Sign1.transform.position == Holder1.transform.position - new Vector3(0, 0, -0.2f))
        {
            Sign1.transform.position = Holder1.transform.position - new Vector3(0, 0, -0.2f);
            Sign1.GetComponent<Rigidbody>().mass = 0;
            correctposition1 = true;
        }
        if (Sign2.transform.position == Holder2.transform.position - new Vector3(0, 0, -0.2f))
        {
            Sign2.transform.position = Holder2.transform.position - new Vector3(0, 0, -0.2f);
            Sign2.GetComponent<Rigidbody>().mass = 0;
            correctposition2 = true;
        }
        if (Sign3.transform.position == Holder3.transform.position - new Vector3(0, 0, -0.2f))
        {
            Sign3.transform.position = Holder3.transform.position - new Vector3(0, 0, -0.2f);
            Sign3.GetComponent<Rigidbody>().mass = 0;
            correctposition3 = true;
        }
        if (correctposition1 == true && correctposition2 == true && correctposition3 == true)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.up * 2 * Time.deltaTime);
            Debug.Log(timer);

            if (timer > 9)
            {
                Destroy(gameObject);
            }
        }
    }
}
