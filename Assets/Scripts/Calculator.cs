using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using TMPro;

public class Calculator : MonoBehaviour
{

    public TextMeshProUGUI MText;
    private string currentInput = "";
    private double result = 0.0;

    public void OnButtonClick(string buttonValue)
    {

        if(buttonValue == "=")
        {

            CalculateResult();

        }
        else if(buttonValue == "C")
        {

            ClearInput();

        }
        else if(buttonValue == "CH. DEP")
        {

            result = System.Convert.ToDouble(currentInput) * 3000;
            currentInput = result.ToString();
            UpdateDisplay();

        }
        else if (buttonValue == "AD. DEP")
        {

            result = System.Convert.ToDouble(currentInput) * 1000;
            currentInput = result.ToString();
            UpdateDisplay();

        }
        else
        {

            currentInput += buttonValue;
            UpdateDisplay();

        }

    }

    public void CalculateResult()
    {
        try
        {

            result = System.Convert.ToDouble(new System.Data.DataTable().Compute(currentInput, ""));
            currentInput = result.ToString();
            UpdateDisplay();

        }
        catch (System.Exception ex)
        {

            currentInput = "Error";
            UpdateDisplay();

        }
        

    }

    private void ClearInput()
    {

        currentInput = "";
        result = 0.0;
        UpdateDisplay();

    }

    private void UpdateDisplay()
    {

        MText.text = currentInput;
    
    }

}
