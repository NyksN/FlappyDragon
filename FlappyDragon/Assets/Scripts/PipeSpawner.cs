using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxSecond = 1.5f;
    public float heightRnage = 0.5f,timer;
    public GameObject[] pipes;
    int randomInt;
    void Start()
    {
        PipeSpawn();
        
    }

    
    void Update()
    {
        maxSecond = Random.Range(2.4f, 3.2f);
        if (timer >maxSecond)
        {
            PipeSpawn();
            timer = 0;
        }
        timer += Time.deltaTime;
        randomInt = Random.Range(0, pipes.Length);

    }

    private void PipeSpawn()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRnage, +heightRnage));
        GameObject pipe = Instantiate(pipes[randomInt] ,spawnPos, Quaternion.identity);

        Destroy(pipe, 8f);
    }
}
