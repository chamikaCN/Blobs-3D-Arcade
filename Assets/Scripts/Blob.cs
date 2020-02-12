using UnityEngine;
using UnityEngine.AI;

public class Blob : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] goals;
    GameObject currentGoal;
    bool playerControlled;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        playerControlled = false;
        goals = GameObject.FindGameObjectsWithTag("Goal");
        RoamToNext();

    }

    void Update()
    {
        if (!playerControlled)
        {
            Roam();
        }
    }

    public void setPlayerControl(){
        playerControlled = true;
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        agent.isStopped = true;
        Debug.Log("cat");
    }

    public void ResetPlayerControl(){
        agent.isStopped = false;
        RoamToNext();
        playerControlled = false;
    }

    void Roam(){
        if (Vector3.Distance(transform.position, currentGoal.transform.position) < 3)
        {
            RoamToNext();
        }
    }

    void RoamToNext()
    {
        currentGoal = goals[Random.Range(0, goals.Length)];
        agent.SetDestination(currentGoal.transform.position);
    }

    public void ChangeTest(){
        Debug.Log("changed to " + transform.name);
    }

    public void ManualMovement(Vector3 target){
        agent.isStopped = false;
        agent.SetDestination(target);
        agent.stoppingDistance = 0f;
    }

    
}
