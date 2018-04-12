using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    Animator _animator;
    GameObject _player;
    public Animation anim;


    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
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
        Debug.Log("Trigger enter");
        if (other.gameObject == _player)
        {
            //navMeshAgent.destination = navMeshAgent.transform.position;
            _animator.SetBool("running", false);
            _animator.SetBool("IsNearPlayer", true);
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            Debug.Log("Trigger exit");
            _animator.SetBool("IsNearPlayer", false);

        }
    }


}