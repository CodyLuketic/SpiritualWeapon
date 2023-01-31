using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosaryCanvas : MonoBehaviour
{
    [SerializeField]
    private StartingPrayerFill startFill = null;
    [SerializeField]
    private DecadePrayerFill decadeFill = null;

    private bool started = false;

    private void Start() {
        startFill.Fill();
    }
}
