using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] private float speed = 0.5f;

    private void Update() {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(speed * Time.time, 0);
    }
}
