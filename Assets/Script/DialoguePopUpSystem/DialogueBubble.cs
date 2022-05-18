using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBubble : MonoBehaviour
{
    public Text text;
    bool isPlaying;
    Canvas canvas;
    public delegate void Delegate();
    public event Delegate OnDialogueEnd, OnDialogueStart;

    public void SetDialogue(ScriptableDialogue dialogue, Transform parent, bool realtime = false)
    {
        if (isPlaying) return;
        StartCoroutine(PlayDialogue(dialogue, parent, realtime));
    }
    private IEnumerator PlayDialogue(ScriptableDialogue dialogue, Transform parent, bool realtime)
    {
        canvas = GetComponent<Canvas>();
        isPlaying = true;
        int total = dialogue.sentences.Count;
        OnDialogueStart?.Invoke();
        for (int i = 0; i < total; i++)
        {
            canvas.enabled = true;
            StartCoroutine(SetText(dialogue.sentences[i]));
            if (realtime) 
                yield return new WaitForSecondsRealtime(2.5f);
            else
                yield return new WaitForSeconds(2.5f);
            canvas.enabled = false;
            if (realtime)
                yield return new WaitForSecondsRealtime(.25f);
            else
                yield return new WaitForSeconds(.25f);
        }
        DialogueManager.instance.EndDialogue(parent);
        OnDialogueEnd?.Invoke();
        yield return null;
        Destroy(gameObject);
    }
    private IEnumerator SetText(string text)
    {
        this.text.text = text;
        yield return null;
        this.text.SetLayoutDirty();
    }
}
