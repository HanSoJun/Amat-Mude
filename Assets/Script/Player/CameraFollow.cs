using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    //border x == max kiri, border y == max kanan
    public Vector2 border = new Vector2(-100, 100);

    //matikan animator saat cameraFollow nyala agar script bisa dipakai
    private void OnEnable()
    {
        Animator animator;
        animator = GetComponent<Animator>();
        if (animator != null) animator.enabled = false;
    }
    private void Update()
    {
        Vector3 newPos = Player.position + offset;
        newPos.x = Mathf.Clamp(newPos.x, border.x, border.y);
        transform.position = newPos;
    }
}