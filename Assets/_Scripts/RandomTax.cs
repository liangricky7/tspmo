using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomTax : MonoBehaviour
{
    //Basic info
    public static string[] firstName = {"Aaron", "Bob", "Christian", "Donald", "Earl", "Felicia", "Gerald", "Harry", "Isadore", "Johnny", "Kim", "Larry", "Monique", "Nate", "Oliver", "Perry", "Quinn", "Rachel", "Sally", "Toddy", "Ursula", "Veronica", "Wally", "Xavier", "Yelena", "Zoe"};
    public static string[] lastName = {"Anderson", "Barnes", "Cason", "Dewey", "Eagan", "Frazier", "Grimwood", "Howard", "Ida", "Johnson", "Kerkman", "Libberton", "Marlow", "Narcross", "Oxford", "Pearson", "Questead", "Reeves", "Southerwood", "Taterfield", "Uren", "Vousdon", "Waddesworth", "Xanthopoulos", "Yarsley", "Zealand"};
    public static int age;
    public static bool married;
    public static string socialSecurity;
    public static string workSocialSecurity;
    
    //Address
    public static string workAddress;
    public static string[] address = {"Amiens", "Blue", "Chester", "Dutch", "East", "Grand", "Highland", "Inverted", "James", "Kimberly", "Lake", "Mint", "North", "Oak", "Peppermint", "Quarter", "Roundhouse", "South", "Town", "Underside", "Village", "West", "Xylophone", "Yellow", "Zigzag"};
    public static string[] streetType = {"Alley", "Street", "Court", "Drive", "Lane", "Plaza", "Road", "Way"};

    //Incomes
    public static int wages;
    public static int tax;
    public static int withheldSocialSecurity;
    public static int withheldMedicare;
    public static int net;

    // Start is called before the first frame update
    void Start()
    {
        var rand = new Random();
        age = rand.Next(18, 76);
        socialSecurity = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
        workSocialSecurity = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));

        workAddress = ((rand.Next(1000)).ToString() + " " + address[rand.Next(address.Length)] + " " + streetType[rand.Next(streetType.Length)]);
        
        if(rand.Next(2) == 0) {
            married = false;
        }
        else {
            married = true;
        }

        wages = rand.Next(10000, 1000000);
        tax = rand.Next(0, wages/10);
        withheldSocialSecurity = rand.Next(0, wages/10);
        withheldMedicare = rand.Next(0, wages/10);
        net = wages - tax - withheldSocialSecurity - withheldMedicare;

        Randomization();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Randomization() {
        var rand = new Random();
        string infoOutput = ((firstName[rand.Next(firstName.Length)]) + " " + (lastName[rand.Next(lastName.Length)]) + " is a " + age + " year old with the social security number " + socialSecurity + ". \n" 
                            + "They work at " + workAddress +" and their employer has a social security number of " + workSocialSecurity + ". \n"
                            + "They've made $" + wages.ToString("N0") + " and owe $" + tax.ToString("N0") + " in taxes, along with $" + withheldSocialSecurity.ToString("N0") + " and $" + withheldMedicare.ToString("N0") + " in withheld social security/medicare. \n"
                            + "Their net should be $" + net.ToString("N0") + ".").ToString();
        Debug.Log(infoOutput);
    }
}
