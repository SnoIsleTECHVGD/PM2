using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text dialogueText;
    public TMPro.TMP_Text characterName;
    //public Image icon;
    //public Image dialogueBox;
    public KeyCode dialogueContinue;
    public KeyCode dialogueSkip;
    public bool dialogueOpen = false;
    public bool hasPause;
    public bool hasDialogueEvents;
    public DialogueManager dialogueManager;

    public UnityEvent endDialogue;
    public UnityEvent dialogueEventShortcut;

    private Queue<DialoguePiece> conversation;
    // Update is called once per frame
    public void Start()
    {
    
    }
    private void Update()
    {
        if (Input.GetKeyDown(dialogueContinue) == true)
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown(dialogueSkip) == true && this.dialogueOpen == true)
        {
            if (hasDialogueEvents == true)
            {
                dialogueEventShortcut.Invoke();
            }
            EndDialogue(dialogueManager);
        }
    }
    public void StartDialogue(Dialogue dialouge)
    {
        dialogueOpen = true;
        Time.timeScale = 0;
        conversation = new Queue<DialoguePiece>();
        foreach (DialoguePiece DP in dialouge.conversation)
        {
            conversation.Enqueue(DP);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (conversation.Count == 0)
        {
            EndDialogue(dialogueManager);
            return;
        }
        DialoguePiece thisDialogue = conversation.Dequeue();
        if (thisDialogue.hasUnityEvent == true)
        {
            thisDialogue.dialogueEvent.Invoke();
        }
        characterName.text = thisDialogue.name;
        string sentence = thisDialogue.sentence;
        //icon.sprite = thisDialogue.icon;
        //dialogueBox.sprite = thisDialogue.dialogueBox;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue(DialogueManager thisScript)
    {  
        Time.timeScale = 1;
        dialogueOpen = false;
        thisScript.endDialogue.Invoke();
    }
}
