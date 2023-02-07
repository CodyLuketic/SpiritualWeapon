using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent agent= null;
    
    private Transform player;
    
    private void Start() {
        agent= gameObject.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate() {
        FollowMelee();
    }

    private void FollowMelee() {
        if(agent.enabled == true) {
            agent.SetDestination(player.position);
        }
    }
}
