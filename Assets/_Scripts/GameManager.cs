using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject currentW2;
    public GameObject current1040;
    public bool inHighlightMode;
    public Transform form1040Spawn;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
        inHighlightMode = true;
    }

    void Start()
    {
        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
    }

    public void EndFileSet()
    {  
        


        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
    }
}
