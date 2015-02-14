using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public Transform[] eggPrefabs;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;
 	
	void Update () {
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
            nextEggTime = Time.time + spawnRate;

            //Speed up the spawnrate for the next egg
//            spawnRate *= 0.98f;
//            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
        }
	}

    void SpawnEgg()
    {
        float addXPos = Random.Range(-1.6f, 1.6f);
        Vector3 spawnPos = transform.position + new Vector3(addXPos,0,0);
        int index = Random.Range(0, 3);
        Instantiate(eggPrefabs[index], spawnPos, Quaternion.identity);
    }
}
