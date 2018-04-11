using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class ClickToMove : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent navMeshAgent;
    private bool mRunnging = false;



    private void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }

    void move()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift) && !anim.GetBool("isDead") && !Input.GetButton("Fire2") && !anim.GetBool("showingChest"))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;               
            }
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            mRunnging = false;

        }

        else
        {
            mRunnging = true;
        }

        anim.SetBool("running", mRunnging);
    }


    


}
