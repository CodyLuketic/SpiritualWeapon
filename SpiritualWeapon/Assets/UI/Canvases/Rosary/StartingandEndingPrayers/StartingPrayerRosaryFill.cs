using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartingPrayerRosaryFill : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image cross = null;
    [SerializeField] private Image lLargeBead = null;
    [SerializeField] private Image lSmallBead = null;
    [SerializeField] private Image mSmallBead = null;
    [SerializeField] private Image rSmallBead = null;
    [SerializeField] private Image rLargeBead = null;

    [SerializeField] private Color completedColor;

    [Header("Basic Values")]
    [SerializeField] private float crossTime = 0.1f;
    [SerializeField] private float lLargeBeadTime = 0.1f;
    [SerializeField] private float lSmallBeadTime = 0.1f;
    [SerializeField] private float mSmallBeadTime = 0.1f;
    [SerializeField] private float rSmallBeadTime = 0.1f;
    [SerializeField] private float rLargeBeadTime = 0.1f;
    [SerializeField] private float completedTime = 0.05f;
    [SerializeField] private float increment = 0.1f;

    private float r = 0, g = 0, b = 0, a = 0;

    private bool changed = false;

    public void Fill() {
        StopAllCoroutines();
        StartCoroutine(FillHelper());
    }
    private IEnumerator FillHelper() {
        yield return new WaitForSeconds(crossTime);

        r = cross.color.r;
        g = cross.color.g;
        b = cross.color.b;
        a = cross.color.a;

        while(!changed) {
            IncrementColor(cross, completedColor);
            yield return new WaitForSeconds(completedTime);
        }
        changed = false;

        Debug.Log("Completed cross");

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
