using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartingPrayerFill : MonoBehaviour
{
    [SerializeField]
    private Image cross = null, outline = null, lLargeBead = null,
        lSmallBead = null, mSmallBead = null, rSmallBead = null, rLargeBead = null;

    [SerializeField]
    private Color crossColor, beadColor, completedColor;

    [SerializeField]
    private float crossTime = 0.1f, largeBeadTime = 0.1f, smallBeadTime = 0.1f,
        resetTime = 0.1f, completedTime = 0.05f, increment = 0.1f;

    private float r, g, b, a;

    private bool changed = false;

    public void Reset() {
        StopAllCoroutines();
        StartCoroutine(ResetHelper());
    }
    private IEnumerator ResetHelper() {
        while(cross.color.a > 0) {
            FadeOut(cross);
            FadeOut(outline);
            FadeOut(lLargeBead);
            FadeOut(lSmallBead);
            FadeOut(mSmallBead);
            FadeOut(rSmallBead);
            FadeOut(rLargeBead);
            yield return new WaitForSeconds(resetTime);
        }
        gameObject.SetActive(false);
    }

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }
    private IEnumerator FillHelper() {
        yield return new WaitForSeconds(crossTime);

        cross.CrossFadeColor(completedColor, completedTime, false, false);
        yield return new WaitForSeconds(completedTime);

        Debug.Log("Completed cross");

        r = lLargeBead.color.r;
        g = lLargeBead.color.g;
        b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(!changed) {
            IncrementColor(lLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(lLargeBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed lLargeBead");

        r = lSmallBead.color.r;
        g = lSmallBead.color.g;
        b = lSmallBead.color.b;
        a = lSmallBead.color.a;

        while(!changed) {
            IncrementColor(lSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(lSmallBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed lSmallBead");

        r = mSmallBead.color.r;
        g = mSmallBead.color.g;
        b = mSmallBead.color.b;
        a = mSmallBead.color.a;

        while(!changed) {
            IncrementColor(mSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(mSmallBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed mSmallBead");

        r = rSmallBead.color.r;
        g = rSmallBead.color.g;
        b = rSmallBead.color.b;
        a = rSmallBead.color.a;

        while(!changed) {
            IncrementColor(rSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }
        changed = false;
        while(!changed) {
            IncrementColor(rSmallBead, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed rSmallBead");

        r = rLargeBead.color.r;
        g = rLargeBead.color.g;
        b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(!changed) {
            IncrementColor(rLargeBead, beadColor);
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
