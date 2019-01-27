using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiBehaviour : MonoBehaviour
{

    public Vector3 objectPosition;
    public string objectName;

    public float distanceToPlayer;

    private Transform player;

    private float maxThreshold = 1000f;

    PanelBehaviour mySpot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        gameObject.name = objectName;
        objectPosition = transform.position;

        mySpot = GameObject.Find(gameObject.name + "(Clone)").GetComponent<PanelBehaviour>();

    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
    }



}
