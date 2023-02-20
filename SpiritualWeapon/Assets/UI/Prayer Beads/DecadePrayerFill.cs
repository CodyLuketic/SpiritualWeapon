using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DecadePrayerFill : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private RosaryCanvas rosaryCanvas = null;

    [Header("Objects")]
    [SerializeField] private Image outline = null;
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

    private Color outlineColor, largeBeadColor, smallBeadColor;

    [Header("Basic Values")]
    [SerializeField] private float outlineAlpha = 1f;
    [SerializeField] private float outlineTime = 0.1f;
    [SerializeField] private float largeBeadTime = 0.1f;
    [SerializeField] private float smallBeadTime = 0.1f;
    [SerializeField] private float resetTime = 0.1f;
    [SerializeField] private float completedTime;
    [SerializeField] private float increment = 0.1f;

    private float r = 0, g = 0, b = 0, a = 1;
    private float waitTime = -1;

    private bool changed = false;

    private void Start() {
        outlineColor = outline.color;
        outlineColor.a = outlineAlpha;
        largeBeadColor = lLargeBead.color;
        smallBeadColor = smallBead1.color;
    }

    public void Reset() {
        StopAllCoroutines();
        StartCoroutine(ResetHelper());
    }
    private IEnumerator ResetHelper() {
        while(lLargeBead.color.a > 0) {
            FadeOutAlpha(lLargeBead);
            FadeOutAlpha(smallBead1);
            FadeOutAlpha(smallBead2);
            FadeOutAlpha(smallBead3);
            FadeOutAlpha(smallBead4);
            FadeOutAlpha(smallBead5);
            FadeOutAlpha(smallBead6);
            FadeOutAlpha(smallBead7);
            FadeOutAlpha(smallBead8);
            FadeOutAlpha(smallBead9);
            FadeOutAlpha(smallBead10);
            FadeOutAlpha(rLargeBead);
            yield return new WaitForSeconds(resetTime);
        }
        //rosaryCanvas.SetDecadeActive(false);
    }

    public void FullReset() {
        StopAllCoroutines();
        StartCoroutine(FullResetHelper());
    }
    private IEnumerator FullResetHelper() {
        while(lLargeBead.color.a > 0) {
            FadeOutAlpha(outline);
            FadeOutAlpha(lLargeBead);
            FadeOutAlpha(smallBead1);
            FadeOutAlpha(smallBead2);
            FadeOutAlpha(smallBead3);
            FadeOutAlpha(smallBead4);
            FadeOutAlpha(smallBead5);
            FadeOutAlpha(smallBead6);
            FadeOutAlpha(smallBead7);
            FadeOutAlpha(smallBead8);
            FadeOutAlpha(smallBead9);
            FadeOutAlpha(smallBead10);
            FadeOutAlpha(rLargeBead);
            yield return new WaitForSeconds(resetTime);
        }
        ColorOut();
        gameObject.SetActive(false);
    }

    /*
    private IEnumerator OutlineFill() {
        r = outlineColor.r;
        g = outlineColor.g;
        b = outlineColor.b;
        a = 0;

        while(!changed) {
            IncrementColor(outline, outlineColor);
            yield return new WaitForSeconds(outlineTime);
        }
        changed = false;
        Fill();
    }
    */

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }

    private IEnumerator FillHelper() {
        r = largeBeadColor.r;
        g = largeBeadColor.g;
        b = largeBeadColor.b;
        a = largeBeadColor.a;

        while(!changed) {
            IncrementColor(lLargeBead, largeBeadColor);
            //yield return new WaitForSeconds(largeBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(lLargeBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed lLargeBead");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead1, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead1, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead1");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead2, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead2, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead2");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead3, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead3, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead3");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead4, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead4, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead4");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead5, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead5, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead5");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead6, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead6, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead6");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead7, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead7, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead7");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead8, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead8, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead8");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead9, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead9, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead9");

        r = smallBeadColor.r;
        g = smallBeadColor.g;
        b = smallBeadColor.b;
        a = smallBeadColor.a;

        while(!changed) {
            IncrementColor(smallBead10, smallBeadColor);
            //yield return new WaitForSeconds(smallBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead10, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead10");

        r = largeBeadColor.r;
        g = largeBeadColor.g;
        b = largeBeadColor.b;
        a = largeBeadColor.a;

        while(!changed) {
            IncrementColor(rLargeBead, largeBeadColor);
            //yield return new WaitForSeconds(largeBeadTime);
            yield return new WaitForSeconds(waitTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(rLargeBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed rLargeBead");

        Reset();
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

    private void FadeOutAlpha(Image img) {
        if(a > 0) {
            a -= increment;
        }
        img.color = new Color(r, g, b, a);
    }

    private void ColorOut() {
        outline.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0);
        lLargeBead.color = new Color(largeBeadColor.r, largeBeadColor.g, largeBeadColor.b, 0);
        smallBead1.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead2.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead3.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead4.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead5.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead6.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead7.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead8.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead9.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        smallBead10.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        rLargeBead.color = new Color(largeBeadColor.r, largeBeadColor.g, largeBeadColor.b, 0);
    }

    public void SetWaitTime(float time) {
        SetWaitTimeHelper(time);
    }
    private void SetWaitTimeHelper(float time) {
        waitTime = time;
    }
}
