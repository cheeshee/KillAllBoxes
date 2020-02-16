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
    private List<int> boxList;
    private int bombBox;
    private BoxController boxComponent;
    private int boxCount;

// Start is called before the first frame update
    protected void Start()
    {
        spawnRate = initialSpawnRate;
        lastSpawnedBoxTime = Time.time;
        boxSpawnNumber = 0;
        boxCount = 0;
        generateNewList();
    }

    // Update is called once per frame
    protected void Update()
    {

        if (Time.time > lastSpawnedBoxTime + spawnRate)
        {
            if (boxList[boxSpawnNumber] % 3 == 0)
            {
                box = ObjectPooler.Instance.SpawnFromPool(Pool.NORMAL_BOX, transform.position, Quaternion.identity);
            }
            else if (boxList[boxSpawnNumber] % 3 == 1)
            {
                box = ObjectPooler.Instance.SpawnFromPool(Pool.HEAVY_BOX, transform.position, Quaternion.identity);
 
            }
            else if (boxList[boxSpawnNumber] % 3 == 2)
            {
                box = ObjectPooler.Instance.SpawnFromPool(Pool.FRAGILE_BOX, transform.position, Quaternion.identity);
                
            }
            else
            {
                Debug.Log("IM VERY ANGRY SPAWNER");
            }

            boxComponent = box.GetComponent<BoxController>();
            boxComponent.OnObjectSpawn();

            if (boxSpawnNumber == bombBox)
            {
                boxComponent.isSafe = false;
            }

            boxSpawnNumber++;
            if (boxSpawnNumber >= 9)
            {
                generateNewList();
                boxSpawnNumber = 0;
            }

            boxCount++;

            lastSpawnedBoxTime = Time.time;
        }
    }



    public void decrementBoxes()
    {
        boxCount--;
    }


    private void generateNewList()
    {
        boxList = Fisher_Yates_CardDeck_Shuffle();
        bombBox = Random.Range(0, 9);
    }




    public static List<int> Fisher_Yates_CardDeck_Shuffle()
    {

        List<int> aList = new List<int> { 0,1,2,3,4,5,6,7,8 };

        System.Random _random = new System.Random();

        int myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }



}
