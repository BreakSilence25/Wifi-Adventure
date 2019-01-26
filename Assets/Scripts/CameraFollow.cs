using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform followObject;
    [SerializeField]
    private Vector2 followObjectPos;

    public Vector3 viewportPosition;

    public Vector3 offset;
    [SerializeField]
    private float damping = 2f;

    private float boundMaxY = 0.7f;
    private float boundMinY = 0.3f;
    private float boundMaxX = 0.7f;
    private float boundMinX = 0.3f;


    public bool isEdge = false;

    void Start()
    {
        followObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        viewportPosition = Camera.main.WorldToViewportPoint(followObject.position);
        followObjectPos = new Vector2(followObject.position.x, followObject.position.y);
        isEdgeCheck();

        if (isEdge)
        {
            Vector3 targetPosition = followObject.position + offset;
            Vector3 lerpedPosition = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
            transform.position = lerpedPosition;
        }
        else
        {
            return;
        }

    }

    void isEdgeCheck()
    {
        if (viewportPosition.x < boundMinX || viewportPosition.x > boundMaxX ||
            viewportPosition.y < boundMinY || viewportPosition.y > boundMaxY)
        {
            isEdge = true;
        }
        else if (viewportPosition.x > boundMinX || viewportPosition.x < boundMaxX ||
                 viewportPosition.y > boundMinY || viewportPosition.y < boundMaxY)
        {
            isEdge = false;
        }
    }
}
