using UnityEngine;

public class SpeechManager : MonoBehaviour
{
    [Header("Debug")]
    [SerializeField] private int endingMystery = 19;

    [Header("Components")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("General Audio Clips/Text")]
    [SerializeField] private AudioClip[] ourFatherClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string ourFatherText;
    [SerializeField] private AudioClip[] hailMaryClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string hailMaryText;
    [SerializeField] private AudioClip[] gloryBeClips = null;
    [TextArea(minLines: 1, maxLines: 12)] [SerializeField] private string gloryBeText;
    [SerializeField] private AudioClip[] fatimaClips = null;
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

    private StartRosary startRosaryScript = null;
    private EndRosary endRosaryScript = null;
    private MysteryRosaryFill mysteryRosaryScript = null;

    private AudioClip[] currentClips = null;
    private string[] currentText = null;

    private int startingMystery = 0;
    private int random = 0;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() {
        Setup();
    }

    private void Setup() {
        PlayerPrefs.SetInt("HitCount", 0);
    }

    public void StartRosary() {
        StartRosaryHelper();
    }
    private void StartRosaryHelper() {
        currentClips = new AudioClip[8];
        currentText = new string[8];

        currentClips[0] = crossStartClip;
        currentClips[1] = creedClip;
        currentClips[2] = intentionsClip;
        random = Random.Range(0, ourFatherClips.Length - 1);
        currentClips[3] = ourFatherClips[random];
        currentClips[4] = faithClip;
        currentClips[5] = hopeClip;
        currentClips[6] = loveClip;
        random = Random.Range(0, ourFatherClips.Length - 1);
        currentClips[7] = gloryBeClips[random];

        currentText[0] = crossStartText;
        currentText[1] = creedText;
        currentText[2] = intentionsText;
        currentText[3] = ourFatherText;
        currentText[4] = faithText;
        currentText[5] = hopeText;
        currentText[6] = loveText;
        currentText[7] = ourFatherText;

        startRosaryScript = GameObject.FindGameObjectWithTag("StartRosary").GetComponent<StartRosary>();
        startRosaryScript.Fill();
    }

    public void EndRosary() {
        EndRosaryHelper();
    }
    private void EndRosaryHelper() {
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

        endRosaryScript = GameObject.FindGameObjectWithTag("EndRosary").GetComponent<EndRosary>();
        endRosaryScript.Fill();
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
        SetVolume(1);
        StartNextPrayerHelper(prayer);
    }
    private void StartNextPrayerHelper(int prayer) {
        audioSource.clip = currentClips[prayer];
        audioSource.Play();
    }

    private void FillCurrentClips(AudioClip sceneClip) {
        currentClips = new AudioClip[14];
        currentText = new string[14];

        currentClips[0] = sceneClip;
        currentText[0] = "";

        RandomClip(1, ourFatherClips);
        currentText[1] = ourFatherText;

        for(int i = 2; i < 12; i++) {
            RandomClip(i, hailMaryClips);
            currentText[i] = hailMaryText;
        }

        RandomClip(12, gloryBeClips);
        currentText[12] = gloryBeText;

        RandomClip(13, fatimaClips);
        currentText[13] = fatimaText;
    }

    private void RandomClip(int currentIndex, AudioClip[] clipsToSet) {
        random = 0;
        do{
            random = Random.Range(0, clipsToSet.Length - 1);
        } while(clipsToSet[random] == null);

        currentClips[currentIndex] = clipsToSet[random];
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
        return currentText[text];
    }

    public void ResetAll() {
        ResetAllHelper();
    }
    private void ResetAllHelper() {
        audioSource.Stop();

        Setup();
    }

    public void SetVolume(float _volume) {
        SetVolumeHelper(_volume);
    }
    private void SetVolumeHelper(float _volume) {
        audioSource.volume = _volume;
    }
}
