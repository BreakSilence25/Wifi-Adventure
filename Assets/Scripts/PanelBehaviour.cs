using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviour : MonoBehaviour
{

    public float playerDistance;
    public Vector3 wifiObjectPos;
    public Vector3 playerPos;

    public float connectionThresholdMax = 30f;
    public float connectionThresholdMin = 10f;

    [SerializeField]
    private Sprite[] signalLevels = new Sprite[4];

    [SerializeField]
    private Image spriteHolder;

    bool isAwoke;

    public AudioClip popSound;
    public AudioSource audioSource;

    private void Awake()
    {
        spriteHolder = GetComponentInChildren<Image>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        playerDistance = Vector3.Distance(wifiObjectPos, playerPos);

        if (playerDistance > connectionThresholdMax)
        {
            //gameObject.SetActive(false);
            spriteHolder.sprite = signalLevels[0];
            Destroy(gameObject, 0.5f);
        }
        if (playerDistance < connectionThresholdMax)
        {
            gameObject.SetActive(true);
            //audioSource.PlayOneShot(popSound);
            spriteHolder.sprite = signalLevels[1];
        }
        if (playerDistance < connectionThresholdMax - 500 && playerDistance > connectionThresholdMin)
        {
            spriteHolder.sprite = signalLevels[2];
        }
        if (playerDistance < connectionThresholdMin)
        {
            spriteHolder.sprite = signalLevels[3];
        }
    }
}
