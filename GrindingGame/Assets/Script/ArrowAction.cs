using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAction : MonoBehaviour {
    public Rigidbody arrow;
    public Transform arrowPoint;
    public float arrowSpeed;


    public void Update()
    {
        // check for Fire1 input and instantiate bullet prefab at bulletPoint                     
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody bulletInstance = Instantiate(arrow, arrowPoint.transform.position, arrowPoint.transform.rotation);
            bulletInstance.velocity = transform.TransformDirection(Vector3.up * arrowSpeed);
        }
    }
}
