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
    [SerializeField] private float talkDistance = 3f;

    private float distance;
    private bool buttonTalkIsActive;
    private bool isTalking;

    private void Start()
    {
        SetButtonTalk(false);
        dialoguePanel.SetActive(false);
        isTalking = false;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (!isTalking)
        {
            if (distance <= talkDistance && !buttonTalkIsActive)
            {
                SetButtonTalk(true);
            }

            if (distance > talkDistance && buttonTalkIsActive)
            {
                SetButtonTalk(false);
            }
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

        isTalking = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, textName, textDialogue, gameObject);
    }

    public void ClearDialogue()
    {
        SetButtonTalk(true);
        dialoguePanel.SetActive(false);

        isTalking = false;
    }

    private void SetButtonTalk(bool active)
    {
        buttonTalk.gameObject.SetActive(active);
        buttonTalkIsActive = active;
    }
}
