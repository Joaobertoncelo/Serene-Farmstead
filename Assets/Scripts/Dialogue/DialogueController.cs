using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [System.Serializable]
    public enum language
    {
        pt,
        eng,
        spa,
        fra,
        ger
    }

    public language selectedLanguage; 


    [Header("Components")]
    public GameObject dialogueObject;
    public Image actorProfilePicture;
    public Text speechText;
    public Text actorName;

    [Header("Settings")]
    public float typingSpeed;

    private bool _isDialogueVisible;
    private int index;
    private string[] currentSentences;

    public bool isDialogueVisible
    {
        get { return _isDialogueVisible; }
        set { _isDialogueVisible = value; }
    }

    public static DialogueController instance;

    private void Awake()
    {
        instance = this;
    }

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
        if(speechText.text == currentSentences[index])
        {
            if(index < currentSentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObject.SetActive(false);
                currentSentences = null;
                _isDialogueVisible = false;
            }
        }
    }

    public void Speech(string[] txt)
    {
        if(!_isDialogueVisible)
        {
            dialogueObject.SetActive(true);
            currentSentences = txt;
            StartCoroutine(TypeSentence());
            _isDialogueVisible = true;
        }
    }
}
