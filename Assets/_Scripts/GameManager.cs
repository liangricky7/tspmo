using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }

    }

    void Start()
    {
        
    }
    public void EndFileSet()
    {
        
    }
}
