using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject currentW2;
    public GameObject current1040;
<<<<<<< HEAD
    public bool inHighlightMode;
    public Transform form1040Spawn;
    public HashSet<string> claimedErrors;
=======
>>>>>>> parent of f680be6 (Merge branch 'main' of https://github.com/liangricky7/tspmo)

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
<<<<<<< HEAD
        inHighlightMode = true;
        claimedErrors = new HashSet<string>();
=======
>>>>>>> parent of f680be6 (Merge branch 'main' of https://github.com/liangricky7/tspmo)
    }

    void Start()
    {
        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
        Debug.Log($"HashSet Contents: {string.Join(", ", FileSet.instance.formW2Errors)}");
    }
    public void EndFileSet()
<<<<<<< HEAD
    {  
        if (claimedErrors.SetEquals(FileSet.instance.form1040Errors)) {
            //idk somethign good
            Debug.Log("good");
        } else {
            Debug.Log("bad");
        }


=======
    {
>>>>>>> parent of f680be6 (Merge branch 'main' of https://github.com/liangricky7/tspmo)
        FileSet.instance.newFileSet();
    }
}
