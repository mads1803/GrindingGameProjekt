using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    Animator _animator;
    GameObject _player;
    public Animation anim;


    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = GetComponent<Animator>();
        anim = GetComponent<Animation>();

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("IsNearPlayer", false);

        }
    }

}