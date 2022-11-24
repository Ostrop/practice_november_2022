using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed;
    GameObject destroyPoint;

    GameObject generatorPoint;
    public float step;
    private float progress;
    private float progresstonull;
    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("DestroyPoint");
        generatorPoint = GameObject.Find("GeneratorPoint");
        transform.position = generatorPoint.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(generatorPoint.transform.position, destroyPoint.transform.position, progress);
        progress += step;
        if (transform.position.x == destroyPoint.transform.position.x)
        {
            this.transform.position = generatorPoint.transform.position;
            progress = progresstonull;
        }
    }

    void Update()
    {
    }
}
