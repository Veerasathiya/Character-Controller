using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    [SerializeField] private float mouseSensitivity;


    private void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = player.rotation;
        Rotate();
    }

    private void Rotate()
    {
        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up, moveX);
    }
}
