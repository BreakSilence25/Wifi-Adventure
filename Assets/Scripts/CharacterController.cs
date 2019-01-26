using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float moveSpeed = 0.2f;

    public void Move(Vector3 moveInput)
    {
        transform.Translate(moveInput * moveSpeed);
    }


}
