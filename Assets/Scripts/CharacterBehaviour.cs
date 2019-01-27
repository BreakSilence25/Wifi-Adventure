using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    public float moveSpeed = 0.2f;
    public float rotationSpeed = 0.7f;

    public GameObject characterMeshBoy;
    public GameObject characterMeshGirl;
    public Animator characterAnimatorBoy;
    public Animator characterAnimatorGirl;


    public void Move(Vector3 moveInput)
    {

            transform.Translate(moveInput * moveSpeed);

            if (moveInput != Vector3.zero)
            {

                characterAnimatorBoy.SetBool("isMoving", true);
                characterAnimatorGirl.SetBool("isMoving", true);

            characterMeshBoy.transform.rotation = Quaternion.Slerp(characterMeshBoy.transform.rotation,
                                                  Quaternion.LookRotation(-moveInput, Vector3.up), rotationSpeed);

            characterMeshGirl.transform.rotation = Quaternion.Slerp(characterMeshGirl.transform.rotation,
                                      Quaternion.LookRotation(-moveInput, Vector3.up), rotationSpeed);
            }
        else
            {
                //characterAnimatorBoy.SetBool("isMoving", false);
                characterAnimatorGirl.SetBool("isMoving", false);
            }

    }

    [ContextMenu("fall down")]
    public void Fall()
    {
        characterAnimatorBoy.SetTrigger("isFalling");
        characterAnimatorGirl.SetTrigger("isFalling");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "car")
        {
            Fall();
        }
    }

}
