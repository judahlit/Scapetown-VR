using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Button buttonTalk;
    public GameObject player;
    public GameObject dialoguePanel;
    public GameObject textName;
    public GameObject textDialogue;

    private float distance;
    private bool buttonTalkIsActive;

    private void Start()
    {
        SetButtonTalk(false);
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 2f && !buttonTalkIsActive)
        {
            SetButtonTalk(true);
        }

        if (distance > 2f && buttonTalkIsActive)
        {
            SetButtonTalk(false);
        }

        if (buttonTalk.IsActive())
        {
            buttonTalk.onClick.AddListener(TriggerDialogue);
        }
    }

    public void TriggerDialogue()
    {
        SetButtonTalk(false);
        dialoguePanel.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, textName, textDialogue, gameobject);
    }

    public void ClearDialogue()
    {
        SetButtonTalk(true);
        dialoguePanel.SetActive(false);
    }

    private void SetButtonTalk(bool active)
    {
        buttonTalk.gameObject.SetActive(active);
        buttonTalkIsActive = active;
    }
}
