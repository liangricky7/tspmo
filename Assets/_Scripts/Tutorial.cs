using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    bool tutorialOn = false;
    public TextMeshProUGUI Tutorial1;
    public TextMeshProUGUI Tutorial2;
    public TextMeshProUGUI Tutorial3;
    public TextMeshProUGUI Tutorial4;
    public TextMeshProUGUI Tutorial5;
    public TextMeshProUGUI Tutorial6;
    public Button nextPage;
    public Button lastPage;
    public int index;


    // Start is called before the first frame update
    void Start()
    {
        nextPage.onClick.AddListener(delegate{changePages("next");});
        lastPage.onClick.AddListener(delegate{changePages("last");});
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick() {
        tutorialOn = !tutorialOn;
        index = 1;
        if(tutorialOn == true) {
            displayText(index);
        }
        else { 
            hideText();
        }
    }

    public void changePages(string shift) {
        if(String.Equals(shift, "next") && index <= 3 && tutorialOn == true) {
            index++;
            displayText(index);
        }
        if(String.Equals(shift, "last") && index >= 1 && tutorialOn == true) {
            index--;
            displayText(index);
        }
    }

    public void displayText(int page) {
        switch(page) {
            case 1:
                hideText();
                Tutorial1.text = "Click to print a new W2 form";
                Tutorial2.text = "Inspect W2 form for mistakes: check correct data and uncheck incorrect data";
                Tutorial3.text = "Shredder shreds every paper when done";
                Tutorial4.text = "Press to access stack of papers";
                break;
            case 2:
                hideText();
                Tutorial5.text = "W2 Form\n"
                                    + "Employee/Employer Names: Tends to have a few missing letters\n"
                                    + "Employee/Employer Addresses: Tends to have a few missing letters\n"
                                    + "Employee/Employer SSN: Tends to have a few incorrect digits\n"
                                    + "Wages, Tax, Withheld SS/Medicare: Tends to be a little bit off\n"
                                    + "Net: Usually the sum of the last four- but if any of those are wrong, Net is likely wrong too!";
                                    break;
            case 3:
                hideText();
                Tutorial6.text = "uhh";
                break;
        }
    }

    public void hideText() {
        Tutorial1.text = "";
        Tutorial2.text = "";
        Tutorial3.text = "";
        Tutorial4.text = "";
        Tutorial5.text = "";
        Tutorial6.text = "";
    }

}
