using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    
    private void Awake()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.transform.position.y + Random.Range(-5, 5), 0);    
    }
    private void Update()
    {
        if(this.transform.position.x <= -9)
        {
            Refresh();
        }
        this.transform.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
    }

    private void Refresh()
    {
        this.transform.position = new Vector3(35, Random.Range(-5, 5), 0);
    }

    private void FixedUpdate()
    {
        
    }
}
