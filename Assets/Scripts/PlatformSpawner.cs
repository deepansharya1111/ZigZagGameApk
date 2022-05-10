using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;  
    Vector3 lastPos;
    float size;
    public bool gameOver;


    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i <10 ; i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms",1f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatforms()
    {
        if(gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
        int rand = Random.Range(0,10);
        if(rand<3)
        {
            spawnX();
        }
        else if(rand >= 3)
        {
            spawnZ();
        }
    }

    void spawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y +1, pos.z), diamonds.transform.rotation);
        }

         

    }

    void spawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1, pos.z) , diamonds.transform.rotation);
        }
    }
}
