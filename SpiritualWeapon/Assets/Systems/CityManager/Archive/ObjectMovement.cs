using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Update() {
        Move();
    }

    private void Move() {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }
}
