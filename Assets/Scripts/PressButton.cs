using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressButton : MonoBehaviour
{
    public GameObject currW2;
    public Transform item;
    public Vector3 Center;
    public Vector3 Shredder;
    public int state;
    private int flag = 0;


    void Start()
    {
        // if (prefab == null)
        // {
        //     Debug.LogError("Prefab isn't assigned!");
        // }

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
        Debug.Log("called");
        StartCoroutine(LerpPosition(currW2, Shredder, 0.2f));
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
        currW2 = GameManager.instance.currentW2;
        currW2.transform.position = item.position;
        currW2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        currW2.SetActive(true);
        StartCoroutine(LerpPosition(currW2, Center, 0.2f));
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
