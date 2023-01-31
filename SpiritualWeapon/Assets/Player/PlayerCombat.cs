using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private float cooldown = 1f;
    private bool canAttack = true;

    private void Update()
    {
        if(Input.GetAxis("Fire1") > 0 && canAttack) {
            StartCoroutine(Attack());
            canAttack = false;
        }
    }

    private IEnumerator Attack() {
        Debug.Log("Player Attacked");
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
