using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair = null; 

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update() {
        AlignCrosshair();
    }

    private void AlignCrosshair() {
        crosshair.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
}
