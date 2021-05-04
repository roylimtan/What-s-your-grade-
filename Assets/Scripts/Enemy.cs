using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private BoxCollider2D boxCollider;
	public LayerMask layerMask;

    public string enemyName;
    public float maxHp;
    public float nowHp;
    public float atkDmg;
    public float atkSpeed;
    public float defDmg;
    public float givExp;

    public bool atk;
    public float atkDmgChar;

    public float xMovA;
    public float yMovA;

    public float curTime;
    public float curTimeMax;

    public int preLevel;
    public int nextLevel;

    GameObject characterMain;

    private void Start()
    {
    

        curTime = 0;
        curTimeMax = 5;

        xMovA = Random.Range(-10, 10) * 0.1f;
        yMovA = Random.Range(-10, 10) * 0.1f;

        preLevel = 1;
    }

    private void Update()
    {

        curTime += 0.02f;

        if (curTime >= curTimeMax) 
        {
            xMovA = Random.Range(-10, 10) * 0.1f;
            yMovA = Random.Range(-10, 10) * 0.1f;

            curTime = 0;
        }

        transform.Translate(xMovA, yMovA, 0);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }


}
