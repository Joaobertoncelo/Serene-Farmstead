using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "New Dialogue/Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    public GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string actorText;

    public List<Sentences> actorSpeech = new List<Sentences>();
}

[System.Serializable]
public class Sentences
{
    public string actorName;
    public Sprite actorProfilePicture;
    public Languages language;
}

[System.Serializable]
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
    public string french;
    public string german;
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings dialogueSettings = (DialogueSettings)target;

        Languages language = new Languages();
        language.portuguese = dialogueSettings.actorText;

        Sentences sentence = new Sentences();
        sentence.actorProfilePicture = dialogueSettings.speakerSprite;
        sentence.language = language;

        if(GUILayout.Button("create Dialogue"))
        {
            if(dialogueSettings.actorText != "")
            {
                dialogueSettings.actorSpeech.Add(sentence);

                dialogueSettings.speakerSprite = null;
                dialogueSettings.actorText = "";
            }
        }
    }
}


#endif