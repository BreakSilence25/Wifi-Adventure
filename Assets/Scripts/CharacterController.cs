using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 0.2f;
    public float rotationSpeed = 0.7f;

    public GameObject characterMesh;
    public Animator characterAnimator;

    public void Move(Vector3 moveInput)
    {
        transform.Translate(moveInput * moveSpeed);
        if (moveInput != Vector3.zero)
        {

            characterAnimator.SetBool("isMoving", true);

            characterMesh.transform.rotation = Quaternion.Slerp(characterMesh.transform.rotation, 
                                               Quaternion.LookRotation(-moveInput, Vector3.up), rotationSpeed);
        }
        else
        {
            characterAnimator.SetBool("isMoving", false);
        }
    }

    public void Fall()
    {
        characterAnimator.SetBool("isFalling", true);
    }


}
