using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    Rigidbody rigidb;
    private NavMeshAgent navMeshAgent;
    public float rotationSpeed = 100.0F;
    public Rigidbody arrow;
    public Transform arrowPoint;
    public float arrowSpeed;
    
    

    private void OnEnable()
    {
        rigidb = GetComponent<Rigidbody>();
        rigidb.velocity = Vector3.zero;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim.SetBool("isDead", false);
    }
	
	// Update is called once per frame
	void Update () {
        StopAndAttack();
        
    }

   

    void StopAndAttack()
    {
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        {
            lookAtMouse();
            //navMeshAgent.isStopped = true;
            navMeshAgent.destination = navMeshAgent.transform.position;
            anim.SetBool("isShooting", true);
         
                
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }


    void Shoot ()
    {                   
                Rigidbody arrowInstance = Instantiate(arrow, arrowPoint.transform.position, arrowPoint.transform.rotation);
                arrowInstance.velocity = transform.TransformDirection(Vector3.forward * arrowSpeed);        
    }

    void lookAtMouse()
    {
        {
         
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
