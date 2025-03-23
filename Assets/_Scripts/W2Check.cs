using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W2Check : MonoBehaviour
{
    public Toggle employeeNameCheck;
    public Toggle employeeSSNCheck;
    public Toggle employeeAddressCheck;
    public Toggle employerNameCheck;
    public Toggle employerSSNCheck;
    public Toggle employerAddressCheck;
    public Toggle wagesCheck;
    public Toggle fedTaxCheck;
    public Toggle socialSecurityCheck;
    public Toggle withheldMedicareCheck;
    public Toggle netWagesCheck;
    public int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPress() {
        score = 0;
        if(employeeNameCheck.isOn == RandomTax.nameCorrect) {
            score++;
        }
        if(employeeSSNCheck.isOn == RandomTax.socialSecurityCorrect) {
            score++;
        }
        if(employeeAddressCheck.isOn == RandomTax.addressCorrect) {
            score++;
        }
        if(employerNameCheck.isOn) {
            score++;
        }
        if(employerSSNCheck.isOn) {
            score++;
        }
        if(employerAddressCheck.isOn) {
            score++;
        }
        if(wagesCheck.isOn == RandomTax.wagesCorrect) {
            score++;
        }
        if(fedTaxCheck.isOn == RandomTax.taxCorrect) {
            score++;
        }
        if(socialSecurityCheck.isOn == RandomTax.withheldSSCorrect) {
            score++;
        }
        if(withheldMedicareCheck.isOn == RandomTax.withheldMedicareCorrect) {
            score++;
        }
        if(netWagesCheck.isOn == RandomTax.netCorrect) {
            score++;
        }

        Debug.Log(score);
    }
}
