using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDialogue : MonoBehaviour
{
    public DialogueTrigger TutDialogue;
    public GameObject ColliderBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TutDialogue.TriggerDialogue();
        ColliderBox.GetComponent<BoxCollider2D>().enabled = false;
    }
}
