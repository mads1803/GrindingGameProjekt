using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int enemyHealth = 100; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void takeDamage(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth<= 0)
        {

        }
    }
}
