using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    private GameObject instructions;
    private GameObject backButton;
    private GameObject playButton;
    private GameObject instructButton;
    private GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
         instructions = GameObject.Find("Instructions");
        backButton = GameObject.Find("Back");
        playButton = GameObject.Find("PlayButton");
        instructButton = GameObject.Find("InstructionButton");
        Title = GameObject.Find("Title");

        instructions.SetActive(false);
        backButton.SetActive(false);
        playButton.SetActive(true);
        instructButton.SetActive(true);
        Title.SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void InstructionsButton()
    {
        instructions.SetActive(true);
        backButton.SetActive(true);
        playButton.SetActive(false);
        instructButton.SetActive(false);
        Title.SetActive(false);




    }
    public void BackButton()
    {
        instructButton.SetActive(true);
        instructions.SetActive(false);
        backButton.SetActive(false);
        playButton.SetActive(true);
        Title.SetActive(true);





    }
}
