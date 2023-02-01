using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosaryCanvas : MonoBehaviour
{
    [SerializeField]
    private StartingPrayerFill startFill = null;
    [SerializeField]
    private DecadePrayerFill decadeFill = null;

    private bool startActive = true, startDone = false,
        decadeActive = true, decadeDone = false;

    
    private void Start() {
        startFill.Fill();
        //decadeFill.Fill();
    }

    
    private void Update() {
        if(!startActive && !startDone) {
            ActivateDecade();
        }

        if(!decadeActive && decadeDone) {
            ReactivateDecade();
        }
    }

    private void ActivateDecade() {
        startFill.gameObject.SetActive(true);
        startDone = true;
        decadeFill.gameObject.SetActive(true);
        decadeActive = false;
    }

    private void ReactivateDecade() {
        decadeFill.Fill();
        decadeActive = true;
    }

    public void SetStartActive(bool isActive) {
        SetStartActiveHelper(isActive);
    }
    private void SetStartActiveHelper(bool isActive) {
        startActive = isActive;
    }

    public void SetDecadeActive(bool isActive) {
        SetDecadeActiveHelper(isActive);
    }
    private void SetDecadeActiveHelper(bool isActive) {
        decadeActive = isActive;
    }  
}
