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
    }

    public void CheckState()
    {
        switch (state)
        {
            case 0: //inital creation
                MakePaper();
                state = 1;
                break;

            case 1: //shredding papers
                ShredPaper();
                state = 0;
                break;

        }
    }

    public void ShredPaper()
    {
        GameObject temp = GameObject.Find("/Papers");
        GameObject.Destroy(temp);
        StartCoroutine(LerpPosition(temp, Shredder, 0.6f));
        state = 0;

    }



    public void MakePaper()
    {

        GameObject temp = GameObject.Instantiate(prefab, item.position, Quaternion.identity) as GameObject;
        temp.name = "Papers";
        // temp.SetActive(false);
        StartCoroutine(LerpPosition(temp, Center, 0.6f));
        state = 1;

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
    }

}
