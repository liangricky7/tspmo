using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationManager : MonoBehaviour
{
    public static InformationManager instance;
    private Dictionary<string, string[]> form1040Data;

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    }

    public void setTrue1040(string firstName, string lastName, string address, string city, string state, string filingStatus, string[] dependents) {
        if (form1040Data != null) form1040Data = null;
        form1040Data = new Dictionary<string, string[]>{
            {"FirstName", new string[]{firstName}},
            {"LastName", new string[]{lastName}},
            {"Address", new string[]{address}},
            {"City", new string[]{city}},
            {"State", new string[]{state}},            
            {"FilingStatus", new string[]{filingStatus}},            
            {"Dependents", dependents}            
        };
    }

    public string getTrue1040(string key, int index = 0) {
        return form1040Data[key][index];
    }

}
