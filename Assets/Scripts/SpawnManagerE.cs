using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerE : MonoBehaviour
{
    public float spawnTime = 3;
    public float curTime;
    public Transform[] spawnPoints;
    public GameObject enemy;

    public int nowLevel;

	private void Start()
	{
		
    }

    private void Update()
    {
        nowLevel = GameObject.Find("Main_Character").GetComponent<MovingObject>().outLevel();
        if (nowLevel == 3)
        {
            if (curTime >= spawnTime)
            {
                int x = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(x);
            }
            curTime += Time.deltaTime;
        }
    }

    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        Instantiate(enemy, spawnPoints[ranNum]);
    }
}
