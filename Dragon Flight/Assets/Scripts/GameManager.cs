using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    [SerializeField] GameObject completeLevelUI;
    //public GameObject completeLevelUI;

    Monster[] _monsters;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (MonstersAreAllDead())
        {
            completeLevelUI.SetActive(true);
        }
    }

   // void GoToNextLevel()
   // {
        //completeLevelUI.SetActive(true);
        //SceneManager.LoadScene(_nextLevelName);
  //  }

    bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
}
