using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnHit : MonoBehaviour
{
    public bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.55f, gameObject.transform.position.z);
            pressed = true;
          
        }
    }
}
