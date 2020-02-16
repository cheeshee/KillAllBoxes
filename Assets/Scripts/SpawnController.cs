using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    protected float initialSpawnRate = 10;
    protected float spawnRate;
    protected float lastSpawnedBoxTime;


    // Start is called before the first frame update
    protected void Start()
    {
        spawnRate = initialSpawnRate;
        lastSpawnedBoxTime = Time.time;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (Time.time > lastSpawnedBoxTime + spawnRate)
        {
            StartCoroutine(SpawnBoxSet());
        }
    }

    IEnumerator SpawnBoxSet()
    {
        GameObject box = ObjectPooler.Instance.SpawnFromPool(Pool.NORMAL_BOX, transform.position, Quaternion.identity);
        box.GetComponent<BoxController>().OnObjectSpawn();
        yield return new WaitForSeconds(10 * (1f / 60f));

        box = ObjectPooler.Instance.SpawnFromPool(Pool.HEAVY_BOX, transform.position, Quaternion.identity);
        box.GetComponent<BoxController>().OnObjectSpawn();
        yield return new WaitForSeconds(10 * (1f / 60f));


        box = ObjectPooler.Instance.SpawnFromPool(Pool.FRAGILE_BOX, transform.position, Quaternion.identity);
        box.GetComponent<BoxController>().OnObjectSpawn();

    }



}
