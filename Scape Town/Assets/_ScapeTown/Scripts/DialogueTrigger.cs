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
    public Text textName;
    public Text textDialogue;
    [SerializeField] private float talkDistance = 3f;

    private float distance;
    private bool buttonTalkIsActive;
    private bool isTalking;

    private Queue<string> sentences;

    private void Start()
    {
        SetButtonTalk(false);
        dialoguePanel.SetActive(false);
        isTalking = false;

        sentences = new Queue<string>();
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
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue, textName, textDialogue, gameObject);
        StartDialogue();
    }

    public void StartDialogue()
    {
        textName.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        textDialogue.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            textDialogue.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        ClearDialogue();
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
