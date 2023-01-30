using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DecadePrayersFill : MonoBehaviour
{
    [SerializeField]
    private Image outline = null;
    [SerializeField]
    private Image lLargeBead = null;
    [SerializeField]
    private Image smallBead1 = null;
    [SerializeField]
    private Image smallBead2 = null;
    [SerializeField]
    private Image smallBead3 = null;
    [SerializeField]
    private Image smallBead4 = null;
    [SerializeField]
    private Image smallBead5 = null;
    [SerializeField]
    private Image smallBead6 = null;
    [SerializeField]
    private Image smallBead7 = null;
    [SerializeField]
    private Image smallBead8 = null;
    [SerializeField]
    private Image smallBead9 = null;
    [SerializeField]
    private Image smallBead10 = null;
    [SerializeField]
    private Image rLargeBead = null;

    [SerializeField]
    private Color outlineColor;
    [SerializeField]
    private Color beadColor;

    [SerializeField]
    private float largeBeadTime = 0.1f;
    [SerializeField]
    private float smallBeadTime = 0.1f;
    [SerializeField]
    private float resetTime = 0.1f;
    [SerializeField]
    private float increment = 0.1f;
    [SerializeField]
    private float deincrement = 0.1f;

    //private float r;
    //private float g;
    //private float b;
    private float a;

    private void Start()
    {
        outline.color = outlineColor;
        StartCoroutine(Fill());
    }

    public void ResetDecade() {
        StopAllCoroutines();
        StartCoroutine(ResetDecadeHelper());
    }

    private IEnumerator ResetDecadeHelper() {
        while(lLargeBead.color.a > 0) {
            ColorReset(lLargeBead, beadColor);
            ColorReset(smallBead1, beadColor);
            ColorReset(smallBead2, beadColor);
            ColorReset(smallBead3, beadColor);
            ColorReset(smallBead4, beadColor);
            ColorReset(smallBead5, beadColor);
            ColorReset(smallBead6, beadColor);
            ColorReset(smallBead7, beadColor);
            ColorReset(smallBead8, beadColor);
            ColorReset(smallBead9, beadColor);
            ColorReset(smallBead10, beadColor);
            ColorReset(rLargeBead, beadColor);
            yield return new WaitForSeconds(resetTime);
        }
        StartCoroutine(Fill());
    }

    private IEnumerator Fill() {
        //r = lLargeBead.color.r;
        //g = lLargeBead.color.g;
        //b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(lLargeBead.color.a < 1) {
            ColorChange(lLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        Debug.Log("Completed lLargeBead");

        //r = smallBead1.color.r;
        //g = smallBead1.color.g;
        //b = smallBead1.color.b;
        a = smallBead1.color.a;

        while(smallBead1.color.a < 1) {
            ColorChange(smallBead1, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead1");

        //r = smallBead2.color.r;
        //g = smallBead2.color.g;
        //b = smallBead2.color.b;
        a = smallBead2.color.a;

        while(smallBead2.color.a < 1) {
            ColorChange(smallBead2, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead2");

        //r = smallbead3.color.r;
        //g = smallbead3.color.g;
        //b = smallbead3.color.b;
        a = smallBead3.color.a;

        while(smallBead3.color.a < 1) {
            ColorChange(smallBead3, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead3");

        //r = smallbead4.color.r;
        //g = smallbead4.color.g;
        //b = smallbead4.color.b;
        a = smallBead4.color.a;

        while(smallBead4.color.a < 1) {
            ColorChange(smallBead4, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead4");

        //r = smallbead5.color.r;
        //g = smallbead5.color.g;
        //b = smallbead5.color.b;
        a = smallBead5.color.a;

        while(smallBead5.color.a < 1) {
            ColorChange(smallBead5, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead5");

        //r = smallbead6.color.r;
        //g = smallbead6.color.g;
        //b = smallbead6.color.b;
        a = smallBead6.color.a;

        while(smallBead6.color.a < 1) {
            ColorChange(smallBead6, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead6");

        //r = smallbead7.color.r;
        //g = smallbead7.color.g;
        //b = smallbead7.color.b;
        a = smallBead7.color.a;

        while(smallBead7.color.a < 1) {
            ColorChange(smallBead7, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead7");

        //r = smallbead8.color.r;
        //g = smallbead8.color.g;
        //b = smallbead8.color.b;
        a = smallBead8.color.a;

        while(smallBead8.color.a < 1) {
            ColorChange(smallBead8, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead8");

        //r = smallbead9.color.r;
        //g = smallbead9.color.g;
        //b = smallbead9.color.b;
        a = smallBead9.color.a;

        while(smallBead9.color.a < 1) {
            ColorChange(smallBead9, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead9");

        //r = smallbead10.color.r;
        //g = smallbead10.color.g;
        //b = smallbead10.color.b;
        a = smallBead10.color.a;

        while(smallBead10.color.a < 1) {
            ColorChange(smallBead10, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed smallBead10");

        //r = rLargeBead.color.r;
        //g = rLargeBead.color.g;
        //b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(rLargeBead.color.a < 1) {
            ColorChange(rLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        Debug.Log("Completed rLargeBead");

        ResetDecade();
    }

    private void ColorChange(Image img, Color col) {
        /*
        if(r < col.r) {
            r += increment;
        } else if(r > col.r) {
            r -= increment;
        }

        if(g < col.g) {
            g += increment;
        } else if(g > col.g) {
            g -= increment;
        }

        if(b < col.b) {
            b += increment;
        } else if(b > col.b) {
            b -= increment;
        }
        */

        a += increment;
        img.color = new Color(col.r, col.g, col.b, a);
    }

    private void ColorReset(Image img, Color col) {
        /*
        if(r < col.r) {
            r += increment;
        } else if(r > col.r) {
            r -= increment;
        }

        if(g < col.g) {
            g += increment;
        } else if(g > col.g) {
            g -= increment;
        }

        if(b < col.b) {
            b += increment;
        } else if(b > col.b) {
            b -= increment;
        }
        */

        a -= deincrement;
        img.color = new Color(col.r, col.g, col.b, a);
    }
}
