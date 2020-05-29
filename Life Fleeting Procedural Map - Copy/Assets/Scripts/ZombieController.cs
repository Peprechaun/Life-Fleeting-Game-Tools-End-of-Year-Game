using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    private enum State 
    {
        //Roaming,
        Investigating,
        ChaseTarget,
    }

    //public Camera cam;
    public NavMeshAgent agent;
    private State state;
    private float shotNoise = 15f;

    

    //public float radius;
    //public float timer;

    //private Transform target;
    //private float currentTimer;
    

    private void Awake()
    {
        state = State.Investigating;
        
    }

    
    private void Update()
    {
        

        switch (state)
        {
            default:
            

            case State.Investigating:

                if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < shotNoise)
                {   
                    agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
                }

                FindTarget();
                break;
            case State.ChaseTarget:
                agent.SetDestination(GameObject.FindWithTag("Player").transform.position);

                
                break;
            

        }


    }

    private void FindTarget()
    {
        float targetRange = 6f;
        float enemyDistance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        if (enemyDistance < targetRange)
        {
            state = State.ChaseTarget;
            

        }
        

    }

    

}
