using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    Rigidbody rigidb;
    public float shootForce = 2000;
    private NavMeshAgent navMeshAgent;
    public float rotationSpeed = 100.0F;

    private void OnEnable()
    {
        rigidb = GetComponent<Rigidbody>();
        rigidb.velocity = Vector3.zero;
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetButton("Fire1")) {
            lookAtMouse();

            navMeshAgent.isStopped = true;
            anim.SetBool("isShooting", true);
            Debug.Log("Skyder");
        }
        else
        {
            anim.SetBool("isShooting", false);
            navMeshAgent.isStopped = false;

        }     
    }


    void ApplyForce()
    {
        rigidb.AddRelativeForce(Vector3.forward * shootForce);
    }

    void SpinObjectInAir()
    {

    }

    void lookAtMouse()
    {
        {
            // Generate a plane that intersects the transform's position with an upwards normal.
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            // Generate a ray from the cursor position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Determine the point where the cursor ray intersects the plane.
            // This will be the point that the object must look towards to be looking at the mouse.
            // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
            //   then find the point along that ray that meets that distance.  This will be the point
            //   to look at.
            float hitdist = 0.0f;
            // If the ray is parallel to the plane, Raycast will return false.
            if (playerPlane.Raycast(ray, out hitdist))
            {
                // Get the point along the ray that hits the calculated distance.
                Vector3 targetPoint = ray.GetPoint(hitdist);

                // Determine the target rotation.  This is the rotation if the transform looks at the target point.
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
