using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public Transform generatorPoint;
    public float distanceBetween;
    public float distanceMin, distanceMax;
    

    int platformSelector;
    float[] platformsWidth;

    public PlatformManager[] platformsM;

    float minHeight, maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    float heightChange;

    // Start is called before the first frame update per frame
    void Start()
    {
        // platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
        platformsWidth = new float[platformsM.Length];
        for (int i = 0; i < platformsM.Length; i++)
        {
            platformsWidth[i] = platformsM[i].platform.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generatorPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            platformSelector = Random.Range(0, platformsM.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
                heightChange = maxHeight;
            else if (heightChange < minHeight)
                heightChange = minHeight;
            transform.position = new Vector3(transform.position.x + platformsWidth[platformSelector] + distanceBetween, heightChange, transform.position.z);


            GameObject newPlatform = platformsM[platformSelector].GetPlatform();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
