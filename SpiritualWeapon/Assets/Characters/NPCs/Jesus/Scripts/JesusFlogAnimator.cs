using UnityEngine;

public class JesusFlogAnimator : MonoBehaviour
{
    [SerializeField] private GameObject JesusObject = null;
    private Animator JesusAnim;

    private void Start() {
        //Get The Animator
        JesusAnim = JesusObject.GetComponent<Animator>(); 
    }
    
    // event for when Jesus is flogged by Roman
    private void JesusFloggedAnimEvent() {
        JesusAnim.SetTrigger("flogged");
    }
}
