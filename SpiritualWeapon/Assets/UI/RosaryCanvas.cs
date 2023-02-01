using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosaryCanvas : MonoBehaviour
{
    [SerializeField]
    private StartingPrayerFill startFill = null;
    [SerializeField]
    private DecadePrayerFill decadeFill = null;

    private bool startEnd = false, decadeActive = false;

    private void Start() {
        startFill.Fill();
    }

    private void Update() {
        if(decadeFill.gameObject.activeSelf) {
            decadeActive = decadeFill.GetDecadeActive();
        }

        if(!startFill.gameObject.activeSelf) {
            decadeFill.gameObject.SetActive(true);
            decadeFill.Fill();
            decadeActive = true;
        } else if(startFill.gameObject.activeSelf && !decadeActive) {
            decadeFill.gameObject.SetActive(true);
            decadeFill.Fill();
        }
    }
}
