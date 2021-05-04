using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingObject : MonoBehaviour
{
    // Start is called before the first frame update

	private BoxCollider2D boxCollider;
	public LayerMask layerMask;

	private float half = 0.5f;

	private Vector3 vector;

	public float walkCount;
	private int currentWalkCount;

	private bool canMove = true;
	public bool attack = false;

	private Animator animator;

	public int level;
    public float currentExp;
	public float curShowExp;

    public int NowMaxhp;
    public float NowCurrentHp;

    
	public int rise;

    public int Nowspeed;

	public float txtTimerA = 0;
	public float txtTimerB = 0;
	public float txtTimerC = 0;
	public float txtTimerMax = 30;

    GameObject Characterinform;
	GameObject EnemyInform;

	public Slider ExpSlider;

	public GameObject Stage1Img;
	public GameObject Stage2Img;
	public GameObject BossStageImg;

	public Text Stage1Txt;
	public Text Stage2Txt;
	public Text BossStageTxt;

	public Slider HPSlider;
	
	void Start()
	{ 

        Nowspeed = 10;

		boxCollider = GetComponent<BoxCollider2D>();
		animator = GetComponent<Animator>();
	
		level = 1;
		currentExp = 0;

		NowCurrentHp = NowMaxhp;
    }

	IEnumerator MoveCoroutine()
	{
		while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

			animator.SetFloat("DirX", vector.x);

			RaycastHit2D hit;

			Vector2 start = transform.position;
			Vector2 end = start + new Vector2(vector.x * Nowspeed * walkCount * half, vector.y * Nowspeed * walkCount * half);

			boxCollider.enabled = false;
			hit = Physics2D.Linecast(start, end, layerMask);
			boxCollider.enabled = true;

			if (hit.transform != null)
			{
				break;
			}


			animator.SetBool("Walking", true);

			while (currentWalkCount < walkCount)
			{
				if (vector.x != 0)
				{
					transform.Translate(vector.x * Nowspeed * half, 0, 0);
				}
				if (vector.y != 0)
				{
					transform.Translate(0, vector.y * Nowspeed * half, 0);
				}

				currentWalkCount++;
				yield return new WaitForSeconds(0.01f);
			}
		
			currentWalkCount = 0;
		}

		animator.SetBool("Walking", false);
		canMove = true;
	}

   	 // Update is called once per frame
    void Update()
   	{
		

		if (canMove)
		{
			if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
			{
				canMove = false;	
				StartCoroutine(MoveCoroutine());			
			}
		}

		animator.SetBool("Attack", false);
		animator.SetFloat("DirX", vector.x);
		
		if (Input.GetKey(KeyCode.Space))
		{
			animator.SetBool("Attack", true);
			animator.SetFloat("DirX", vector.x);
		}


		if (currentExp >= 80)
		{
			level = 3;
			ExpSlider.maxValue = 80;
			curShowExp = currentExp - 80;
			ExpSlider.value = curShowExp;
		}

		else if (currentExp >= 30)
		{
			level = 2;
			ExpSlider.maxValue = 50;
			curShowExp = currentExp - 30;
			ExpSlider.value = curShowExp;
		}

		else if (currentExp < 30)
		{
			level = 1;
			ExpSlider.maxValue = 30;
			curShowExp = currentExp;
			ExpSlider.value = curShowExp;
		}

		if (NowCurrentHp >= NowMaxhp) {NowCurrentHp = NowMaxhp;}
		if (NowCurrentHp <= 0) {NowCurrentHp = 0;}

		OpenStageTxt();		
	}

	public int outLevel()
	{
		return level;
	}

	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyA"))
        {
			//float enemyAtkDmg = GameObject.Find("book").GetComponent<Enemy>().atkDmg;
			NowCurrentHp -= 5;
			HPSlider.value = NowCurrentHp;
			SoundManager.instance.PlaySE("Damage");
        }

		if (col.CompareTag("EnemyB"))
		{
			currentExp += 4;
			ExpSlider.value = curShowExp;
			SoundManager.instance.PlaySE("GetExp");
		}
    }

	public void OpenStageTxt()
	{
		if(level == 1)
		{
			txtTimerA += 0.05f;
			if (txtTimerA < txtTimerMax)
			{
				Stage1Img.SetActive(true);
			}

			else
			{
				Stage1Img.SetActive(false);
			}

		}

		else if(level == 2)
		{
			txtTimerB += 0.05f;
			if (txtTimerB < txtTimerMax)
			{
				Stage2Img.SetActive(true);
			}

			else
			{
				Stage2Img.SetActive(false);
			}
		}

		else if(level == 3)
		{
			txtTimerC += 0.05f;
			if (txtTimerC < txtTimerMax)
			{
				BossStageImg.SetActive(true);
			}

			else
			{
				BossStageImg.SetActive(false);
			}
		}

	}
}
