using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryArrowByTime : MonoBehaviour {

    public float lifeTime;
    private Rigidbody arrow;
    private Collider arrowCollider;
    public float arrowDmg;
    private EnemyController enemyController;
    private PlayerInventory playerController;
    public GameObject player;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        arrow = GetComponent<Rigidbody>();
        arrowCollider = GetComponent<Collider>();
        // playerController = GetComponent<PlayerInventory>().tag("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        arrowDmg += player.GetComponent<PlayerInventory>().maxDamage;
        //playerController.currentDamage;
        Debug.Log(arrowDmg);
        Debug.Log(player.GetComponent<PlayerInventory>().maxDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "Arrow") && !(other.gameObject.tag == "Player")) { 
            arrow.constraints = RigidbodyConstraints.FreezeAll;
            arrowCollider.enabled = false;
        }

        if (other.gameObject.tag == "Enemy")
        {
            // other.gameObject.SendMessage("ApplyDmg", arrowDmg);
            
            enemyController = other.gameObject.GetComponent<EnemyController>();
            enemyController.takeDamage(arrowDmg);
          
            Destroy(gameObject);
        }
            
       
    }
}
