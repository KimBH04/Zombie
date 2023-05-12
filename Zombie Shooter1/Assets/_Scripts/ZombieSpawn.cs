using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [Range(.0f, 10.0f)]
    public float aTime = 10.0f;
    public GameObject zombie;

    public float min;
    private float pTime;

    private void Start()
    {
        min = 0.9f;
        transform.position = new Vector2(Random.Range(-5.0f, 5.0f), 5.0f);
        Instantiate(zombie, transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        aTime -= Time.deltaTime / 10.0f;
        pTime += Time.deltaTime;
        if (pTime > Mathf.Clamp(aTime, min,10.0f))
        {
            transform.position = new Vector2(Random.Range(-5.0f, 5.0f), 5.0f);
            pTime = 0.0f;
            Instantiate(zombie, transform.position, Quaternion.identity);
        }
    }
}
