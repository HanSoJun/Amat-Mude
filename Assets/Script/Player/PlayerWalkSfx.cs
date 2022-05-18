using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSfx : MonoBehaviour
{
    public static string currentSfxName = "";
    public void PlayWalkSfx()
    {
        AudioManager.PlaySfx(currentSfxName);
    }
}
