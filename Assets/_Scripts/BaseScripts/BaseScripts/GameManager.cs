using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    void Start()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);
    }
}
