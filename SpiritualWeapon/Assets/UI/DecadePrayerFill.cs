using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DecadePrayerFill : MonoBehaviour
{
    [SerializeField]
    private Image outline = null, lLargeBead = null, smallBead1 = null,
        smallBead2 = null, smallBead3 = null, smallBead4 = null, smallBead5 = null,
        smallBead6 = null, smallBead7 = null, smallBead8 = null, smallBead9 = null,
        smallBead10 = null, rLargeBead = null;

    [SerializeField]
    private Color beadColor, completedColor;

    [SerializeField]
    private float largeBeadTime = 0.1f, smallBeadTime = 0.1f,
        resetTime = 0.1f, completedTime, increment = 0.1f;
    
    private float r, g, b, a;

    private bool changed = false;

    public void Reset() {
        StopAllCoroutines();
        StartCoroutine(ResetHelper());
    }

    private IEnumerator ResetHelper() {
        while(lLargeBead.color.a > 0) {
            FadeOut(outline);
            FadeOut(lLargeBead);
            FadeOut(smallBead1);
            FadeOut(smallBead2);
            FadeOut(smallBead3);
            FadeOut(smallBead4);
            FadeOut(smallBead5);
            FadeOut(smallBead6);
            FadeOut(smallBead7);
            FadeOut(smallBead8);
            FadeOut(smallBead9);
            FadeOut(smallBead10);
            FadeOut(rLargeBead);
            yield return new WaitForSeconds(resetTime);
        }
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
            ColorChange(lLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }
        changed = false;
        
        lLargeBead.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);

        Debug.Log("Completed lLargeBead");

        r = smallBead1.color.r;
        g = smallBead1.color.g;
        b = smallBead1.color.b;
        a = smallBead1.color.a;

        while(!changed) {
            ColorChange(smallBead1, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead1.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead1");

        r = smallBead2.color.r;
        g = smallBead2.color.g;
        b = smallBead2.color.b;
        a = smallBead2.color.a;

        while(!changed) {
            ColorChange(smallBead2, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead2.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead2");

        r = smallBead3.color.r;
        g = smallBead3.color.g;
        b = smallBead3.color.b;
        a = smallBead3.color.a;

        while(!changed) {
            ColorChange(smallBead3, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead3.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead3");

        r = smallBead4.color.r;
        g = smallBead4.color.g;
        b = smallBead4.color.b;
        a = smallBead4.color.a;

        while(!changed) {
            ColorChange(smallBead4, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead4.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead4");

        r = smallBead5.color.r;
        g = smallBead5.color.g;
        b = smallBead5.color.b;
        a = smallBead5.color.a;

        while(!changed) {
            ColorChange(smallBead5, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead5.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead5");

        r = smallBead6.color.r;
        g = smallBead6.color.g;
        b = smallBead6.color.b;
        a = smallBead6.color.a;

        while(!changed) {
            ColorChange(smallBead6, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead6.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead6");

        r = smallBead7.color.r;
        g = smallBead7.color.g;
        b = smallBead7.color.b;
        a = smallBead7.color.a;

        while(!changed) {
            ColorChange(smallBead7, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead7.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead7");

        r = smallBead8.color.r;
        g = smallBead8.color.g;
        b = smallBead8.color.b;
        a = smallBead8.color.a;

        while(!changed) {
            ColorChange(smallBead8, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead8.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead8");

        r = smallBead9.color.r;
        g = smallBead9.color.g;
        b = smallBead9.color.b;
        a = smallBead9.color.a;

        while(!changed) {
            ColorChange(smallBead9, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead9.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead9");

        r = smallBead10.color.r;
        g = smallBead10.color.g;
        b = smallBead10.color.b;
        a = smallBead10.color.a;

        while(!changed) {
            ColorChange(smallBead10, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        
        smallBead10.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed smallBead10");

        r = rLargeBead.color.r;
        g = rLargeBead.color.g;
        b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(!changed) {
            ColorChange(rLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }
        changed = false;
        
        rLargeBead.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);
        Debug.Log("Completed rLargeBead");
    }

    private void ColorChange(Image img, Color col) {
        bool pass1 = false, pass2 = false, pass3 = false, pass4 = false;

        if(r < col.r) {
            r += increment;
        } else {
            pass1 = true;
        }

        if(g < col.g) {
            g += increment;
        } else {
            pass2 = true;
        }


        if(b < col.b) {
            b += increment;
        } else {
            pass3 = true;
        }


        if(a < 0.99) {
            a += increment;
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

    //private ColorChange2()

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
}
