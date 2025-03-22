using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class W2 : MonoBehaviour
{
    [Header("Data")]
    public string employerID;
    public string employerName;
    public string employerAddress;
    public string employeeName;
    public string employeeAddress;
    public int wages;

    [Space(20)]
    [Header("Text Connections")]

    public TextMeshProUGUI firstNameHolder;
    public TextMeshProUGUI lastNameHolder;
    public TextMeshProUGUI addressHolder;
    public TextMeshProUGUI cityHolder;
    public TextMeshProUGUI stateHolder;
    public TextMeshProUGUI filingStatusHolder;
    public TextMeshProUGUI[] dependentsHolder;

    
}
