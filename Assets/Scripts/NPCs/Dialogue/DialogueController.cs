using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObject;
    public Image actorProfilePicture;
    public Text speechText;
    public Text actorName;

    [Header("Settings")]
    public float typingSpeed;

    private bool isDialogueVisible;
    private int index;
    private string[] currentSentences;

    void Start()
    {
        
    }

    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in currentSentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

    }

    public void Speech(string[] txt)
    {
        if(!isDialogueVisible)
        {
            dialogueObject.SetActive(true);
            currentSentences = txt;
            StartCoroutine(TypeSentence());
            isDialogueVisible = true;
        }
    }
}
