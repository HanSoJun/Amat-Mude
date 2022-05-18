using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    //Fade in = Fade ke scene
    //Fade out = Fade ke black screen

    public static Transition instance;

    public string fadeInto;
    public GameObject fadein;
    public GameObject fadeout;

    public static bool isFading;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {

        if (fadeout.activeInHierarchy)
        {
            fadeout.SetActive(false);
        }

        fadein.SetActive(true);        
    }

    public void FadeOut()
    {
        StartCoroutine(WaitFading());
        
        if(fadein.activeInHierarchy)
        {
            fadein.SetActive(false);
        }

        fadeout.SetActive(true);
    }

    IEnumerator WaitFading()
    {
        isFading = true;
        yield return new WaitForSeconds(1.5f);
        isFading = false;
        SceneManager.LoadScene(fadeInto);
    }
}
