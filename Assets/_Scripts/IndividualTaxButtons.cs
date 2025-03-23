using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndividualTaxButtons : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.interactable = false;
    }

    void Update()
    {
        button.interactable = GameManager.instance.inHighlightMode;
    }

    public void Information(int i) {
        if (i == 0) { // Full Name is Wrong
            
        } else if (i == 1) { // SSN is wrong

        } else if (i == 2) { // Spouse Name is wrong

        } else if (i == 3) { // Spouse SSN is wrong

        } else if (i == 4) { // Address is wrong

        }
    }

    public void FilingStatus() {
        //Claim filing status is faulty
    }

    public void Dependent(int i) {
        // ith dependent is faulty
    }
    public void Income(int i) {
        //claim one of the incomes is wrong
    }
}
