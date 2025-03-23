using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class W2 : MonoBehaviour
{
    [Header("Data")]
    public string fullEmployeeName;
    public string employeeSSN;
    public string employeeAddress;
    public string fullEmployerName;
    public string employerSSN;
    public string employerAddress;
    public int wages;
    public int fedTax;
    public int socialSecurity;
    public int withheldMedicare;
    public int netWages;


    [Space(10)]
    [Header("Text Connections")]

    public TextMeshProUGUI employeeNameHolder;
    public TextMeshProUGUI employeeSSNHolder;
    public TextMeshProUGUI employeeAddressHolder;
    public TextMeshProUGUI employerNameHolder;
    public TextMeshProUGUI employerSSNHolder;
    public TextMeshProUGUI employerAddressHolder;
    public TextMeshProUGUI wageHolder;
    public TextMeshProUGUI fedTaxHolder;
    public TextMeshProUGUI socSecHolder;
    public TextMeshProUGUI withheldMedicareHolder;
    public TextMeshProUGUI netWageHolder;

    void Start()
    {
        employeeNameHolder.text = fullEmployeeName;
        employeeSSNHolder.text = employeeSSN;
        employeeAddressHolder.text = employeeAddress;
        employerNameHolder.text = fullEmployerName;
        employerSSNHolder.text = employerSSN;
        employerAddressHolder.text = employerAddress;
        wageHolder.text = wages.ToString("N0");
        fedTaxHolder.text = fedTax.ToString("N0");
        socSecHolder.text = socialSecurity.ToString("N0");
        withheldMedicareHolder.text = withheldMedicare.ToString("N0");
        netWageHolder.text = netWages.ToString("N0");
    }
}