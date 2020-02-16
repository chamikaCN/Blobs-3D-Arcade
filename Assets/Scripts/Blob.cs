using UnityEngine;
using UnityEngine.AI;

public class Blob : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] goals;
    GameObject currentGoal;
    bool playerControlled;
    Vector3 movingDirection;
    public GameObject ball;

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

    public void Attack(){
        Debug.Log("Attacked");
        Instantiate(ball, new Vector3(transform.position.x,transform.position.y+1,
            transform.position.z), Quaternion.identity, this.transform);
    }

    void setMovingDirection(Vector3 direction){
        if(movingDirection != direction){
            movingDirection = direction;
        }
    }

    public Vector3 getMovingDirection(){
        return movingDirection;
    }

    
}
