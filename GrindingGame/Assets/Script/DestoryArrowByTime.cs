using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryArrowByTime : MonoBehaviour {

    public float lifeTime;
    private Rigidbody arrow;
    private Collider arrowCollider;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        arrow = GetComponent<Rigidbody>();
        arrowCollider = GetComponent<Collider>();
        //arrow2 = GetComponent<Collider>();
        //colliderToIgnore = GameObject.Find("Player/Aroow").GetComponent<Collider>();
    }

    private void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!(collision.gameObject.tag == "Arrow") && !(collision.gameObject.tag == "Player"))
    //        arrow.constraints = RigidbodyConstraints.FreezeAll;
    //    //arrow.isKinematic = true;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "Arrow") && !(other.gameObject.tag == "Player")) { 
            arrow.constraints = RigidbodyConstraints.FreezeAll;
            arrowCollider.enabled = false;
        }

        if (other.gameObject.tag == "Enemy")
            Destroy(gameObject);
    }
}
