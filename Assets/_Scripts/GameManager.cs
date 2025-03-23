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
    public HashSet<string> claimedErrors;
    public GameObject shredder;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        inHighlightMode = true;
        claimedErrors = new HashSet<string>();
    }

    void Start()
    {
        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
    }

    public void EndFileSet()
    {
        if (claimedErrors.SetEquals(FileSet.instance.form1040Errors))
        {
            //idk somethign good
            Debug.Log("good");
        }
        else
        {
            Debug.Log("bad");
        }
        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
        Debug.Log($"HashSet Contents: {string.Join(", ", FileSet.instance.form1040Errors)}");
        shredder.GetComponent<ObjectShake>().TriggerShake();
    }
}
