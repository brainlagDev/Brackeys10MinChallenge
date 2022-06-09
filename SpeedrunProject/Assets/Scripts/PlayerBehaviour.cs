using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 100f;
    [SerializeField] private float _gravity = -25f;
    [SerializeField] UnityEvent OnPipePassEvent;
    [SerializeField] UnityEvent OnGameOverEvent;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, _gravity);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale < 1)
            {
                Time.timeScale = 1;
            }
            Jump();
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipe"))
        {
            Debug.Log("Invoke");
            OnPipePassEvent?.Invoke();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Time.timeScale = 0;
            OnGameOverEvent?.Invoke();
        }
    }
}
