using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair = null; 
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update() {
        AlignCrosshair();
    }

    private void AlignCrosshair() {
        crosshair.transform.position = new Vector3(Input.mousePosition.x + offsetX, Input.mousePosition.y + offsetY, 0);
    }
}
