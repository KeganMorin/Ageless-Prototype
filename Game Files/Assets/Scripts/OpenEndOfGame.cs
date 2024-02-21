using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OpenEndOfGame : MonoBehaviour
{
    private bool movewall = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(movewall == true)
        {
            MoveWall();
        }
    }
    public void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player") & Input.GetKeyDown(KeyCode.F))
            {

                Destroy(GameObject.Find("PrisonerTextActivation"));
                Destroy(GameObject.Find("Prisoner"));
            movewall = true;

            }
        }

    public void MoveWall()
    {
       gameObject.transform.Translate(Vector3.up * Time.deltaTime * 3);
    }
}
