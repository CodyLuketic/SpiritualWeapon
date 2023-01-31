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
    private Color outlineColor, beadColor, completedColor;

    [SerializeField]
    private float outlineTime = 0.1f, largeBeadTime = 0.1f, smallBeadTime = 0.1f, resetTime = 0.1f,
        increment = 0.1f, deincrement = 0.1f;

    //private float r, g, b;
    private float a;

    //private bool ended = false;

    public void OutlineFill() {
        StartCoroutine(OutlineFillHelper());
    }
    private IEnumerator OutlineFillHelper() {
        outline.color = outlineColor;
        
        //r = cross.color.r;
        //g = cross.color.g;
        //b = cross.color.b;
        a = outline.color.a;

        while(outline.color.a < 0.8) {
            ColorChange(outline, outlineColor);
            yield return new WaitForSeconds(outlineTime);
        }
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
    }

    public void Fill() {
        StartCoroutine(ResetDecadeHelper());
    }

    private IEnumerator FillHelper() {
        //r = lLargeBead.color.r;
        //g = lLargeBead.color.g;
        //b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(lLargeBead.color.a < 1) {
            ColorChange(lLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        lLargeBead.color = completedColor;
        Debug.Log("Completed lLargeBead");

        //r = smallBead1.color.r;
        //g = smallBead1.color.g;
        //b = smallBead1.color.b;
        a = smallBead1.color.a;

        while(smallBead1.color.a < 1) {
            ColorChange(smallBead1, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead1.color = completedColor;
        Debug.Log("Completed smallBead1");

        //r = smallBead2.color.r;
        //g = smallBead2.color.g;
        //b = smallBead2.color.b;
        a = smallBead2.color.a;

        while(smallBead2.color.a < 1) {
            ColorChange(smallBead2, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead2.color = completedColor;
        Debug.Log("Completed smallBead2");

        //r = smallbead3.color.r;
        //g = smallbead3.color.g;
        //b = smallbead3.color.b;
        a = smallBead3.color.a;

        while(smallBead3.color.a < 1) {
            ColorChange(smallBead3, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead3.color = completedColor;
        Debug.Log("Completed smallBead3");

        //r = smallbead4.color.r;
        //g = smallbead4.color.g;
        //b = smallbead4.color.b;
        a = smallBead4.color.a;

        while(smallBead4.color.a < 1) {
            ColorChange(smallBead4, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead4.color = completedColor;
        Debug.Log("Completed smallBead4");

        //r = smallbead5.color.r;
        //g = smallbead5.color.g;
        //b = smallbead5.color.b;
        a = smallBead5.color.a;

        while(smallBead5.color.a < 1) {
            ColorChange(smallBead5, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead5.color = completedColor;
        Debug.Log("Completed smallBead5");

        //r = smallbead6.color.r;
        //g = smallbead6.color.g;
        //b = smallbead6.color.b;
        a = smallBead6.color.a;

        while(smallBead6.color.a < 1) {
            ColorChange(smallBead6, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead6.color = completedColor;
        Debug.Log("Completed smallBead6");

        //r = smallbead7.color.r;
        //g = smallbead7.color.g;
        //b = smallbead7.color.b;
        a = smallBead7.color.a;

        while(smallBead7.color.a < 1) {
            ColorChange(smallBead7, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead7.color = completedColor;
        Debug.Log("Completed smallBead7");

        //r = smallbead8.color.r;
        //g = smallbead8.color.g;
        //b = smallbead8.color.b;
        a = smallBead8.color.a;

        while(smallBead8.color.a < 1) {
            ColorChange(smallBead8, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead8.color = completedColor;
        Debug.Log("Completed smallBead8");

        //r = smallbead9.color.r;
        //g = smallbead9.color.g;
        //b = smallbead9.color.b;
        a = smallBead9.color.a;

        while(smallBead9.color.a < 1) {
            ColorChange(smallBead9, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead9.color = completedColor;
        Debug.Log("Completed smallBead9");

        //r = smallbead10.color.r;
        //g = smallbead10.color.g;
        //b = smallbead10.color.b;
        a = smallBead10.color.a;

        while(smallBead10.color.a < 1) {
            ColorChange(smallBead10, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        smallBead10.color = completedColor;
        Debug.Log("Completed smallBead10");

        //r = rLargeBead.color.r;
        //g = rLargeBead.color.g;
        //b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(rLargeBead.color.a < 1) {
            ColorChange(rLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        rLargeBead.color = completedColor;
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
