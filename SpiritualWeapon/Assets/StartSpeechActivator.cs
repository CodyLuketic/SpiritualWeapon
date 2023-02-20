using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpeechActivator : MonoBehaviour
{
    private PrayerAndTextManager manager = null;

    private void Start() {
        manager = GameObject.FindGameObjectWithTag("PrayerAndTextManager").GetComponent<PrayerAndTextManager>();

        manager.StartingPrayers();
    }
}
