using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemiesOnScene : MonoBehaviour
{
    public static bool IsEnemiesOnScene
    {
        get;
        private set;
    }

    private void Start()
    {
        IsEnemiesOnScene = true;
    }

    private void Update()
    {
        IsEnemiesOnScene = Check();
    }

    public bool Check()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
