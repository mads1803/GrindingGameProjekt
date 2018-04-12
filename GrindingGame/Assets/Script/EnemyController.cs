using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public int enemyHealth = 100;
    Animator _animator;
    AudioSource audio;
    public AudioClip audioDie;
    public AudioClip audioDamage;
    public AudioClip audioIdle;
    bool dead = false;
    Collider m_Collider;
    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        m_Collider = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Arrow")
        {
            takeDamage(10);
            Debug.Log("10 skade");
        }
    }

    void takeDamage(int damage)
    {
        if (!dead) { 
        enemyHealth -= damage;
        audio.loop = false;
        audio.clip = audioDamage;
        audio.Play();


            if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                dead = true;
                _animator.SetBool("IsDead", true);
                Destroy(gameObject, 60);
                audio.loop = false;
                audio.clip = audioDie;
                audio.Play();
                m_Collider.enabled = false;

            }
        }

    }
}
