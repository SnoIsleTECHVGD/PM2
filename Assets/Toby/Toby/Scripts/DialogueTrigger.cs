using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager manager;
    public Dialogue dialogueText;
    public KeyCode interact;
    public bool interactable;
    public bool onInteractable;
    public bool activateOnAwake;
    public UnityEvent triggerOnInteract;
    public UnityEvent triggerOnCollision;
    public UnityEvent triggerOnIsTrigger;
    public UnityEvent onSceneEnter;

    private void Awake()
    {
        if (activateOnAwake == true)
        {
            onSceneEnter.Invoke();
            TriggerDialogue();
        }
    }

    void Update()
    {
        if (interactable == true && Input.GetKeyDown(interact) == true && onInteractable == true)
        {
            triggerOnInteract.Invoke();
            TriggerDialogue();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onInteractable = true;
        }
        if (interactable == false && collision.gameObject.CompareTag("Player"))
        {
            triggerOnCollision.Invoke();
            TriggerDialogue();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onInteractable = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onInteractable = true;
        }
        if (interactable == false && collision.gameObject.CompareTag("Player"))
        {
            triggerOnIsTrigger.Invoke();
            TriggerDialogue();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onInteractable = false;

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactable == true && Input.GetKeyDown(interact) == true && collision.gameObject.CompareTag("Player"))
        {
            triggerOnInteract.Invoke();
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogueText);
    }

}
