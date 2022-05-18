using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    int totalMelee = 1;
    public int currentIndex;

    public GameObject[] melee;
    public GameObject meleeHolder;
    public GameObject currentMelee;

    void Start()
    {
        totalMelee = meleeHolder.transform.childCount;
        melee = new GameObject[totalMelee];

        for(int i = 0; i < totalMelee; i++)
        {
            melee[i] = meleeHolder.transform.GetChild(i).gameObject;
            melee[i].SetActive(false);
        }

        melee[0].SetActive(true);
        currentMelee = melee[0];
        currentIndex = 0;
    }

    public void Melee1()
    {
        melee[currentIndex].SetActive(false);
        currentIndex = 0;
        melee[currentIndex].SetActive(true);
    }

    public void Melee2()
    {
        melee[currentIndex].SetActive(false);
        currentIndex = 1;
        melee[currentIndex].SetActive(true);
    }

    public void Melee3()
    {
        melee[currentIndex].SetActive(false);
        currentIndex = 2;
        melee[currentIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
