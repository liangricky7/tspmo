using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Shredder")
        {
            Debug.Log("hooray");
        }

        if (col.gameObject.tag == "Stack")
        {
            Debug.Log("yipppeee");
        }
    }

}
