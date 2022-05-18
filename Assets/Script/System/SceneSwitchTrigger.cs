using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitchTrigger : MonoBehaviour
{
    Switch sceneSwitch;
    [SerializeField]
    private string sceneCutsceneName, sceneNonCutsceneName, cutsceneName;
    [SerializeField]
    private bool isCutsceneNext;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwitch = FindObjectOfType<Switch>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SwitchScene();
        }
    }
    public void SwitchScene()
    {
        if (PlayerPrefs.GetInt("Cutscene" + cutsceneName, 0) == 1)
        {
            sceneSwitch.SwitchScene(sceneNonCutsceneName);
        }
        else
        {
            if (isCutsceneNext)
            {
                PlayerPrefs.SetInt("Cutscene" + cutsceneName, 1);
            }
            sceneSwitch.SwitchScene(sceneCutsceneName);
        }
    }
}
