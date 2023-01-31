using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartingPrayerFill : MonoBehaviour
{
    [SerializeField]
    private Image cross = null;
    [SerializeField]
    private Image outline = null;
    [SerializeField]
    private Image lLargeBead = null;
    [SerializeField]
    private Image lSmallBead = null;
    [SerializeField]
    private Image mSmallBead = null;
    [SerializeField]
    private Image rSmallBead = null;
    [SerializeField]
    private Image rLargeBead = null;

    [SerializeField]
    private Color crossColor;
    [SerializeField]
    private Color outlineColor;
    [SerializeField]
    private Color beadColor;

    [SerializeField]
    private float crossTime = 0.1f;
    [SerializeField]
    private float largeBeadTime = 0.1f;
    [SerializeField]
    private float smallBeadTime = 0.1f;
    [SerializeField]
    private float increment = 0.1f;

    //private float r;
    //private float g;
    //private float b;
    private float a;

    private void Start()
    {
        outline.color = outlineColor;
        StartCoroutine(Fill());
    }

    private IEnumerator Fill() {
        //r = cross.color.r;
        //g = cross.color.g;
        //b = cross.color.b;
        a = cross.color.a;

        while(cross.color.a < 1) {
            ColorChange(cross, crossColor);
            yield return new WaitForSeconds(crossTime);
        }

        Debug.Log("Completed cross");

        //r = lLargeBead.color.r;
        //g = lLargeBead.color.g;
        //b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(lLargeBead.color.a < 1) {
            ColorChange(lLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        Debug.Log("Completed lLargeBead");

        //r = lSmallBead.color.r;
        //g = lSmallBead.color.g;
        //b = lSmallBead.color.b;
        a = lSmallBead.color.a;

        while(lSmallBead.color.a < 1) {
            ColorChange(lSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed lSmallBead");

        //r = mSmallBead.color.r;
        //g = mSmallBead.color.g;
        //b = mSmallBead.color.b;
        a = mSmallBead.color.a;

        while(mSmallBead.color.a < 1) {
            ColorChange(mSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed mSmallBead");

        //r = rSmallBead.color.r;
        //g = rSmallBead.color.g;
        //b = rSmallBead.color.b;
        a = rSmallBead.color.a;

        while(rSmallBead.color.a < 1) {
            ColorChange(rSmallBead, beadColor);
            yield return new WaitForSeconds(smallBeadTime);
        }

        Debug.Log("Completed rSmallBead");

        //r = rLargeBead.color.r;
        //g = rLargeBead.color.g;
        //b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        while(rLargeBead.color.a < 1) {
            ColorChange(rLargeBead, beadColor);
            yield return new WaitForSeconds(largeBeadTime);
        }

        Debug.Log("Completed rLargeBead");
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
}
