using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroductionCanvas : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RawImage background = null;
    [SerializeField] private RawImage title = null;

    [SerializeField] private Image demon = null;
    [SerializeField] private TMP_Text demonText = null;

    [SerializeField] private Image stDominic = null;
    [SerializeField] private TMP_Text stDominicText = null;

    [SerializeField] private Image jesusNativity = null;
    [SerializeField] private TMP_Text jesusNativityText = null;

    [SerializeField] private Image jesusEuch = null;
    [SerializeField] private TMP_Text jesusEuchText = null;

    [SerializeField] private Image jesusCrux = null;
    [SerializeField] private TMP_Text jesusCruxText = null;

    [SerializeField] private Image jesusAscend = null;
    [SerializeField] private TMP_Text jesusAscendText = null;


    private void Start() {
        
    }

    private void Update() {
        
    }
}
