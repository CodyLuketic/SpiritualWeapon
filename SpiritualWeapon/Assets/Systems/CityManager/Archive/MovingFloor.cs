using System.Collections;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    /*
    private float speed = 0.5f, tempSpeed = 1f;
    private float offset = 0f;

    private void Update() {
        Move();
    }

    private void Move() {
        offset -= speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
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
