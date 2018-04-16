using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    Animator _animator;
    GameObject _player;
    public Animation anim;

    //Swrod collider evt
    GameObject sword;
    Collider sword_collider;

    GameObject druidHand;
    Collider hand_collider;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();

        sword = GameObject.FindGameObjectWithTag("AssassinWeapon");
        sword_collider = sword.GetComponent<Collider>();
        sword_collider.enabled = false;

        druidHand = GameObject.FindGameObjectWithTag("DruideWeapon");
        hand_collider = druidHand.GetComponent<Collider>();
        hand_collider.enabled = false;

    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //if (_animator.GetBool("IsNearPlayer"))
            //transform.LookAt(_player.transform.position);
    
}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enemy Trigger enter");
        if (other.gameObject == _player)
        {
            //navMeshAgent.destination = navMeshAgent.transform.position;
            _animator.SetBool("running", false);
         
            _animator.SetBool("IsNearPlayer", true);

           if(!_animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack") && other.gameObject.tag == ("Player"))
            {
                sword_collider.enabled = true;
                hand_collider.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            Debug.Log("Enemy Trigger exit");
            _animator.SetBool("IsNearPlayer", false);
           

        }
    }


}