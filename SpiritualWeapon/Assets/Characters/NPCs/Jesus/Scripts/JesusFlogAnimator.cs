using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesusFlogAnimator : MonoBehaviour
{
    [SerializeField] private GameObject JesusObject = null;
    private Animator JesusAnim;

    // Start is called before the first frame update
    void Start()
    {
        //Get The Animator
        JesusAnim = JesusObject.GetComponent<Animator>(); 
    }
    
    // event for when Jesus is flogged by Roman
    public void JesusFloggedAnimEvent()
    {
        JesusAnim.SetTrigger("flogged");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
