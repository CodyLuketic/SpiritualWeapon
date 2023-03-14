using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float speed = 1f;

    private void Update() {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }
}
