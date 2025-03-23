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
            //calc child dependency
        }
        else if (buttonValue == "AD. DEP")
        {
            //calc adult dependency
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
