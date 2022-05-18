using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    private bool playerDetected;
    public Transform door;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;

    [SerializeField]
    private string sceneName;

    Switch sceneSwitch;

    private void Start()
    {
        sceneSwitch = FindObjectOfType<Switch>();
    }
    private void Update()
    {
        playerDetected = Physics2D.OverlapBox(door.position, new Vector2(width, height), 0, whatIsPlayer);
        if (playerDetected == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                sceneSwitch.SwitchScene(sceneName);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(door.position, new Vector3(width, height, 1));
    }
}
