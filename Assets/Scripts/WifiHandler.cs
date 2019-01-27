using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiHandler : MonoBehaviour
{

    private GameObject[] wifiObjects = new GameObject[3];
    private GameObject[] closeSignals;
    private Transform player;

    public float minDistanceThreshold = 10f;
    public float maxDistanceThreshold = 30f;

    [SerializeField]
    private GameObject hotspotUIPrefab;
    [SerializeField]
    private GameObject wifiPanel;

    public List<string> foundSignals;

    int index = 0;

    void AddHotspot(string signalName, Vector3 signalPosition)
    {
        //hotspotUIPrefab.name = signalName;
        hotspotUIPrefab.GetComponentInChildren<Text>().text = signalName;
        hotspotUIPrefab.name = signalName;
        hotspotUIPrefab.GetComponent<PanelBehaviour>().wifiObjectPos = signalPosition;
        Instantiate(hotspotUIPrefab, wifiPanel.transform);
        index++;
    }

    void RemoveHotspot(string signalName)
    {
        if (foundSignals.Contains(signalName))
        {
            Debug.Log("Removing " + signalName.ToString());
            foundSignals.Remove(signalName);
            index -= 1;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        wifiObjects = GameObject.FindGameObjectsWithTag("wifi");

        if (index <= wifiObjects.Length)
        {
            {
                foreach (GameObject wifiObject in wifiObjects)
                {
                    if (Vector3.Distance(wifiObject.transform.position, player.position) < maxDistanceThreshold)
                    {
                        if (!foundSignals.Contains(wifiObject.GetComponent<WifiBehaviour>().objectName))
                        {
                            Debug.Log(wifiObject.name);
                            AddHotspot(wifiObject.GetComponent<WifiBehaviour>().objectName, wifiObject.transform.position);
                            foundSignals.Add(wifiObject.GetComponent<WifiBehaviour>().objectName);
                        }
                    }
                    if (Vector3.Distance(wifiObject.transform.position, player.position) > maxDistanceThreshold)
                    {
                        if (foundSignals.Contains(wifiObject.GetComponent<WifiBehaviour>().objectName))
                        {
                            RemoveHotspot(wifiObject.GetComponent<WifiBehaviour>().objectName);
                        }
                    }
                }
            }
        }
        else
        {
            return;
        }
    }
}
