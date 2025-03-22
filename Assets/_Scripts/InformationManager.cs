using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationManager : MonoBehaviour
{
    public static InformationManager instance;
    private Dictionary<string, string[]> form1040Data;
    private Dictionary<string, string> W2Data;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public void setTrue1040(string firstName, string lastName, string address, string city, string state, string SSN, string filingStatus, string[] dependents) {
        if (form1040Data != null) form1040Data = null;
        form1040Data = new Dictionary<string, string[]>{
            {"FirstName", new string[]{firstName}},
            {"LastName", new string[]{lastName}},
            {"Address", new string[]{address}},
            {"City", new string[]{city}},
            {"State", new string[]{state}},            
            {"SSN", new string[]{SSN}},            
            {"FilingStatus", new string[]{filingStatus}},            
            {"Dependents", dependents}            
        };
    }

    public string getTrue1040(string key, int index = 0) {
        return form1040Data[key][index];
    }

    public void setTrueW2(string employerName, string employerSSN, string employerAddress, int wages, int fedTax, int socSec, int med, int net) {
        if (W2Data != null) form1040Data = null;
        W2Data = new Dictionary<string, string>{
            {"EmployeeFullName", getTrue1040("FirstName") + " " + getTrue1040("LastName")},
            {"EmployeeSSN", getTrue1040("SSN")},
            {"EmployeeAddress", getTrue1040("Address")},
            {"EmployerFullName", employerName},
            {"EmployerSSN", employerSSN},
            {"EmployerAddress", employerAddress},      
            {"Wages", wages.ToString()},        
            {"FederalTaxWithheld", fedTax.ToString()},            
            {"SocialSecurityWithheld", socSec.ToString()},        
            {"MedicareWithheld", med.ToString()},
            {"NetWages", net.ToString()}         
        };
    }
    public string getTrueW2(string key) {
        return W2Data[key];
    }
}
