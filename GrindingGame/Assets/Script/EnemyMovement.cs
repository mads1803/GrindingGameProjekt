using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    private Transform _player;
    Animator _animator;
    public Animation anim;

    void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        //TODO: Finde animation done statement
        if (!_animator.GetBool("IsNearPlayer") && !_animator.GetBool("IsDead"))
        {
             if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack"))
             {
                _nav.SetDestination(_player.position);
                _animator.SetBool("running", true);
            }
               

           
        }
        

    }
}