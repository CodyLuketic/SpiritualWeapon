using System.Collections;
using UnityEngine;

public class PrayerAndTextManager : MonoBehaviour
{
    [Header("Scripts")]
    private StartingPrayerFill startingPrayerScript = null;
    private DecadePrayerFill decadePrayerScript = null;

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

    [Header("Joyful Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip annunciationClip = null;
    [SerializeField] private AudioClip visitationClip = null;
    [SerializeField] private AudioClip nativityClip = null;
    [SerializeField] private AudioClip presentationClip = null;
    [SerializeField] private AudioClip templeClip = null;

    [Header("Luminous Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip baptismClip = null;
    [SerializeField] private AudioClip weddingClip = null;
    [SerializeField] private AudioClip kingdomClip = null;
    [SerializeField] private AudioClip transfigurationClip = null;
    [SerializeField] private AudioClip eucharistClip = null;

    [Header("Sorrowful Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip gardenClip = null;
    [SerializeField] private AudioClip pillarClip = null;
    [SerializeField] private AudioClip thornsClip = null;
    [SerializeField] private AudioClip carryingClip = null;
    [SerializeField] private AudioClip crucifixionClip = null;

    [Header("Glorious Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip resurrectionClip = null;
    [SerializeField] private AudioClip ascensionClip = null;
    [SerializeField] private AudioClip pentacostClip = null;
    [SerializeField] private AudioClip assumptionClip = null;
    [SerializeField] private AudioClip coronationClip = null;

    private AudioClip[] mysteries = null;

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

    private AudioClip[] currentClips = null;
    private int currentMystery = 0;
    private int endingMystery = 0;
    private bool canContinue = false;

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

        mysteries = new AudioClip[] { annunciationClip, visitationClip, nativityClip,
            presentationClip, templeClip, baptismClip, weddingClip, kingdomClip,
            transfigurationClip, eucharistClip, gardenClip, pillarClip, thornsClip,
            carryingClip, crucifixionClip, resurrectionClip, ascensionClip, pentacostClip,
            assumptionClip, coronationClip };
    }

    public void StartingPrayers() {
        StartingPrayersHelper();
    }
    private void StartingPrayersHelper() {
        currentClips = new AudioClip[13];

        currentClips[0] = crossStartClip;
        currentClips[1] = creedClip;
        currentClips[2] = intentionsClip;
        currentClips[3] = faithClip;
        currentClips[4] = hopeClip;
        currentClips[5] = loveClip;

        canContinue = false;

        startingPrayerScript = GameObject.FindGameObjectWithTag("StartingPrayers").GetComponent<StartingPrayerFill>();
        StartCoroutine(Speech(startingPrayerScript));
    }

    public void EndingPrayers() {
        EndingPrayersHelper();
    }
    private void EndingPrayersHelper() {
        currentClips = new AudioClip[13];

        currentClips[0] = reginaClip;
        currentClips[1] = godClip;
        currentClips[2] = memorareClip;
        currentClips[3] = michaelClip;
        currentClips[4] = heartClip;
        currentClips[5] = crossEndClip;

        startingPrayerScript = GameObject.FindGameObjectWithTag("StartingPrayers").GetComponent<StartingPrayerFill>();
        StartCoroutine(Speech(startingPrayerScript));
    }

    public void MysteriesPrayer(int startingPrayer, int endingPrayer) {
        MysteriesPrayerInitial(startingPrayer, endingPrayer);
    }
    private void MysteriesPrayerInitial(int startingPrayer, int endingPrayer) {
        decadePrayerScript = GameObject.FindGameObjectWithTag("DecadePrayers").GetComponent<DecadePrayerFill>();

        currentMystery = startingPrayer;
        endingMystery = endingPrayer;

        MysteriesPrayerContinuous();
    }
    private void MysteriesPrayerContinuous() {
        if(currentMystery == endingMystery) {
            EndingPrayersHelper();
        }

        FillCurrentClips(mysteries[currentMystery]);

        StartCoroutine(Speech(decadePrayerScript));
    }

    private void FillCurrentClips(AudioClip sceneClip) {
        currentClips = new AudioClip[13];

        currentClips[0] = sceneClip;

        SetCurrentClip(1, ourFatherClips, fatherTempClips);
        for(int i = 2; i < 12; i++) {
            SetCurrentClip(i, hailMaryClips, maryTempClips);
        }
        SetCurrentClip(12, gloryBeClips, gloryTempClips);
    }

    private void SetCurrentClip(int currentIndex, AudioClip[] clipsToSet, AudioClip[] tempClips) {
        if(clipsToSet.Length == 0) {
            clipsToSet = new AudioClip[tempClips.Length];
            CopyArray(tempClips,  clipsToSet);
        }

        int random = Random.Range(0, clipsToSet.Length - 1);

        currentClips[currentIndex] = clipsToSet[random];
        clipsToSet[random] = null;

        AudioClip[] temp = new AudioClip[clipsToSet.Length - 1];
        CopyArraySkipNull(clipsToSet, temp);

        clipsToSet = temp;
    }

    private IEnumerator Speech(StartingPrayerFill script) {
        script.Fill();

        for(int i = 0; i < currentClips.Length; i++) {
            audioSource.clip = currentClips[i];
            audioSource.Play();
            script.SetWaitTime(currentClips[i].length);
            yield return new WaitForSeconds(currentClips[i].length);
        }

        MysteriesPrayerInitial(0, -1);
    }

    private IEnumerator Speech(DecadePrayerFill script) {
        script.Fill();

        for(int i = 0; i < currentClips.Length; i++) {
            audioSource.clip = currentClips[i];
            audioSource.Play();
            script.SetWaitTime(currentClips[i].length);
            yield return new WaitForSeconds(currentClips[i].length);
        }

        currentMystery++;
        MysteriesPrayerContinuous();
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
                copiedArray[i] = arrayToCopy[copiedArray.Length];
            }
        }
    }
}
