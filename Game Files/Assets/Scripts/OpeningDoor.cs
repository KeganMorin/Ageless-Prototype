using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    public ButtonInteraction Button1;
    public ButtonInteraction Button2;
    public ButtonInteraction Button3;
    public ButtonInteraction Button4;
    public Aging age;
    public SignPuzzle helpbox;
    private bool inArea = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Button1.ispressed == true && Button2.ispressed == true && Button3.ispressed == true && Button4.ispressed == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        inArea = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if(age.ageNumber > 60 && inArea == true)
        {

            helpbox.helptips.text = "Those buttons may do something if I hit them";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        helpbox.helptips.text = "";
        inArea = false;
    }
}
