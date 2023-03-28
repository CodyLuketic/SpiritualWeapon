using System.Collections;
using UnityEngine;

public class AutomaticMovement : MonoBehaviour
{
    private float speed = 1f, tempSpeed = 1f;

    private void Start() {
        tempSpeed = speed;
    }

    private void Update() {
        Move();
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

    public void SetSpeed(float _speed) {
        SetSpeedHelper(_speed);
    }
    private void SetSpeedHelper(float _speed) {
        speed = _speed;
    }

    /*
    public void SlowSpeed(float slowAmount, float waitTime) {
        StartCoroutine(SlowSpeedHelper(slowAmount, waitTime));
    }
    private IEnumerator SlowSpeedHelper(float slowAmount, float waitTime) {
        while(speed > 0) {
            speed -= slowAmount;
            yield return new WaitForSeconds(waitTime);
        }
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
