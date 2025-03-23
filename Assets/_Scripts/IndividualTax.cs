using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IndividualTax : MonoBehaviour
{
    [Header("Data")]
    public string firstName;
    public string lastName;
    public string address;
    public string city;
    public string state;
    public string SSN;
    public string filingStatus;
    public string[] dependents;
    [Space(20)]
    [Header("Text Connections")]

    public TextMeshProUGUI firstNameHolder;
    public TextMeshProUGUI lastNameHolder;
    public TextMeshProUGUI addressHolder;
    public TextMeshProUGUI cityHolder;
    public TextMeshProUGUI stateHolder;
    public TextMeshProUGUI filingStatusHolder;
    public TextMeshProUGUI[] dependentsHolder;

    void Start()
    {
        firstNameHolder.text = firstName;
        lastNameHolder.text = lastName;
        addressHolder.text = address;
        cityHolder.text = city;
        stateHolder.text = state;
        filingStatusHolder.text = filingStatus;
    }
}
