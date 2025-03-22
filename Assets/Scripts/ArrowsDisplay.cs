using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsDisplay : MonoBehaviour
{
    // Update is called once per frame
    bool transition = false;

    void Start()
    {
        //set arrows hidden at first to avoid conflicts with no papers
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    void Update()
    {

        //are there papers in play?
        GameObject stack = GameObject.Find("/Papers");
        GameObject space = GameObject.Find("/Workarea");
        if (stack != null)
        {
            // Stack is in center position
            if (stack.transform.position == space.transform.position)
            {
                if (transition)
                {
                    for (int i = 0; i < transform.childCount; i++)
                        transform.GetChild(i).gameObject.SetActive(true);
                    transition = !transition;
                }
            }
            //stack is moving.
            else
            {
                if (!transition)
                {
                    for (int i = 0; i < transform.childCount; i++)
                        transform.GetChild(i).gameObject.SetActive(false);
                    transition = !transition;
                }

                return;
            }
        }


    }
}
