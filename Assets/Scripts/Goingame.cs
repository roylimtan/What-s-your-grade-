using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goingame : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        SceneManager.LoadScene("Ingame");
    }
}
