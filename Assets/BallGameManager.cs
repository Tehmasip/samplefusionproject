using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameManager : MonoBehaviour
{
    public int index;
    public Transform[] points;
    public static BallGameManager Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    
}
