using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public GameObject textName;
    public GameObject textDialogue;

    private float distance;

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < 2f)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, textName, textDialogue);
    }
}
