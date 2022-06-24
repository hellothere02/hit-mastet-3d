using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float force;

    private void Update()
    {
        Destroy(this.gameObject, 2);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
