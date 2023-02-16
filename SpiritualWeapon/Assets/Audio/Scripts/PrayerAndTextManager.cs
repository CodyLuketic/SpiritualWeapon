using System.Collections;
using UnityEngine;

public class PrayerAndTextManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private AudioSource audioSource = null;

    [Header("General Audio Clips/Text")]
    [SerializeField] private AudioClip[] ourFatherClips = null;
    private AudioClip[] fatherTempClips = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] ourFatherText;
    [SerializeField] private AudioClip[] hailMaryClips = null;
    private AudioClip[] maryTempClips = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] hailMaryText;
    [SerializeField] private AudioClip[] gloryBeClips = null;
    private AudioClip[] gloryTempClips = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] gloryBeText;

    [Header("Start Audio Clips/Text")]
    [SerializeField] private AudioClip crossStartClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] crossStartText;
    [SerializeField] private AudioClip creedClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] creedText;
    [SerializeField] private AudioClip intentionsClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] intentionsText;
    [SerializeField] private AudioClip faithClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] faithText;
    [SerializeField] private AudioClip hopeClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] hopeText;
    [SerializeField] private AudioClip loveClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] loveText;

    [Header("Joyful Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip annunciationClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] annunciationText;
    [SerializeField] private AudioClip visitationClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] visitationText;
    [SerializeField] private AudioClip birthClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] birthText;
    [SerializeField] private AudioClip presentationClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] presentationText;
    [SerializeField] private AudioClip templeClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] templeText;

    [Header("Luminous Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip baptismClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] baptismText;
    [SerializeField] private AudioClip canaClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] canaText;
    [SerializeField] private AudioClip kingdomClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] kingdomText;
    [SerializeField] private AudioClip transfigurationClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] transfigurationText;
    [SerializeField] private AudioClip eucharistClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] eucharistText;

    [Header("Sorrowful Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip gardenClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] gardenText;
    [SerializeField] private AudioClip pillarClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] pillarText;
    [SerializeField] private AudioClip thornClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] thornText;
    [SerializeField] private AudioClip carryingClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] carryingText;
    [SerializeField] private AudioClip crucifixionClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] crucifixionText;

    [Header("Glorious Mystery Audio Clips/Text")]
    [SerializeField] private AudioClip resurrectionClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] resurrectionText;
    [SerializeField] private AudioClip anscensionClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] anscensionText;
    [SerializeField] private AudioClip spiritClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] spiritText;
    [SerializeField] private AudioClip assumptionClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] assumptionText;
    [SerializeField] private AudioClip coronationClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] coronationText;

    [Header("End Audio Clips/Text")]
    [SerializeField] private AudioClip reginaClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] reginaText;
    [SerializeField] private AudioClip godClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] godText;
    [SerializeField] private AudioClip memorareClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] memorareText;
    [SerializeField] private AudioClip michaelClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] michaelText;
    [SerializeField] private AudioClip heartClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] heartText;
    [SerializeField] private AudioClip crossEndClip = null;
    [TextArea(minLines: 1, maxLines: 6)] [SerializeField] private string[] crossEndText;

    private AudioClip[] currentClips = new AudioClip[13];

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start() {
        CopyArray(ourFatherClips, fatherTempClips);
        CopyArray(hailMaryClips, maryTempClips);
        CopyArray(gloryBeClips, gloryTempClips);

        FillCurrentClips(annunciationClip);

        StartCoroutine(Speech());
    }

    private void FillCurrentClips(AudioClip sceneClip) {
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

        AudioClip[] temp = null;
        CopyArray(clipsToSet, temp);

        clipsToSet = new AudioClip[clipsToSet.Length - 1];
        CopyArraySkipNull(temp, clipsToSet);
    }

    private IEnumerator Speech() {
        for(int i = 0; i < currentClips.Length; i++) {
            audioSource.clip = currentClips[i];
            audioSource.Play();
            yield return new WaitForSeconds(currentClips[i].length);
        }
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
