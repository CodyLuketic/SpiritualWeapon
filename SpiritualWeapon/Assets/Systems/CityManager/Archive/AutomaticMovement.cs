using System.Collections;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    /*
    private float speed = 1f, tempSpeed = 1f, random = 0;

    private void Update() {
        Move();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("SpawnDeleter")) {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Building") || other.gameObject.CompareTag("NPC")) {
            random = Random.Range(0, 3);
            transform.Translate(-Vector3.forward * random);
        }
    }

    private void Move() {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }

    public float GetTempSpeed() {
        return GetTempSpeedHelper();
    }
    private float GetTempSpeedHelper() {
        return tempSpeed;
    }

    public void SetTempSpeed(float _tempSpeed) {
        SetTempSpeedHelper(_tempSpeed);
    }
    private void SetTempSpeedHelper(float _tempSpeed) {
        tempSpeed = _tempSpeed;
    }

    public void SetSpeed(float _speed) {
        SetSpeedHelper(_speed);
    }
    private void SetSpeedHelper(float _speed) {
        speed = _speed;
    }

    
    public void SlowSpeed(float slowAmount, float waitTime) {
        StartCoroutine(SlowSpeedHelper(slowAmount, waitTime));
    }
    private IEnumerator SlowSpeedHelper(float slowAmount, float waitTime) {
        while(speed > 0) {
            speed -= slowAmount;
            yield return new WaitForSeconds(waitTime);
        }

        speed = 0;
    }

    public void IncreaseSpeed(float increaseAmount, float waitTime) {
        StartCoroutine(IncreaseSpeedHelper(increaseAmount, waitTime));
    }
    private IEnumerator IncreaseSpeedHelper(float increaseAmount, float waitTime) {
        while(speed < tempSpeed) {
            speed += increaseAmount;
            yield return new WaitForSeconds(waitTime);
        }
    }
    */
    
}
