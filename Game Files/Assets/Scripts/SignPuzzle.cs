using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class SignPuzzle : MonoBehaviour
{
    public bool inArea;
    public Vector3 changedpos;
    public Aging aging;
    public TMP_Text helptips;
    public StoneBag stonebag;
    public SecondDoor secondDoor;
    public GameObject correctsign;
    // Start is called before the first frame update
    void Start()
    {
        inArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aging.ageNumber < 30)
        {
            //rb.GetComponent<Rigidbody>().mass = 100f;
            /*  transform.position = transform.position - new Vector3(-3, 0.3f, 1);           
            transform.rotation = new Quaternion(transform.rotation.w, transform.rotation.x, 90f, 90f);
            */
            //helptips.text = "This is too heavy, I cannot carry this";
        }
        /* if (Input.GetKey(KeyCode.F) && isHolding == true && inArea == false && aging.ageNumber >= 30)
         {
             signHeld.transform.position = transform.position - new Vector3(-3, 1.1f, 1);
             signHeld.transform.rotation = new Quaternion(transform.rotation.w, transform.rotation.x, 90f, 90f);
         }
        */
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("sign"))
        {
            inArea = true;

        }



    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sign"))
        {
            inArea = false;

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("sign"))
        {
            aging.targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripvalue);
            if (inArea == true)
            {
                if (gripvalue == true && other.gameObject != correctsign || gripvalue == false && other.gameObject != correctsign)
                {
                    other.gameObject.GetComponent<Rigidbody>().mass = 1;

                }


                if (gripvalue == false && other.gameObject == correctsign || gripvalue == true && other.gameObject == correctsign)
                {
                    changedpos = transform.position - new Vector3(0, 0, -0.2f);
                    other.transform.position = changedpos;
                    other.transform.rotation = transform.rotation;
                    other.gameObject.GetComponent<Rigidbody>().mass = 0;
                    helptips.text = "";
                }
            }
          
            
        }
        
        if (inArea == true && aging.ageNumber >= 30)
        {
            helptips.text = "";

        }

    }
            
}
