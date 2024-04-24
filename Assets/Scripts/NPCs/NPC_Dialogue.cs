using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask PlayerLayer;

    public DialogueSettings currentDialogue;

    public bool playerHit;

    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNpcInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueController.instance.Speech(sentences.ToArray());
        }
    }

    void GetNpcInfo()
    {
        for(int i = 0; i < currentDialogue.actorSpeech.Count; i++)
        {
            switch (DialogueController.instance.selectedLanguage)
            {
                case DialogueController.language.pt:
                    sentences.Add(currentDialogue.actorSpeech[i].language.portuguese);
                    break;
                case DialogueController.language.eng:
                    sentences.Add(currentDialogue.actorSpeech[i].language.english);
                    break;
                case DialogueController.language.spa:
                    sentences.Add(currentDialogue.actorSpeech[i].language.spanish);
                    break;
                case DialogueController.language.fra:
                    sentences.Add(currentDialogue.actorSpeech[i].language.french);
                    break;
                case DialogueController.language.ger:
                    sentences.Add(currentDialogue.actorSpeech[i].language.german);
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D playerDetector = Physics2D.OverlapCircle(transform.position, dialogueRange, PlayerLayer);
        
        if (playerDetector != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueController.instance.dialogueObject.SetActive(false);
            DialogueController.instance.isDialogueVisible = false;
            DialogueController.instance.speechText.text = "";
            DialogueController.instance.index = 0;
            DialogueController.instance.currentSentences = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
