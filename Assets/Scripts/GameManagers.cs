using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{
    public GameObject MenuSet;
    public GameObject GameExplain;
    public GameObject MyInform;
    public GameObject MyScore;

    public GameObject APlus;
    public GameObject A;
    public GameObject BPlus;
    public GameObject CPlus;

    public int NowspeedNum;

    GameObject CharacterinformNum;

    public static bool GameIsPaused = false;

    GameObject CallLevel;
    public int NowLevel;

    public Text LevelTxt;

    public Slider HPSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterinformNum = GameObject.Find("Main_Character");
        NowspeedNum = CharacterinformNum.GetComponent<MovingObject>().Nowspeed;
        NowLevel = CharacterinformNum.GetComponent<MovingObject>().level;

        LevelTxt.text = NowLevel.ToString();
    
    }

    public void Opensetting()
    {
        MenuSet.SetActive(true);
        GameIsPaused = true;
        if(GameIsPaused == true)
        {
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        MenuSet.SetActive(false);
        GameIsPaused = false;
        if(GameIsPaused == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void OpenHowto()
    {
        GameExplain.SetActive(true);
    }

    public void quitExplain()
    {
        GameExplain.SetActive(false);
    }

    public void OpenMyScore()
    {
        if(HPSlider.value == 0)
        {
            MyScore.SetActive(true);

            GameIsPaused = true;
            if(GameIsPaused == true)
            {
            Time.timeScale = 0f;
            }

            if(NowLevel == 1)
            {
                APlus.SetActive(false);
                A.SetActive(false);
                BPlus.SetActive(false);
                CPlus.SetActive(true);     
            }

            else if(NowLevel == 2)
            {
                APlus.SetActive(false);
                A.SetActive(false);
                BPlus.SetActive(true);
                CPlus.SetActive(false);
            }

            else if(NowLevel == 3)
            {
                APlus.SetActive(false);
                A.SetActive(true);
                BPlus.SetActive(false);
                CPlus.SetActive(false);
            }

            else
            {
                APlus.SetActive(true);
                A.SetActive(false);
                BPlus.SetActive(false);
                CPlus.SetActive(false);
            }
        }
    }

    public void ChangeSceneRetryBtn()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void GameExitBtn()
    {
        Application.Quit();
    }

    public void ChangHPSlider()
    {
        
    }

}
