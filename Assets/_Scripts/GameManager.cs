using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject currentW2;
    public GameObject current1040;
    public bool inHighlightMode;
    public Transform form1040Spawn;
    public HashSet<string> claimedErrors;
    public GameObject shredder;
    int count = 0;

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
            win();
        }
        else
        {
            if (count == 3) lose();
            count++;
        }
        FileSet.instance.newFileSet();
        current1040 = FileSet.instance.form1040Obj;
        currentW2 = FileSet.instance.formW2Obj;
        Debug.Log($"HashSet Contents: {string.Join(", ", FileSet.instance.form1040Errors)}");
        shredder.GetComponent<ObjectShake>().TriggerShake();
    }

    void win()
    {

        SceneManager.LoadSceneAsync("Victory");

    }

    void lose()
    {
        SceneManager.LoadSceneAsync("GameOver");

    }
}
