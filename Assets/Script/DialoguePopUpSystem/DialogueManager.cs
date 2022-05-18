using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    public static DialogueManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    public GameObject bubblePrefab;
    public List<DialogueBubble.Delegate> onEnd = new List<DialogueBubble.Delegate>(), onStart =  new List<DialogueBubble.Delegate>();
    private List<Transform> speakers = new List<Transform>();
    public void SpawnDialogue(ScriptableDialogue dialogueData, Transform parent, Vector3 offset, bool realtime = false)
    {
        if (speakers.Contains(parent)) return;
        DialogueBubble bubble = Instantiate(bubblePrefab, parent).GetComponent<DialogueBubble>();
        bubble.transform.localPosition = offset;
        foreach (DialogueBubble.Delegate del in onStart)
        {
            bubble.OnDialogueStart += del;
        }
        foreach (DialogueBubble.Delegate del in onEnd)
        {
            bubble.OnDialogueEnd += del;
        }
        bubble.SetDialogue(dialogueData, parent, realtime);
        speakers.Add(parent);
        onEnd = new List<DialogueBubble.Delegate>();
        onStart = new List<DialogueBubble.Delegate>();
    }
    public void EndDialogue(Transform parent)
    {
        if (speakers.Contains(parent))
        {
            speakers.Remove(parent);
        }
        else
        {
            Debug.Log("SS the whole screen and send to Chris.\nTransform Name: " + parent.gameObject.name + ".");
        }
    }
}