using UnityEngine;

public class SpeechManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("General Audio Clips/Text")]
    [SerializeField] private AudioClip[] ourFatherClips = null;
    private AudioClip[] fatherTempClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string ourFatherText;
    [SerializeField] private AudioClip[] hailMaryClips = null;
    private AudioClip[] maryTempClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string hailMaryText;
    [SerializeField] private AudioClip[] gloryBeClips = null;
    private AudioClip[] gloryTempClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string gloryBeText;
    [SerializeField] private AudioClip[] fatimaClips = null;
    private AudioClip[] fatimaTempClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string fatimaText;

    [Header("Start Audio Clips/Text")]
    [SerializeField] private AudioClip crossStartClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string crossStartText;
    [SerializeField] private AudioClip creedClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string creedText;
    [SerializeField] private AudioClip intentionsClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string intentionsText;
    [SerializeField] private AudioClip faithClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string faithText;
    [SerializeField] private AudioClip hopeClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string hopeText;
    [SerializeField] private AudioClip loveClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string loveText;

    [Header("Mystery Audio Clips")]
    [SerializeField] private AudioClip[] mysteryClips = null;

    [Header("End Audio Clips/Text")]
    [SerializeField] private AudioClip reginaClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string reginaText;
    [SerializeField] private AudioClip godClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string godText;
    [SerializeField] private AudioClip memorareClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string memorareText;
    [SerializeField] private AudioClip michaelClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string michaelText;
    [SerializeField] private AudioClip heartClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string heartText;
    [SerializeField] private AudioClip crossEndClip = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string crossEndText;

    private GameManager gameManager = null;
    private StartAndEndRosaryFill startAndEndRosaryScript = null;
    private MysteryRosaryFill mysteryRosaryScript = null;

    private AudioClip[] currentClips = null;
    private string[] currentText = null;

    private int startingMystery = 0;
    private int endingMystery = 19;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() {
        Setup();
    }

    private void Setup() {
        fatherTempClips = new AudioClip[ourFatherClips.Length];
        CopyArray(ourFatherClips, fatherTempClips);
        maryTempClips = new AudioClip[hailMaryClips.Length];
        CopyArray(hailMaryClips, maryTempClips);
        gloryTempClips = new AudioClip[gloryBeClips.Length];
        CopyArray(gloryBeClips, gloryTempClips);
        fatimaTempClips = new AudioClip[fatimaClips.Length];
        CopyArray(fatimaClips, fatimaTempClips);

        PlayerPrefs.SetInt("HitCount", 0);
    }

    public void StartRosary() {
        StartRosaryHelper();
    }
    private void StartRosaryHelper() {
        currentClips = new AudioClip[6];
        currentText = new string[6];

        currentClips[0] = crossStartClip;
        currentClips[1] = creedClip;
        currentClips[2] = intentionsClip;
        currentClips[3] = faithClip;
        currentClips[4] = hopeClip;
        currentClips[5] = loveClip;

        currentText[0] = crossStartText;
        currentText[1] = creedText;
        currentText[2] = intentionsText;
        currentText[3] = faithText;
        currentText[4] = hopeText;
        currentText[5] = loveText;

        startAndEndRosaryScript = GameObject.FindGameObjectWithTag("StartAndEndRosary").GetComponent<StartAndEndRosaryFill>();
        startAndEndRosaryScript.Fill();
    }

    public void EndRosary() {
        EndRosaryHelper();
    }
    private void EndRosaryHelper() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.ToEndRosary();

        currentClips = new AudioClip[6];
        currentText = new string[6];

        currentClips[0] = reginaClip;
        currentClips[1] = godClip;
        currentClips[2] = memorareClip;
        currentClips[3] = michaelClip;
        currentClips[4] = heartClip;
        currentClips[5] = crossEndClip;

        currentText[0] = reginaText;
        currentText[1] = godText;
        currentText[2] = memorareText;
        currentText[3] = michaelText;
        currentText[4] = heartText;
        currentText[5] = crossEndText;

        startAndEndRosaryScript = GameObject.FindGameObjectWithTag("StartAndEndRosary").GetComponent<StartAndEndRosaryFill>();
        startAndEndRosaryScript.Fill();
    }

    public void Mysteries(int starting) {
        MysteriesHelper(starting);
    }
    private void MysteriesHelper(int starting) {
        startingMystery = starting;
        FillCurrentClips(mysteryClips[startingMystery]);

        mysteryRosaryScript = GameObject.FindGameObjectWithTag("MysteryRosary").GetComponent<MysteryRosaryFill>();
        mysteryRosaryScript.Fill();
    }

    public void StartNextPrayer(int prayer) {
        StartNextPrayerHelper(prayer);
    }
    private void StartNextPrayerHelper(int prayer) {
        Debug.Log("Current Clip Playing: " + currentClips[prayer]);
        audioSource.clip = currentClips[prayer];
        audioSource.Play();
    }

    private void FillCurrentClips(AudioClip sceneClip) {
        currentClips = new AudioClip[14];
        currentText = new string[14];

        currentClips[0] = sceneClip;
        currentText[0] = "";

        SetCurrentClip(1, ourFatherClips, fatherTempClips);
        currentText[1] = ourFatherText;

        for(int i = 2; i < 12; i++) {
            SetCurrentClip(i, hailMaryClips, maryTempClips);
            currentText[i] = hailMaryText;
        }

        SetCurrentClip(12, gloryBeClips, gloryTempClips);
        currentText[12] = gloryBeText;

        SetCurrentClip(13, fatimaClips, fatimaTempClips);
        currentText[13] = fatimaText;
    }

    private void SetCurrentClip(int currentIndex, AudioClip[] clipsToSet, AudioClip[] tempClips) {
        if(clipsToSet.Length == 0) {
            clipsToSet = new AudioClip[tempClips.Length];
            CopyArray(tempClips,  clipsToSet);
        }

        int random = 0;
        do{
            random = Random.Range(0, clipsToSet.Length - 1);
        } while(clipsToSet[random] == null);

        currentClips[currentIndex] = clipsToSet[random];
        clipsToSet[random] = null;

        AudioClip[] temp = new AudioClip[clipsToSet.Length - 1];
        CopyArraySkipNull(clipsToSet, temp);

        clipsToSet = temp;
    }

    private void CopyArray(AudioClip[] arrayToCopy, AudioClip[] copiedArray) {
        for(int i = 0; i < copiedArray.Length; i++) {
            copiedArray[i] = arrayToCopy[i];
        }
    }

    private void CopyArraySkipNull(AudioClip[] arrayToCopy, AudioClip[] copiedArray) {
        for(int i = 0; i < copiedArray.Length; i++) {
            if(arrayToCopy[i] != null) {
                copiedArray[i] = arrayToCopy[i];
            } else {
                int random = 0;
                do {
                    random = Random.Range(0, arrayToCopy.Length - 1);
                } while(random != i);
                copiedArray[i] = arrayToCopy[random];
            }
        }
    }

    public void PauseVocals() {
        PauseVocalsHelper();
    }
    private void PauseVocalsHelper() {
        audioSource.Pause();
    }

    public void PlayVocals() {
        PlayVocalsHelper();
    }
    private void PlayVocalsHelper() {
        audioSource.Play();
    }

    public int GetStartingMystery() {
        return GetStartingMysteryHelper();
    }
    private int GetStartingMysteryHelper() {
        return startingMystery;
    }
    public int GetEndingMystery() {
        return GetEndingMysteryHelper();
    }
    private int GetEndingMysteryHelper() {
        return endingMystery;
    }

    public void SetEndingMystery(int ending) {
        SetEndingMysteryHelper(ending);
    }
    private void SetEndingMysteryHelper(int ending) {
        endingMystery = ending;
    }

    public string StartScrollingText(int text) {
        return StartScrollingTextHelper(text);
    }
    private string StartScrollingTextHelper(int text) {
        Debug.Log("Current Text Printing: " + currentText[text]);
        return currentText[text];
    }
}
