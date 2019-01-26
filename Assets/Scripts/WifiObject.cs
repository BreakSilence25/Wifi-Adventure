using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiObject : MonoBehaviour
{

    public Vector3 objectPosition;
    public string objectName;

    void Start()
    {
        objectPosition = transform.position;
    }



}
