using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if(gameObject.name == "kiri")
        {
            
        }
        else if(gameObject.name == "kanan")
        {

        }
        else if(gameObject.name == "loncat")
        {
            player.GetComponent<jalan>().melompat();
        }
    }

    void OnMouseUp()
    {
        if (gameObject.name == "kiri")
        {
            player.GetComponent<jalan>().berhenti();
        }
        else if (gameObject.name == "kanan")
        {
            player.GetComponent<jalan>().berhenti();
        }
        else if (gameObject.name == "loncat")
        {
            
        }
    }

    void OnMouseDrag()
    {
        if (gameObject.name == "kiri")
        {
            player.GetComponent<jalan>().jalankiri();
        }
        else if (gameObject.name == "kanan")
        {
            player.GetComponent<jalan>().jalankanan();
        }
        else if (gameObject.name == "loncat")
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
