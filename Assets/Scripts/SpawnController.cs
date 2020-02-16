using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnController : MonoBehaviour
{

    [SerializeField]
    protected float initialSpawnRate = 10;
    [SerializeField]
    private int randomPacketSize = 6;
    protected float spawnRate;
    protected float lastSpawnedBoxTime;
    protected int boxSpawnNumber = 0;
    private GameObject box;
    private List<int> boxList;
    private int bombBox;
    private BoxController boxComponent;
    private int boxCount;
    [SerializeField]
    private int maximumBoxCount = 9;


// Start is called before the first frame update
    protected void Start()
    {
        spawnRate = initialSpawnRate;
        lastSpawnedBoxTime = -spawnRate;
        boxSpawnNumber = 0;
        boxCount = 0;
        generateNewList();
    }

    // Update is called once per frame
    protected void Update()
    {

        if (Time.time > lastSpawnedBoxTime + spawnRate && boxCount < maximumBoxCount)
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
            boxComponent.onBoxDeath += BoxOnDeath;

            if (boxSpawnNumber == bombBox)
            {
                boxComponent.isSafe = false;
            }

            boxSpawnNumber++;
            if (boxSpawnNumber >= randomPacketSize)
            {
                generateNewList();
                boxSpawnNumber = 0;
            }

            boxCount++;

            lastSpawnedBoxTime = Time.time;
        }

        /* Restart Code
        using UnityEngine.SceneManagement;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        */
    }

    void BoxOnDeath()
    {
        boxCount--;
    }



    private void generateNewList()
    {
        boxList = Fisher_Yates_CardDeck_Shuffle();
        bombBox = Random.Range(0, randomPacketSize);
    }




    public List<int> Fisher_Yates_CardDeck_Shuffle()
    {

        List<int> aList = new List<int>();
        for (int i = 0; i < randomPacketSize; i++)
        {
            aList.Add(i);
        }

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
