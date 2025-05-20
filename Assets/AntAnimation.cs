using UnityEngine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class AntAnimation : MonoBehaviour
{
    private Animator        _anim;
    private NavMeshAgent    _agent;
    private EnemyAttack     _attack;
    private EnemyHealth     _health;
    private bool            _isDead;

    void Awake()
    {
        _anim  = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _attack = GetComponent<EnemyAttack>();
        _health = GetComponent<EnemyHealth>();
    }

    void OnEnable()
    {
        if (_attack != null)
            _attack.OnAttack += HandleAttack;
        if (_health != null)
            _health.OnDeath  += HandleDeath;
    }

    void OnDisable()
    {
        if (_attack != null)
            _attack.OnAttack -= HandleAttack;
        if (_health != null)
            _health.OnDeath  -= HandleDeath;
    }

    void Update()
    {
        if (_isDead) return;

        // Walking animation
        bool walking = _agent.velocity.sqrMagnitude > 0.1f;
        _anim.SetBool("isWalking", walking);
    }

    public void HandleAttack()
    {
        // Attack animation
        _anim.SetTrigger("Attack");
    }

    private void HandleDeath()
    {
        _isDead = true;
        _anim.SetTrigger("Die");

        // stop moving/collisions
        _agent.isStopped = true;
        var col = GetComponent<Collider>();
        if (col) col.enabled = false;

        // queue destroy after death clip length
        float delay = GetDeathClipLength();
        Destroy(gameObject, delay);
    }

    private float GetDeathClipLength()
    {
        // find the clip named "Death" on the runtime controller
        foreach (var clip in _anim.runtimeAnimatorController.animationClips)
            if (clip.name == "Death")
                return clip.length;
        // fallback
        return 1f;
    }
}
