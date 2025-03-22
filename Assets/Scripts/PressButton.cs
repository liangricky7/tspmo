using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressButton : MonoBehaviour
{

    public GameObject prefab;
    public Transform item;
    public Vector3 Center;
    public Vector3 Shredder;
    public int state;
    private int flag = 0;


    void Start()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab isn't assigned!");
        }

        if (item == null)
        {
            Debug.LogError("Transform isn't assigned!");
        }

        Shredder = GameObject.Find("/Shredder").transform.position;
        Center = GameObject.Find("/Workarea").transform.position;
    }

    public void CheckState()
    {
        switch (state)
        {
            case 0: //inital creation
                MakePaper();
                break;

            case 1: //shredding papers
                ShredPaper();
                break;

        }
    }

    public void ShredPaper()
    {
        //check to prevent deleting null papers
        if (GameObject.Find("/Papers") == null)
        {
            return;
        }
        GameObject temp = GameObject.Find("Papers");
        Debug.Log(temp.name);
        StartCoroutine(LerpPosition(temp, Shredder, 0.2f));
        // while (Vector3.Distance(Shredder, temp.transform.position) > 0.001f)
        // {
        //     Debug.Log("Moving there!");
        // }


    }



    public void MakePaper()
    {
        //check to prevent doubling up papers
        if (GameObject.Find("/Papers") != null)
        {
            return;
        }
        GameObject temp = GameObject.Instantiate(prefab, item.position, Quaternion.identity) as GameObject;
        temp.name = "Papers";
        // temp.SetActive(false);
        StartCoroutine(LerpPosition(temp, Center, 0.2f));

    }


    IEnumerator LerpPosition(GameObject item, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = item.transform.position;

        while (time < duration)
        {
            item.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        item.transform.position = targetPosition;

        if (targetPosition == Shredder)
        {
            GameObject.Destroy(item);
        }

        if (state == 0)
        {
            state++;
        }
        else
        {
            state = 0;
        }


    }



}
