using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSNgle : MonoBehaviour
{
    public GameObject searchBar;
    public Button searchToggle;
    private bool toggle;
    public string search;

    void Start()
    {
        toggle = false;
        searchBar.SetActive(toggle);
    }

    public void DisplaySSNgle()
    {
        toggle = !toggle;
        searchBar.SetActive(toggle);
    }

    public void getInput(string s) {
        search = s;
        Debug.Log(search);
    }

}
