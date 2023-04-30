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

    private Coroutine runningCoroutine = null;

    [Header("Title Values")]
    [SerializeField] private float titleTime = .01f;
    [SerializeField] private float titleIncrement = 0.001f;
    [SerializeField] private float backgroundIncrement = 0.001f;

    [Header("Slide Values")]
    [SerializeField] private float slideTime = .01f;
    [SerializeField] private float slideIncrement = 0.001f;

    
    private float a = 0, aBackground = 1, r = 1, g = 1, b = 1;
    private bool changed = false, backgroundChanged = false, pass1 = false, pass2 = false, pass3 = false, pass4 = false;
    private int currentSlide = 0;

    private void Start() {
        runningCoroutine = StartCoroutine(RunTitleAndSlide());
    }

    private IEnumerator RunTitleAndSlide() {
        a = 0;

        while(!changed) {
            Fade(title, true, titleIncrement);
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        a = 1;

        while(!changed || !backgroundChanged) {
            Fade(title, false, titleIncrement);
            IncrementColor(background, backgroundDarkColor, backgroundIncrement);
            yield return new WaitForSeconds(titleTime);
        }
        changed = false;

        a = 0;

        while(!changed) {
            Fade(slides[currentSlide], true, slideIncrement);
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
            Fade(slides[currentSlide], false, slideIncrement);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        slides[currentSlide].gameObject.SetActive(false);
        currentSlide += 1;
        slides[currentSlide].gameObject.SetActive(true);

        a = 0;

        while(!changed) {
            Fade(slides[currentSlide], true, slideIncrement);
            yield return new WaitForSeconds(slideTime);
        }
        
        changed = false;

        runningCoroutine = null;
    }

    public void EndIntroduction() {
        if(runningCoroutine == null) {
            runningCoroutine = StartCoroutine(EndIntroductionHelper());
        }
    }
    private IEnumerator EndIntroductionHelper() {
        a = 1;

        while(!changed) {
            Fade(slides[currentSlide], false, slideIncrement);
            yield return new WaitForSeconds(slideTime);
        }
        changed = false;

        slides[currentSlide].gameObject.SetActive(false);

        gameManager.ToStartRosary();
    }

    private void Fade(CanvasGroup section, bool fadeUp, float increment) {
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

    private void IncrementColor(RawImage img, Color col, float increment) {
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
