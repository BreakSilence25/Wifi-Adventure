using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    public Transform path;
    [SerializeField]
    private List<Transform> nodes;
    private int currentNode = 0;

    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();

        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckWaypoint();
        MoveToWaypoint(nodes[currentNode].transform);
    }

    void MoveToWaypoint(Transform currentWaypoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, Time.deltaTime * 900);
        transform.LookAt(currentWaypoint.position, Vector3.up);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(currentWaypoint.position, Vector3.up), Time.deltaTime);

    }

    void CheckWaypoint()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 50f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }

        print(currentNode);
    }


}
