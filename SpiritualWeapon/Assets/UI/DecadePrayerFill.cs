using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DecadePrayerFill : MonoBehaviour
{
    [SerializeField]
    private RosaryCanvas rosaryCanvas = null;

    [SerializeField]
    private Image outline = null, lLargeBead = null, smallBead1 = null,
        smallBead2 = null, smallBead3 = null, smallBead4 = null, smallBead5 = null,
        smallBead6 = null, smallBead7 = null, smallBead8 = null, smallBead9 = null,
        smallBead10 = null, rLargeBead = null;

    private Color outlineColor, largeBeadColor, smallBeadColor;
    
    [SerializeField]
    private Color completedColor;

    [SerializeField]
    private float outlineTime = 0.1f, largeBeadTime = 0.1f, smallBeadTime = 0.1f,
        resetTime = 0.1f, completedTime, increment = 0.1f;
    
    private float r, g, b, a;

    private bool changed = false;

    private void Start() {
        outlineColor = outline.color;
        largeBeadColor = lLargeBead.color;
        smallBeadColor = smallBead1.color;
        StartCoroutine(OutlineFill());
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
        rosaryCanvas.SetDecadeActive(false);
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

    private IEnumerator OutlineFill() {
        while(!changed) {
            IncrementColor(outline, outlineColor);
            yield return new WaitForSeconds(outlineTime);
        }
        changed = false;
        Fill();
    }

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }

    private IEnumerator FillHelper() {
        r = lLargeBead.color.r;
        g = lLargeBead.color.g;
        b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(!changed) {
            IncrementColor(lLargeBead, largeBeadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(lLargeBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed lLargeBead");

        r = smallBead1.color.r;
        g = smallBead1.color.g;
        b = smallBead1.color.b;
        a = smallBead1.color.a;

        while(!changed) {
            IncrementColor(smallBead1, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead1, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead1");

        r = smallBead2.color.r;
        g = smallBead2.color.g;
        b = smallBead2.color.b;
        a = smallBead2.color.a;

        while(!changed) {
            IncrementColor(smallBead2, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead2, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead2");

        r = smallBead3.color.r;
        g = smallBead3.color.g;
        b = smallBead3.color.b;
        a = smallBead3.color.a;

        while(!changed) {
            IncrementColor(smallBead3, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead3, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead3");

        r = smallBead4.color.r;
        g = smallBead4.color.g;
        b = smallBead4.color.b;
        a = smallBead4.color.a;

        while(!changed) {
            IncrementColor(smallBead4, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead4, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead4");

        r = smallBead5.color.r;
        g = smallBead5.color.g;
        b = smallBead5.color.b;
        a = smallBead5.color.a;

        while(!changed) {
            IncrementColor(smallBead5, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead5, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead5");

        r = smallBead6.color.r;
        g = smallBead6.color.g;
        b = smallBead6.color.b;
        a = smallBead6.color.a;

        while(!changed) {
            IncrementColor(smallBead6, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead6, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead6");

        r = smallBead7.color.r;
        g = smallBead7.color.g;
        b = smallBead7.color.b;
        a = smallBead7.color.a;

        while(!changed) {
            IncrementColor(smallBead7, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead7, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead7");

        r = smallBead8.color.r;
        g = smallBead8.color.g;
        b = smallBead8.color.b;
        a = smallBead8.color.a;

        while(!changed) {
            IncrementColor(smallBead8, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead8, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead8");

        r = smallBead9.color.r;
        g = smallBead9.color.g;
        b = smallBead9.color.b;
        a = smallBead9.color.a;

        while(!changed) {
            IncrementColor(smallBead9, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead9, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead9");

        r = smallBead10.color.r;
        g = smallBead10.color.g;
        b = smallBead10.color.b;
        a = smallBead10.color.a;

        while(!changed) {
            IncrementColor(smallBead10, smallBeadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(smallBead10, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed smallBead10");

        r = rLargeBead.color.r;
        g = rLargeBead.color.g;
        b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(!changed) {
            IncrementColor(rLargeBead, largeBeadColor);
            yield return new WaitForSeconds(largeBeadTime);
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

        if(r < col.r -0.05) {
            r += increment;
        } else if(r > col.r + 0.05) {
            r -= increment;
        } else {
            pass1 = true;
        }

        if(g < col.g -0.05) {
            g += increment;
        } else if(g > col.g + 0.05) {
            g -= increment;
        } else {
            pass2 = true;
        }

        if(b < col.b -0.05) {
            b += increment;
        } else if(b > col.b + 0.05) {
            b -= increment;
        } else {
            pass3 = true;
        }

        if(a < col.a -0.05) {
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

    /*
    private void FadeOut(Image img) {
        if(r < 1) {
            r += increment;
        }

        if(g < 1) {
            g += increment;
        }

        if(b < 1) {
            b += increment;
        }

        if(a > 0) {
            a -= increment;
        }
        img.color = new Color(r, g, b, a);
    }
    */

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
}
