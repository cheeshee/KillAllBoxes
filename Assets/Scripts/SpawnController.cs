using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    protected float initialSpawnRate = 10;
    protected float spawnRate;
    protected float lastSpawnedBoxTime;
    protected int boxSpawnNumber = 0;
    private GameObject box;

    // Start is called before the first frame update
    protected void Start()
    {
        spawnRate = initialSpawnRate;
        lastSpawnedBoxTime = Time.time;
        boxSpawnNumber = 0;
    }

    // Update is called once per frame
    protected void Update()
    {

        if (Time.time > lastSpawnedBoxTime + spawnRate)
        {
            if (boxSpawnNumber == 0)
            {
                GameObject box = ObjectPooler.Instance.SpawnFromPool(Pool.NORMAL_BOX, transform.position, Quaternion.identity);
                box.GetComponent<BoxController>().OnObjectSpawn();
                boxSpawnNumber = 1;
            }
            else if (boxSpawnNumber == 1)
            {
                box = ObjectPooler.Instance.SpawnFromPool(Pool.HEAVY_BOX, transform.position, Quaternion.identity);
                box.GetComponent<BoxController>().OnObjectSpawn();
                boxSpawnNumber = 2;
            }
            else if (boxSpawnNumber == 2)
            {
                box = ObjectPooler.Instance.SpawnFromPool(Pool.FRAGILE_BOX, transform.position, Quaternion.identity);
                box.GetComponent<BoxController>().OnObjectSpawn();
                boxSpawnNumber = 0;
            }
            else
            {
                Debug.Log("IM VERY ANGRY SPAWNER");
            }
            //StartCoroutine(SpawnBoxSet());
            // Debug.Log("Spawn!");
            lastSpawnedBoxTime = Time.time;
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
