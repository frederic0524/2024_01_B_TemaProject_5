using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 250f;
    public float attackRange = 2.5f;
    public int attackDamage = 25;
    public float attackCooldown = 1.5f;

    private CharacterController controller;
    private float lastAttackTime;

    public Animator animator;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        lastAttackTime = -attackCooldown;
    }

   



    void Update()
    {
        float speed = rb.velocity.magnitude;
        animator.SetFloat("Speed", speed);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -transform.forward * moveSpeed;
        }
        else
        {
            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
            }
        }

        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        Debug.Log("Player attacked!");
        lastAttackTime = Time.time;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }

    public void IncreaseMoveSpeed(float additionalSpeed)
    {
        moveSpeed += additionalSpeed;
        Debug.Log($"New move speed: {moveSpeed}");
    }
}