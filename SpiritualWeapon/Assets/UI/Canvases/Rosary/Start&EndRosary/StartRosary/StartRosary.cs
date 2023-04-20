using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartRosary : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private bool skipSpeeches = false;

    [Header("Scripts")]
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private MusicManager musicManager = null;
    [SerializeField] private EnemySpawner enemySpawner = null;
    [SerializeField] private float spawnEnemiesDelay = 1f;
    private SpeechManager speechManager = null;

    [Header("Images")]
    [SerializeField] private Image cross = null;
    [SerializeField] private Image lLargeBead = null;
    [SerializeField] private Image lSmallBead = null;
    [SerializeField] private Image mSmallBead = null;
    [SerializeField] private Image rSmallBead = null;
    [SerializeField] private Image rLargeBead = null;

    [Header("Color")]
    [SerializeField] private Color completedColor;
    private float r = 0, g = 0, b = 0, a = 0;

    [Header("Fill Speeds")]
    [SerializeField] private float signOfTheCrossTime = 5f;
    [SerializeField] private float apostlesCreedTime = 0.1f;
    [SerializeField] private float intentionsTime = 5f;
    [SerializeField] private float ourFatherTime = 0.1f;
    [SerializeField] private float faithTime = 0.1f;
    [SerializeField] private float hopeTime = 0.1f;
    [SerializeField] private float loveTime = 0.1f;
    [SerializeField] private float gloryBeTime = 0.1f;

    [SerializeField] private float increment = 0.1f;

    [Header("Scrolling Text Values")]
    [SerializeField] private TMP_Text textBox = null;
    [SerializeField] private GameObject fadeOut = null;

    [SerializeField] private float signOfTheCrossTextSpeed = 0.1f;
    [SerializeField] private float apostlesCreedTextSpeed = 0.1f;
    [SerializeField] private float intentionsTextSpeed = 0.1f;
    [SerializeField] private float ourFatherTextSpeed = 0.1f;
    [SerializeField] private float faithTextSpeed = 0.1f;
    [SerializeField] private float hopeTextSpeed = 0.1f;
    [SerializeField] private float loveTextSpeed = 0.1f;
    [SerializeField] private float gloryBeTextSpeed = 0.1f;
   
    [SerializeField] private int maxStringLength = 10;

    private string currentText = null;
    private Coroutine textCoroutine = null;

    private bool changed = false;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Fill() {
        StopAllCoroutines();

        if(!skipSpeeches) {
            StartCoroutine(FillHelper());
        } else {
            StartCoroutine(SkipFill());
        }
    }
    private IEnumerator FillHelper() {
        StartCoroutine(SpawnEnemiesDelay());

        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();
        speechManager.StartNextPrayer(0);
        currentText = speechManager.StartScrollingText(0);

        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(signOfTheCrossTextSpeed));

        yield return new WaitForSeconds(signOfTheCrossTime);

        speechManager.StartNextPrayer(1);
        currentText = speechManager.StartScrollingText(1);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(apostlesCreedTextSpeed));

        r = cross.color.r;
        g = cross.color.g;
        b = cross.color.b;
        a = cross.color.a;

        while(!changed) {
            IncrementColor(cross, completedColor);
            yield return new WaitForSeconds(apostlesCreedTime);
        }
        changed = false;

        speechManager.StartNextPrayer(2);
        currentText = speechManager.StartScrollingText(2);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(intentionsTextSpeed));

        yield return new WaitForSeconds(intentionsTime);

        speechManager.StartNextPrayer(3);
        currentText = speechManager.StartScrollingText(3);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(ourFatherTextSpeed));

        r = lLargeBead.color.r;
        g = lLargeBead.color.g;
        b = lLargeBead.color.b;
        a = lLargeBead.color.a;

        while(!changed) {
            IncrementColor(lLargeBead, completedColor);
            yield return new WaitForSeconds(ourFatherTime);
        }
        changed = false;

        speechManager.StartNextPrayer(4);
        currentText = speechManager.StartScrollingText(4);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(faithTextSpeed));

        r = lSmallBead.color.r;
        g = lSmallBead.color.g;
        b = lSmallBead.color.b;
        a = lSmallBead.color.a;

        while(!changed) {
            IncrementColor(lSmallBead, completedColor);
            yield return new WaitForSeconds(faithTime);
        }
        changed = false;

        speechManager.StartNextPrayer(5);
        currentText = speechManager.StartScrollingText(5);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(hopeTextSpeed));

        r = mSmallBead.color.r;
        g = mSmallBead.color.g;
        b = mSmallBead.color.b;
        a = mSmallBead.color.a;

        while(!changed) {
            IncrementColor(mSmallBead, completedColor);
            yield return new WaitForSeconds(hopeTime);
        }
        changed = false;

        speechManager.StartNextPrayer(6);
        currentText = speechManager.StartScrollingText(6);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(loveTextSpeed));

        r = rSmallBead.color.r;
        g = rSmallBead.color.g;
        b = rSmallBead.color.b;
        a = rSmallBead.color.a;

        while(!changed) {
            IncrementColor(rSmallBead, completedColor);
            yield return new WaitForSeconds(loveTime);
        }
        changed = false;

        speechManager.StartNextPrayer(5);
        currentText = speechManager.StartScrollingText(5);

        StopCoroutine(textCoroutine);
        fadeOut.SetActive(false);
        textCoroutine = StartCoroutine(Scroll(gloryBeTextSpeed));

        r = rLargeBead.color.r;
        g = rLargeBead.color.g;
        b = rLargeBead.color.b;
        a = rLargeBead.color.a;

        musicManager.AudioFadeOut();

        while(!changed) {
            IncrementColor(rLargeBead, completedColor);
            yield return new WaitForSeconds(gloryBeTime);
        }
        changed = false;

        CheckNextScene();
    }

    private IEnumerator SkipFill() {
        speechManager = GameObject.FindGameObjectWithTag("SpeechManager").GetComponent<SpeechManager>();

        yield return new WaitForSeconds(0.1f);

        CheckNextScene();
    }

    private void CheckNextScene() {
        int nextScene = PlayerPrefs.GetInt("Decades");
        int endingMystery = 19;

        switch(nextScene) {
            case 0:
                speechManager.SetEndingMystery(endingMystery);

                gameManager.ToJoyfulMysteries();
                break;
            case 1:
                endingMystery = 4;
                speechManager.SetEndingMystery(endingMystery);

                gameManager.ToJoyfulMysteries();
                break;
            case 2:
                endingMystery = 9;
                speechManager.SetEndingMystery(endingMystery);

                gameManager.ToLuminousMysteries();
                break;
            case 3:
                endingMystery = 14;
                speechManager.SetEndingMystery(endingMystery);

                gameManager.ToSorrowfulMysteries();
                break;
            case 4:
                speechManager.SetEndingMystery(endingMystery);

                gameManager.ToGloriusMysteries();
                break;
            default:
                Debug.Log("Error");
                break;
        }
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

    private IEnumerator Scroll(float textSpeed) {
        currentText = currentText.Replace("\r", "");

        for (int i = 0, j = 0; i < currentText.Length + 1; i++) {
            textBox.text = currentText.Substring(j, i - j);

            if(textBox.text.Length > maxStringLength) {
                fadeOut.SetActive(true);
                j++;
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private IEnumerator SpawnEnemiesDelay() {
        yield return new WaitForSeconds(spawnEnemiesDelay);

        if(enemySpawner != null) {
            enemySpawner.enabled = true;
        }
    }
}
