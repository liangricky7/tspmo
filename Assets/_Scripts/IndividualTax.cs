using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dependent {
    public string name;
    public string ssn;
    public bool childTax;

    public Dependent(string name, string ssn, bool childTax) {
        this.name = name;
        this.ssn = ssn;
        this.childTax = childTax;
    }
}

public class IndividualTax : MonoBehaviour
{
    #nullable enable
    [Header("Data")]
    public string fullName;
    public string SSN;
    public string? spouseFullName;
    public string? spouseSSN;
    public string address;
    public string city;
    public string state;
    public string zip;
    public string filingStatus;
    public string? deductionClaim;
    public string? deductionAge;
    public Dependent[] dependents;
    public int totalW2;
    public int household;
    public int tipIncome;
    public int other;
    public int summedIncome;
    public int deductions;
    public int taxableIncome;

    [Space(10)]
    [Header("Text Connections")]

    public TextMeshProUGUI fullNameHolder;
    public TextMeshProUGUI SSNHolder;
    public TextMeshProUGUI fullSpouseNameHolder;
    public TextMeshProUGUI SSNSpouseHolder;
    public TextMeshProUGUI addressHolder;
    public TextMeshProUGUI cityHolder;
    public TextMeshProUGUI stateHolder;
    public TextMeshProUGUI zipHolder;
    public TextMeshProUGUI[] filingStatusTickers;
    public TextMeshProUGUI[] deductionClaimTickers;
    public TextMeshProUGUI[] deductionAgeTickers;
    public TextMeshProUGUI[] dependentNameHolders;
    public TextMeshProUGUI[] dependentSSNHolders;
    public TextMeshProUGUI[] dependentChildTaxTickers;
    public TextMeshProUGUI W2Holder;
    public TextMeshProUGUI HouseholdHolder;
    public TextMeshProUGUI TipIncomeHolder;
    public TextMeshProUGUI OtherIncomeHolder;
    public TextMeshProUGUI SummedIncomeHolder;
    public TextMeshProUGUI DeductionHolder;
    public TextMeshProUGUI TaxableIncomeHolder;

    void Start()
    {
        fullNameHolder.text = fullName;
        SSNHolder.text = SSN;
        fullSpouseNameHolder.text = spouseFullName;
        SSNSpouseHolder.text = spouseSSN;
        addressHolder.text = address;
        cityHolder.text = city;
        stateHolder.text = state;
        zipHolder.text = zip;

        // filing status
        if (filingStatus.Equals("Single")) {
            filingStatusTickers[0].enabled = true;
        } else if (filingStatus.Equals("Married Filing Jointly")) {
            filingStatusTickers[1].enabled = true;
        } else if (filingStatus.Equals("Married Filing Seperately")) {
            filingStatusTickers[2].enabled = true;
        } else if (filingStatus.Equals("Head Of Household")) {
            filingStatusTickers[3].enabled = true;
        }

        // deduction claims
        if (deductionClaim != null && deductionClaim.Equals("YouDependent")) {
            deductionClaimTickers[0].enabled = true;
        } else if (deductionClaim != null && deductionClaim.Equals("SpouseDependent")) {
            deductionClaimTickers[1].enabled = true;
        }

        // deduction ages
        if (deductionAge != null && deductionAge.Equals("YouOld")) {
            deductionAgeTickers[0].enabled = true;
        } else if (deductionAge != null && deductionAge.Equals("SpouseOld")) {
            deductionAgeTickers[1].enabled = true;
        }

        // dependents
        int i = 0;
        foreach (Dependent dependent in dependents) {
            dependentNameHolders[i].text = dependent.name;
            dependentSSNHolders[i].text = dependent.ssn;
            dependentChildTaxTickers[i].enabled = dependent.childTax;
            i++;
        }

        W2Holder.text = totalW2.ToString();
        HouseholdHolder.text = household.ToString();
        TipIncomeHolder.text = tipIncome.ToString();
        OtherIncomeHolder.text = other.ToString();
        SummedIncomeHolder.text = summedIncome.ToString();
        DeductionHolder.text = deductions.ToString();
        TaxableIncomeHolder.text = taxableIncome.ToString();
    }
}
