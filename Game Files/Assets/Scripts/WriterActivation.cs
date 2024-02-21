using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriterActivation : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    public TMP_Text messageText;
    public TMP_Text messageText2;


    public bool active = false;
    public bool active2 = false;

    private void Awake()
    {

    }

    void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && active == false)
        {
            active = true;
            Debug.Log("Work");
            textWriter.AddWriter(messageText,
           "Hello human, I am a fairy of this forest a protecter of the life and nature. " +
           "There is someone trapped inside of some ruins deep within the forest. " +
           "use your special power to get inside and save him.", 0.06f, true);

           
        }
        if(gameObject.tag == "textWrite" && active2 == false)
        {
            textWriter.AddWriter(messageText2,
               "Thank you for saving me, I was exploring through a secret passage when all of the sudden" +
               " everything went black and I ended up here. We need to hurry out of here, " +
               "something tells me that these ruins won't stay up for long. ", 0.04f, true);
        }
    }
}