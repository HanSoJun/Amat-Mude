using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    public static string prevScene;
    public static string currScene;
    public virtual void Start()
    {
        currScene = SceneManager.GetActiveScene().name;
    }
    public void SwitchScene(string sceneName)
    {
        prevScene = currScene;
        Transition.instance.fadeInto = sceneName;
        Transition.instance.FadeOut();
    }
}
