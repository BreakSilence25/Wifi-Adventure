using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{

    public CharacterController characterController;

    private float v;
    private float h;

    [SerializeField]
    private Vector3 touchStartPosition;
    [SerializeField]
    private Vector3 touchDragPosition;

    void Update()
    {
        MoveInput();
#if UNITY_IOS
        TouchInput();
#endif
    }

    void MoveInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPosition = Input.mousePosition;
            //Debug.Log("MousePos: " + touchStartPosition);
        }

        if (Input.GetMouseButton(0))
        {
            touchDragPosition = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0))
        {
            touchStartPosition = Vector3.zero;
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchDragPosition = Vector3.zero;
        }

        //float touchDirX = (touchDragPosition.x - touchStartPosition.x);
        //float touchDirY = (touchDragPosition.y - touchStartPosition.y);
        //Debug.Log(touchDirX);

        Vector3 touchDir = new Vector3(touchDragPosition.x - touchStartPosition.x, 0, touchDragPosition.y - touchStartPosition.y).normalized;

        characterController.Move(touchDir);

    }
#if UNITY_IOS
    void TouchInput()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;

                Debug.Log("touch input at:" + touchStartPosition);
            }
        }
    }
#endif
}
