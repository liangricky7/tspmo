using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSNgle : MonoBehaviour
{
    public GameObject searchBar;
    private bool toggle;

    void Start()
    {
        Debug.Log(searchBar.name);
        toggle = false;
        searchBar.SetActive(toggle);
    }

    void OnMouseDown()
    {
        DisplaySSNgle();
        Debug.Log(toggle);
    }

    public void DisplaySSNgle()
    {
        searchBar.SetActive(toggle);
        toggle = !toggle;
    }

}
