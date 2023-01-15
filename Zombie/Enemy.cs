using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private Health health;
    private Health targetHealth;
    private Player player;
    public Animator animator;
    private Collider collider;
    public bool isDead = false;
    public bool isAttacking = false;
    public float speed = 1.0f;
    public float angularSpeed = 120f;
    public float damage = 20;


    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.Find("Player");
        target.GetComponent<Health>();
        player=GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        animator=GetComponent<Animator>();
        collider=GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        Chase();
        CheckAttack();
    }

    void CheckHealth()
    {
    if(health.health<=0)
    {
        isDead=true;
        animator.CrossFadeInFixedTime("Death",0.1f);
        agent.isStopped=true;
        collider.enabled=false;
        Destroy(gameObject,3f);
    }
    }

    void Chase()
    {
        if(isDead)return;
         else if(player.isDead)return;
        agent.destination =target.transform.position; 
    }
    void CheckAttack() {
		if(isDead)return;
        else if(isAttacking)return;
        else if(player.isDead)return;
		float distanceFromTarget = Vector3.Distance(target.transform.position,transform.position);

		if(!isAttacking && distanceFromTarget <= 2.0f) {
			Attack();
		}
	}
    void ResetAttacking()
    {
        isAttacking=false;
        agent.speed=speed;
        agent.angularSpeed= angularSpeed;
    }

    void Attack()
    {
        Health targetHealth= target.GetComponent<Health>();
        targetHealth.TakeDamage(damage);
            agent.speed = 0;
            agent.angularSpeed=0;
            isAttacking=true;
			animator.SetTrigger("ShouldAttack");
			Invoke("ResetAttacking",2f);
    }
}
