using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SSNgle : MonoBehaviour
{
    public GameObject searchBar;
    public Button searchToggle;
    public TMP_InputField input;
    private bool toggle;
    public string search;

    void Start()
    {
        input = searchBar.GetComponent<TMP_InputField>();
        // toggle = false;
        // searchBar.SetActive(toggle);
    }

    // public void DisplaySSNgle()
    // {
    //     toggle = !toggle;
    //     searchBar.SetActive(toggle);
    // }

    public void getInput(string s) {
        search = s;
        Debug.Log(input.text);
        Identity identity = SSNDB.instance.Search(input.text);
        Debug.Log(identity.name);
        Debug.Log(identity.address);
        Debug.Log(identity.age);
    }

}
