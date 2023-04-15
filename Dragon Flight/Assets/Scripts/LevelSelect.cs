using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayBoss()
    {
        SceneManager.LoadScene("Boss");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("Level3");
    }
}
