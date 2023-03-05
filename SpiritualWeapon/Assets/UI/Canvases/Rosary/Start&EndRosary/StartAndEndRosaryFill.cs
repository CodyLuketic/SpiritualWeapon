using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartAndEndRosaryFill : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private GameManager gameManager = null;
    private SpeechManager speechManager = null;

    [Header("Images")]
    [SerializeField] private Image cross = null;
    [SerializeField] private Image lLargeBead = null;
    [SerializeField] private Image lSmallBead = null;
    [SerializeField] private Image mSmallBead = null;
    [SerializeField] private Image rSmallBead = null;
    [SerializeField] private Image rLargeBead = null;

    [Header("Color")]
    [SerializeField] private Color completedColor;
    private float r = 0, g = 0, b = 0, a = 0;

    [Header("Fill Speeds")]
    [SerializeField] private float crossTime = 0.05f;
    [SerializeField] private float lLargeBeadTime = 0.1f;
    [SerializeField] private float lSmallBeadTime = 0.1f;
    [SerializeField] private float mSmallBeadTime = 0.1f;
    [SerializeField] private float rSmallBeadTime = 0.1f;
    [SerializeField] private float rLargeBeadTime = 0.1f;
    [SerializeField] private float increment = 0.1f;

    [Header("Scrolling Text Values")]
    [SerializeField] private TMP_Text textBox = null;
    [SerializeField] private GameObject fadeOut = null;

    [SerializeField] private float textSpeed = 0.01f;
    [SerializeField] private int maxStringLength = 10;

    private string currentText = null;
    private Coroutine textCoroutine = null;

    private bool changed = false;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }
    private IEnumerator FillHelper() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();
        speechManager.StartNextPrayer(0);
        currentText = speechManager.StartScrollingText(0);

        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = cross.color.r;
        g = cross.color.g;
        b = cross.color.b;
        a = cross.color.a;

        while(!changed) {
            IncrementColor(cross, completedColor);
            yield return new WaitForSeconds(crossTime);
        }
        changed = false;

        Debug.Log("Completed cross");

        speechManager.StartNextPrayer(1);
        currentText = speechManager.StartScrollingText(1);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = lLargeBead.color.r;
        g = lLargeBead.color.g;
        b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(!changed) {
            IncrementColor(lLargeBead, completedColor);
            yield return new WaitForSeconds(lLargeBeadTime);
        }
        changed = false;

        Debug.Log("Completed lLargeBead");

        speechManager.StartNextPrayer(2);
        currentText = speechManager.StartScrollingText(2);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = lSmallBead.color.r;
        g = lSmallBead.color.g;
        b = lSmallBead.color.b;
        a = lSmallBead.color.a;

        while(!changed) {
            IncrementColor(lSmallBead, completedColor);
            yield return new WaitForSeconds(lSmallBeadTime);
        }
        changed = false;

        Debug.Log("Completed lSmallBead");

        speechManager.StartNextPrayer(3);
        currentText = speechManager.StartScrollingText(3);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = mSmallBead.color.r;
        g = mSmallBead.color.g;
        b = mSmallBead.color.b;
        a = mSmallBead.color.a;

        while(!changed) {
            IncrementColor(mSmallBead, completedColor);
            yield return new WaitForSeconds(mSmallBeadTime);
        }
        changed = false;

        Debug.Log("Completed mSmallBead");

        speechManager.StartNextPrayer(4);
        currentText = speechManager.StartScrollingText(4);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = rSmallBead.color.r;
        g = rSmallBead.color.g;
        b = rSmallBead.color.b;
        a = rSmallBead.color.a;

        while(!changed) {
            IncrementColor(rSmallBead, completedColor);
            yield return new WaitForSeconds(rSmallBeadTime);
        }
        changed = false;

        Debug.Log("Completed rSmallBead");

        speechManager.StartNextPrayer(5);
        currentText = speechManager.StartScrollingText(5);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll());

        r = rLargeBead.color.r;
        g = rLargeBead.color.g;
        b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(!changed) {
            IncrementColor(rLargeBead, completedColor);
            yield return new WaitForSeconds(rLargeBeadTime);
        }
        changed = false;

        Debug.Log("Completed rLargeBead");

        CheckNextScene();
    }

    private void CheckNextScene() {
        int nextScene = PlayerPrefs.GetInt("Decades");
        int endingMystery = 19;

        switch(nextScene) {
            case 0:
                gameManager.ToJoyfulMysteries();
                break;
            case 1:
                gameManager.ToJoyfulMysteries();
                endingMystery = 4;
                break;
            case 2:
                gameManager.ToLuminousMysteries();
                endingMystery = 9;
                break;
            case 3:
                gameManager.ToSorrowfulMysteries();
                endingMystery = 14;
                break;
            case 4:
                gameManager.ToGloriusMysteries();
                break;
            default:
                Debug.Log("Error");
                break;
        }

        speechManager.SetEndingMystery(endingMystery);
    }

    private void IncrementColor(Image img, Color col) {
        bool pass1 = false, pass2 = false, pass3 = false, pass4 = false;

        if(r < col.r - 0.05) {
            r += increment;
        } else if(r > col.r + 0.05) {
            r -= increment;
        } else {
            pass1 = true;
        }

        if(g < col.g - 0.05) {
            g += increment;
        } else if(g > col.g + 0.05) {
            g -= increment;
        } else {
            pass2 = true;
        }

        if(b < col.b - 0.05) {
            b += increment;
        } else if(b > col.b + 0.05) {
            b -= increment;
        } else {
            pass3 = true;
        }

        if(a < col.a - 0.05) {
            a += increment;
        } else if(a > col.a + 0.05) {
            a -= increment;
        } else {
            pass4 = true;
        }

        if(pass1 && pass2 && pass3 && pass4) {
            changed = true;
            r = col.r;
            g = col.g;
            b = col.b;
        } else {
            img.color = new Color(r, g, b, a);
        }
    }

    private IEnumerator Scroll() {
        currentText = currentText.Replace("\r", "");

        for (int i = 0, j = 0; i < currentText.Length + 1; i++) {
            textBox.text = currentText.Substring(j, i - j);

            if(textBox.text.Length > maxStringLength) {
                fadeOut.SetActive(true);
                j++;
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }   
}
