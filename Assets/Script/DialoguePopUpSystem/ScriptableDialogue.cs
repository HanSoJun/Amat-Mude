using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "new Pop Up Dialogue")]
public class ScriptableDialogue : ScriptableObject
{
    [TextArea(2, 5)]
    public List<string> sentences;
}
