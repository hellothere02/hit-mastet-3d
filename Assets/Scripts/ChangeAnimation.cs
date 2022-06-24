using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class ChangeAnimation : MonoBehaviour
{
    private Animator anim;
    private CharacterController characterController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController.Agent.remainingDistance > 0.2f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
