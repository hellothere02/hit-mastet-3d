using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckEnemiesOnScene))]
public class Dying : MonoBehaviour
{
    Rigidbody[] rbs;
    private CheckEnemiesOnScene checkEnemies;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        checkEnemies = GetComponent<CheckEnemiesOnScene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            foreach (var item in rbs)
            {
                item.isKinematic = false;
            }
            this.GetComponent<Animator>().enabled = false;
            this.gameObject.tag = "dead";
            checkEnemies.Check();
        }
    }
}
