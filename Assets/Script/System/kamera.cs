using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Vector3 offset;
    public Transform Player;
    public GameObject player;
    public float jarak;
    public Vector2 border = new Vector2(-100, 100);

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = new Vector3(player.transform.localPosition.x + (player.transform.localScale.x * jarak), 0, -10.3f);
        transform.localPosition = Vector3.Slerp(transform.localPosition, pos, 0.01f);
        Vector3 newPos = Player.position + offset;
        newPos.x = Mathf.Clamp(newPos.x, border.x, border.y);
        transform.position = newPos;
    }
}
