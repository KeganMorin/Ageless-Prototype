using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuzzlehint : MonoBehaviour
{
    public SignPuzzle signPuzzle;
    public Aging aging;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /* private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && aging.ageNumber >= 60)
        {
            signPuzzle.helptips.text = "This puzzle... " +
                "it wants the signs in order I think";
        }

        else if (other.CompareTag("Player") && aging.ageNumber < 60)
        {
            signPuzzle.helptips.text = "";
        }
    }
    */
}

   
