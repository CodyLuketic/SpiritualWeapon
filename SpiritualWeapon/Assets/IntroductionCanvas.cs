using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionCanvas : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameManager gameManager = null;

    [SerializeField] private RawImage background = null;
    [SerializeField] private Color backgroundDarkColor;

    [SerializeField] private CanvasGroup title = null;

    [SerializeField] private CanvasGroup[] slides = null;

   /* [SerializeField] private CanvasGroup stDominic = null;

    [SerializeField] private CanvasGroup jesusNativity = null;

    [SerializeField] private CanvasGroup jesusEuch = null;

    [SerializeField] private CanvasGroup jesusCrux = null;

    [SerializeField] private CanvasGroup jesusAscend = null;*/

    private Coroutine runningCoroutine = null;

    [Header("Fade Values")]
    [SerializeField] private float increment = 0.001f;
    private float a = 0, aBackground = 1, r = 1, g = 1, b = 1;
    private bool changed = false, backgroundChanged = false, pass1 = false, pass2 = false, pass3 = false, pass4 = false;
    private int currentSlide=0;

    [Header("Fade Times")]
    [SerializeField] private float titleTime = .01f;

    [SerializeField] private float slideTime = .01f;

    /*[SerializeField] private float stDominicTime = .01f;

    [SerializeField] private float jesusNativityTime = .01f;

    [SerializeField] private float jesusEuchTime = .01f;

    [SerializeField] private float jesusCruxTime = .01f;

    [SerializeField] private float jesusAscendTime = .01f;*/

    private void Start() {
        runningCoroutine = StartCoroutine(RunTitleAndSlideI());
    }
    private IEnumerator RunTitleAndSlideI() {
        a = 0;

        while(!changed) {
            Fade(title, true);
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        a = 1;

        while(!changed || !backgroundChanged) {
            Fade(title, false);
            IncrementColor(background, backgroundDarkColor);
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        a = 0;

        while(!changed) {
            Fade(slides[currentSlide], true);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        runningCoroutine = null;
    }

    public void RunNextSlide() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(RunNextSlideHelper());
        }
    }
    private IEnumerator RunNextSlideHelper() {
        a = 1;

        while(!changed) {
            Fade(slides[currentSlide], false);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        slides[currentSlide].gameObject.SetActive(false);
        currentSlide += 1;
        slides[currentSlide].gameObject.SetActive(true);

        a = 0;

        while (!changed)
        {
                Fade(slides[currentSlide], true);
                yield return new WaitForSeconds(slideTime);
        }
        
        changed = false;

        runningCoroutine = null;
    }

   /* public void RunJesusNativity() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(RunJesusNativityHelper());
        }
    }
    private IEnumerator RunJesusNativityHelper() {
        a = 1;

        while(!changed) {
            Fade(slides[1], false);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        slides[1].gameObject.SetActive(false);
        slides[2].gameObject.SetActive(true);

        a = 0;

        while(!changed) {
            Fade(slides[2], true);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        runningCoroutine = null;
    }

    public void RunJesusEuch() {
        if(runningCoroutine == null) {
           runningCoroutine = StartCoroutine(RunJesusEuchHelper());
        }
    }
    private IEnumerator RunJesusEuchHelper() {
        a = 1;

        while(!changed) {
            Fade(jesusNativity, false);
            yield return new WaitForSeconds(jesusNativityTime);
        }
        changed = false;

        jesusNativity.gameObject.SetActive(false);
        jesusEuch.gameObject.SetActive(true);

        a = 0;

        while(!changed) {
            Fade(jesusEuch, true);
            yield return new WaitForSeconds(jesusEuchTime);
        }
        changed = false;

        runningCoroutine = null;
    }

    public void RunJesusCrux() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(RunJesusCruxHelper());
        }
    }
    private IEnumerator RunJesusCruxHelper() {
        a = 1;

        while(!changed) {
            Fade(jesusEuch, false);
            yield return new WaitForSeconds(jesusEuchTime);
        }
        changed = false;

        jesusEuch.gameObject.SetActive(false);
        jesusCrux.gameObject.SetActive(true);

        a = 0;

        while(!changed) {
            Fade(jesusCrux, true);
            yield return new WaitForSeconds(jesusCruxTime);
        }
        changed = false;

        runningCoroutine = null;
    }

    public void RunJesusAscend() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(RunJesusAscendHelper());
        }
    }
    private IEnumerator RunJesusAscendHelper() {
        a = 1;

        while(!changed) {
            Fade(jesusCrux, false);
            yield return new WaitForSeconds(jesusCruxTime);
        }
        changed = false;

        jesusCrux.gameObject.SetActive(false);
        jesusAscend.gameObject.SetActive(true);

        a = 0;

        while(!changed) {
            Fade(jesusAscend, true);
            yield return new WaitForSeconds(jesusAscendTime);
        }
        changed = false;

        runningCoroutine = null;
    }*/

    public void EndIntroduction() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(EndIntroductionHelper());
        }
    }
    private IEnumerator EndIntroductionHelper() {
        a = 1;

        while(!changed) {
            Fade(slides[currentSlide], false);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        slides[currentSlide].gameObject.SetActive(false);

        gameManager.ToStartRosary();
    }

    private void Fade(CanvasGroup section, bool fadeUp) {
        if(fadeUp && a < 0.995) {
            a += increment;
        } else if(!fadeUp && a > 0.005) {
            a -= increment;
        } else {
            changed = true;

            if(fadeUp) {   
                a = 1;
            } else {
                a = 0;
            }
        }

        section.alpha = a;
    }

    private void IncrementColor(RawImage img, Color col) {
        pass1 = false;
        pass2 = false;
        pass3 = false;
        pass4 = false;

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

        if(aBackground < col.a - 0.05) {
            aBackground += increment;
        } else if(aBackground > col.a + 0.05) {
            aBackground -= increment;
        } else {
            pass4 = true;
        }

        if(pass1 && pass2 && pass3 && pass4) {
            backgroundChanged = true;

            r = col.r;
            g = col.g;
            b = col.b;
            aBackground = col.a;
        }

        img.color = new Color(r, g, b, aBackground);
    }
}
