using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MysteryRosaryFill : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private GameManager gameManager = null;
     private SpeechManager speechManager = null;

    [Header("Images")]
    [SerializeField] private Image lLargeBead = null;
    [SerializeField] private Image smallBead1 = null;
    [SerializeField] private Image smallBead2 = null;
    [SerializeField] private Image smallBead3 = null;
    [SerializeField] private Image smallBead4 = null;
    [SerializeField] private Image smallBead5 = null;
    [SerializeField] private Image smallBead6 = null;
    [SerializeField] private Image smallBead7 = null;
    [SerializeField] private Image smallBead8 = null;
    [SerializeField] private Image smallBead9 = null;
    [SerializeField] private Image smallBead10 = null;
    [SerializeField] private Image rLargeBead = null;

    [Header("Color")]
    [SerializeField] private Color completedColor;
    private float r = 0, g = 0, b = 0, a = 0;

    [SerializeField] private TMP_Text title = null;

    [Header("Fill Speeds")]
    [SerializeField] private float titleTime = 1f;
    [SerializeField] private float announcementTime = 1f;
    [SerializeField] private float lLargeBeadTime = 0.1f;
    [SerializeField] private float smallBeadTime = 0.1f;
    [SerializeField] private float rLargeBeadTime = 0.1f;
    [SerializeField] private float increment = 0.1f;

    [Header("Scrolling Text Values")]
    [SerializeField] private TMP_Text textBox = null;
    [SerializeField] private GameObject fadeOut = null;

    [SerializeField] private float lLargeBeadTextSpeed = 0.1f;
    [SerializeField] private float smallBeadTextSpeed = 0.1f;
    [SerializeField] private float rLargeBeadTextSpeed = 0.1f;
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

        r = 0;
        g = 0;
        b = 0;
        a = title.color.a;

        while(!changed) {
            IncrementTitle(title, new Color(0, 0, 0, 1));
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        while(!changed) {
            IncrementTitle(title, new Color(0, 0, 0, 0));
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        yield return new WaitForSeconds(announcementTime);
        
        gameManager.StartTransition();
        speechManager.StartNextPrayer(1);
        currentText = speechManager.StartScrollingText(1);

        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(lLargeBeadTextSpeed));

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
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead1.color.r;
        g = smallBead1.color.g;
        b = smallBead1.color.b;
        a = smallBead1.color.a;

        while(!changed) {
            IncrementColor(smallBead1, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead1");

        speechManager.StartNextPrayer(3);
        currentText = speechManager.StartScrollingText(3);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead2.color.r;
        g = smallBead2.color.g;
        b = smallBead2.color.b;
        a = smallBead2.color.a;

        while(!changed) {
            IncrementColor(smallBead2, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead2");

        speechManager.StartNextPrayer(4);
        currentText = speechManager.StartScrollingText(4);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead3.color.r;
        g = smallBead3.color.g;
        b = smallBead3.color.b;
        a = smallBead3.color.a;

        while(!changed) {
            IncrementColor(smallBead3, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead3");

        speechManager.StartNextPrayer(5);
        currentText = speechManager.StartScrollingText(5);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead4.color.r;
        g = smallBead4.color.g;
        b = smallBead4.color.b;
        a = smallBead4.color.a;

        while(!changed) {
            IncrementColor(smallBead4, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead4");

        speechManager.StartNextPrayer(6);
        currentText = speechManager.StartScrollingText(6);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead5.color.r;
        g = smallBead5.color.g;
        b = smallBead5.color.b;
        a = smallBead5.color.a;

        while(!changed) {
            IncrementColor(smallBead5, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead5");

        speechManager.StartNextPrayer(7);
        currentText = speechManager.StartScrollingText(7);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead6.color.r;
        g = smallBead6.color.g;
        b = smallBead6.color.b;
        a = smallBead6.color.a;

        while(!changed) {
            IncrementColor(smallBead6, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead6");

        speechManager.StartNextPrayer(8);
        currentText = speechManager.StartScrollingText(8);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead7.color.r;
        g = smallBead7.color.g;
        b = smallBead7.color.b;
        a = smallBead7.color.a;

        while(!changed) {
            IncrementColor(smallBead7, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead7");

        speechManager.StartNextPrayer(9);
        currentText = speechManager.StartScrollingText(9);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead8.color.r;
        g = smallBead8.color.g;
        b = smallBead8.color.b;
        a = smallBead8.color.a;

        while(!changed) {
            IncrementColor(smallBead8, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead8");

        speechManager.StartNextPrayer(10);
        currentText = speechManager.StartScrollingText(10);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead9.color.r;
        g = smallBead9.color.g;
        b = smallBead9.color.b;
        a = smallBead9.color.a;

        while(!changed) {
            IncrementColor(smallBead9, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead9");

        speechManager.StartNextPrayer(11);
        currentText = speechManager.StartScrollingText(11);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(smallBeadTextSpeed));

        r = smallBead10.color.r;
        g = smallBead10.color.g;
        b = smallBead10.color.b;
        a = smallBead10.color.a;

        while(!changed) {
            IncrementColor(smallBead10, completedColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;

        Debug.Log("Completed smallBead10");

        speechManager.StartNextPrayer(12);
        currentText = speechManager.StartScrollingText(12);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(rLargeBeadTextSpeed));

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

        if(speechManager.GetStartingMystery() == speechManager.GetEndingMystery()) {
            speechManager.EndRosary();
        } else {
            gameManager.NextScene();
        }
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
            a = col.a;
        }

        img.color = new Color(r, g, b, a);
    }

    private void IncrementTitle(TMP_Text text, Color col) {
        bool pass = false;

        if(a < col.a - 0.05) {
            a += increment;
        } else if(a > col.a + 0.05) {
            a -= increment;
        } else {
            pass = true;
        }

        if(pass) {
            changed = true;

            a = col.a;
        }

        text.color = new Color(r, g, b, a);
    }

    private IEnumerator Scroll(float textSpeed) {
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
