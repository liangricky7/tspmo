using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualTaxButtons : MonoBehaviour
{
    public Toggle button;
    bool isPressed = false;
    bool fullName;
    bool spouseName;
    bool address;
    bool filingStatus;
    bool[] dependents;
    bool income1;
    bool income2;
    void Start()
    {
        button.interactable = false;
        dependents = new bool[4];
    }
    void Update()
    {
        button.interactable = GameManager.instance.inHighlightMode;
    }

    public void Information(int i) {
        if (i == 0) { // Full Name is Wrong
            if (!fullName) {
                GameManager.instance.claimedErrors.Add("Full Name");
                fullName = true;
            } else {
                GameManager.instance.claimedErrors.Remove("Full Name");
                fullName = false;
            }
        } else if (i == 1) { // SSN is wrong

        } else if (i == 2) { // Spouse Name is wrong
            if (!spouseName) {
                GameManager.instance.claimedErrors.Add("Spouse Name");
                spouseName = true;
            } else {
                GameManager.instance.claimedErrors.Add("Spouse Name");
                spouseName = false;
            }
        } else if (i == 3) { // Spouse SSN is wrong

        } else if (i == 4) { // Address is wrong
            if (!address) {
                GameManager.instance.claimedErrors.Add("Address");
                address = true;
            } else {
                GameManager.instance.claimedErrors.Add("Address");
                address = false;
            }
        }
        Debug.Log("information pressed");
    }

    public void FilingStatus() {
        //Claim filing status is faulty
        if (!filingStatus) {
            GameManager.instance.claimedErrors.Add("Filing Status");
            filingStatus = true;
        } else {
            GameManager.instance.claimedErrors.Remove("Filing Status");
            filingStatus = false;
        }
        Debug.Log("filing pressed");
    }

    public void Dependent(int i) {
        // ith dependent is faulty
        if (!dependents[i]) {
            GameManager.instance.claimedErrors.Add("Dependent " + i);
            dependents[i] = true;
        } else {
            GameManager.instance.claimedErrors.Remove("Dependent " + i);
            dependents[i] = false;
        }
        
        Debug.Log("dependent pressed");
    }
    public void Income(int i) {
        //claim one of the incomes is wrong
        
        if (i == 1) {
            if (!income1) {
                GameManager.instance.claimedErrors.Add("Income " + i  + " Altered");
                income1 = true;
            } else {
                GameManager.instance.claimedErrors.Add("Income " + i  + " Altered");
                income1 = false;
            }
        } else {
            if (!income2) {
                GameManager.instance.claimedErrors.Add("Income " + i  + " Altered");
                income2 = true;
            } else {
                GameManager.instance.claimedErrors.Add("Income " + i  + " Altered");
                income2 = false;
            }
        }
        
        Debug.Log("income pressed");
    }
}
