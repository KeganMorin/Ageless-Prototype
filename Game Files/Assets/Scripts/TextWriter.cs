using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextWriter : MonoBehaviour
{
    private TMP_Text uiText;
    public Throwing throwing;
    public StoneBag stonebag;
    public Aging aging;
    private string textToWrite;
    private float timePerCharacter;
    private float timer;
    private int characterIndex;
    private bool invisibleCharacters;
    private float screenvalue;

    public void AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);

                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }

                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
        GameObject.Find("StoneCounter").GetComponent<TMP_Text>().text = "Rocks: " + stonebag.stoneCounter;
        screenvalue = Mathf.Round(aging.ageNumber);
        GameObject.Find("AgeViewer").GetComponent<TMP_Text>().text = "Age: " + screenvalue;

    }
}