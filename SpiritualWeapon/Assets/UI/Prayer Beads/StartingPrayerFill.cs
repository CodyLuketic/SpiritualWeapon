using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartingPrayerFill : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private RosaryCanvas rosaryCanvas = null;

    [Header("Objects")]
    [SerializeField] private Image cross = null;
    [SerializeField] private Image outline = null;
    [SerializeField] private Image lLargeBead = null;
    [SerializeField] private Image lSmallBead = null;
    [SerializeField] private Image mSmallBead = null;
    [SerializeField] private Image rSmallBead = null;
    [SerializeField] private Image rLargeBead = null;

    [SerializeField] private Color completedColor;

    private Color crossColor, outlineColor, largeBeadColor, smallBeadColor;

    [Header("Basic Values")]
    [SerializeField] private float largeBeadTime = 0.1f;
    [SerializeField] private float smallBeadTime = 0.1f;
    [SerializeField] private float resetTime = 0.1f;
    [SerializeField] private float completedTime = 0.05f;
    [SerializeField] private float increment = 0.1f;

    private float r = 0, g = 0, b = 0, a = 0, waitTime = 1f;

    private bool changed = false;

    private void Start() {
        crossColor = cross.color;
        outlineColor = outline.color;
        largeBeadColor = lLargeBead.color;
        smallBeadColor = lSmallBead.color;
    }

    public void Reset() {
        StopAllCoroutines();
        StartCoroutine(ResetHelper());
    }
    private IEnumerator ResetHelper() {
        r = outline.color.r;
        g = outline.color.g;
        b = outline.color.b;
        a = outline.color.a;

        while(!changed) {
            IncrementColor(outline, new Color(0, 0, 0, 1));
            yield return new WaitForSeconds(largeBeadTime);
        }
        changed = false;

        while(cross.color.a > 0) {
            FadeOutAlpha(cross);
            FadeOutAlpha(outline);
            FadeOutAlpha(lLargeBead);
            FadeOutAlpha(lSmallBead);
            FadeOutAlpha(mSmallBead);
            FadeOutAlpha(rSmallBead);
            FadeOutAlpha(rLargeBead);
            yield return new WaitForSeconds(resetTime);
        }
        ColorOut();
    }

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }
    private IEnumerator FillHelper() {
        yield return new WaitForSeconds(waitTime);

        r = cross.color.r;
        g = cross.color.g;
        b = cross.color.b;
        a = cross.color.a;

        while(!changed) {
            IncrementColor(cross, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;
        yield return new WaitForSeconds(completedTime);

        Debug.Log("Completed cross");

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

        r = lSmallBead.color.r;
        g = lSmallBead.color.g;
        b = lSmallBead.color.b;
        a = lSmallBead.color.a;

        while(!changed) {
            IncrementColor(lSmallBead, smallBeadColor);
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
            IncrementColor(mSmallBead, smallBeadColor);
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
            IncrementColor(rSmallBead, smallBeadColor);
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
            r += increment / waitTime;
        } else if(r > col.r + 0.05) {
            r -= increment / waitTime;
        } else {
            pass1 = true;
        }

        if(g < col.g -0.05) {
            g += increment / waitTime;
        } else if(g > col.g + 0.05) {
            g -= increment / waitTime;
        } else {
            pass2 = true;
        }

        if(b < col.b -0.05) {
            b += increment / waitTime;
        } else if(b > col.b + 0.05) {
            b -= increment / waitTime;
        } else {
            pass3 = true;
        }

        if(a < col.a -0.05) {
            a += increment / waitTime;
        } else if(a > col.a + 0.05) {
            a -= increment / waitTime;
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
        r = img.color.r;
        g = img.color.g;
        b = img.color.b;
        a = img.color.a;

        if(a > 0) {
            a -= increment;
        }
        img.color = new Color(r, g, b, a);
    }

    private void ColorOut() {
        cross.color = new Color(crossColor.r, crossColor.g, crossColor.b, 0);
        outline.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 0);
        lLargeBead.color = new Color(largeBeadColor.r, largeBeadColor.g, largeBeadColor.b, 0);
        lSmallBead.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        mSmallBead.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        rSmallBead.color = new Color(smallBeadColor.r, smallBeadColor.g, smallBeadColor.b, 0);
        rLargeBead.color = new Color(largeBeadColor.r, largeBeadColor.g, largeBeadColor.b, 0);
    }

    public void SetWaitTime(float time) {
        SetWaitTimeHelper(time);
    }
    private void SetWaitTimeHelper(float time) {
        waitTime = time;
    }
}
