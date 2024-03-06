using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoulder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Left" || other.gameObject.tag == "Right")
        {
            Debug.Log("Run");
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 1.5f, ForceMode.Impulse);
        }
    }
}
