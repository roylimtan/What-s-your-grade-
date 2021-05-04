using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerC : MonoBehaviour
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
        if (nowLevel == 2)
        {
            if (curTime >= spawnTime)
            {
                int x = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(x);
            }
            curTime += Time.deltaTime;
        }

        DeleteObject();
    }

    public void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        Instantiate(enemy, spawnPoints[ranNum]);
    }

    public void DeleteObject()
    {
        nowLevel = GameObject.Find("Main_Character").GetComponent<MovingObject>().level;
        if (nowLevel == 3)
        {
            Destroy(this.gameObject);
        } 
    }
}
