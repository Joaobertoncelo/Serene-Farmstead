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
    private int _index;
    private string[] _currentSentences;

    public bool isDialogueVisible
    {
        get { return _isDialogueVisible; }
        set { _isDialogueVisible = value; }
    }

    public int index
    {
        get { return _index; }
        set { _index = value; }
    }

    public string[] currentSentences
    {
        get { return _currentSentences; }
        set { _currentSentences  = value; }
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
        foreach (char letter in _currentSentences[_index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == _currentSentences[_index])
        {
            if(_index < _currentSentences.Length - 1)
            {
                _index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                _index = 0;
                dialogueObject.SetActive(false);
                _currentSentences = null;
                _isDialogueVisible = false;
            }
        }
    }

    public void Speech(string[] txt)
    {
        if(!_isDialogueVisible)
        {
            dialogueObject.SetActive(true);
            _currentSentences = txt;
            StartCoroutine(TypeSentence());
            _isDialogueVisible = true;
        }
    }
}
