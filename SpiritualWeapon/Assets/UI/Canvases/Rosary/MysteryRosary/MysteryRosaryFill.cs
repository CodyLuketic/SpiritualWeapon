using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MysteryRosaryFill : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private GameManager gameManager = null;
    private SpeechManager speechScript = null;

    [Header("Objects")]
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

    [SerializeField] private Color completedColor;

    [Header("Basic Values")]
    [SerializeField] private float announcementTime = 1f;
    [SerializeField] private float lLargeBeadTime = 0.1f;
    [SerializeField] private float smallBeadTime = 0.1f;
    [SerializeField] private float rLargeBeadTime = 0.1f;
    [SerializeField] private float increment = 0.1f;

    private float r = 0, g = 0, b = 0, a = 0;

    private bool changed = false;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        speechScript = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();
    }

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }

    private IEnumerator FillHelper() {
        speechScript.StartNextPrayer(0);

        yield return new WaitForSeconds(announcementTime);

        speechScript.StartNextPrayer(1);

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

        speechScript.StartNextPrayer(2);

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

        speechScript.StartNextPrayer(3);

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

        speechScript.StartNextPrayer(4);

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

        speechScript.StartNextPrayer(5);

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

        speechScript.StartNextPrayer(6);

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

        speechScript.StartNextPrayer(7);

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

        speechScript.StartNextPrayer(8);

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

        speechScript.StartNextPrayer(9);

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

        speechScript.StartNextPrayer(10);

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

        speechScript.StartNextPrayer(11);

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

        speechScript.StartNextPrayer(12);

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

        gameManager.NextScene();
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
}