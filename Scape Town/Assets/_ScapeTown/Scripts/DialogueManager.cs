using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Text nameText;
    private Text dialogueText;
	private DialogueTrigger dialogueTrigger;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject textName, GameObject textDialogue, GameObject triggerObject)
    {
        nameText = textName.GetComponent<Text>();
        dialogueText = textDialogue.GetComponent<Text>();
        dialogueTrigger = triggerObject.GetComponent<DialogueTrigger>();

        nameText.text = dialogue.name;
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

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        dialogueTrigger.ClearDialogue();
    }
}
