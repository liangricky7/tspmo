using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class FileSet : MonoBehaviour
{
    #region Prefabs and Objects
    public GameObject form1040Prefab;
    public GameObject formW2Prefab;
    IndividualTax form1040;
    W2 formW2;
    GameObject form1040Obj;
    GameObject formW2Obj;
    #endregion

    #region fields
    // received from ssn db
    Identity selfIdentity;
    // following data will be generated in this file
    // for both 1040 and w2
    int w2Total;
    // 1040
    Identity spouseIdentity;
    string filingStatus;
    bool[] standardDeduction;
    Dependent[] dependents = new Dependent[4];
    int householdWages;
    int tipIncome;
    int otherIncome;
    int totalIncome;
    int standardDeductionAmt;
    int taxableIncome; 
    // w2
    Identity employerIdentity;
    int wages;
    int fedTax;
    int socSec;
    int withMed;
    int netWages;
    #endregion
    #region Generation Pool
    private static string[] firstName = {"Aaron", "Alex", "Bob", "Belle", "Christian", "Christina", "Donald", "Earl", "Felicia", "Frank", "Gerald", "Georgia", "Harry", "Isabella", "Johnny", "Jessica", "Kim", "Larry", "Monique", "Martin", "Nate", "Oliver", "Olivia", "Perry", "Quinn", "Rachel", "Ronald", "Sally", "Sarah", "Toddy", "Ursula", "Veronica", "Wally", "William", "Xavier", "Helena", "Zoe", "Ricky", "Mikey", "Rohan", "Michael", "Connor", "Ruijie"};
    private static string[] lastName = {"Anderson", "Barnes", "Wu", "Dewey", "Parker", "Frazier", "Phillips", "Howard", "Robinson", "Johnson", "Kirkman", "Lopez", "Martin", "Sanchez", "Oxford", "Pearson", "Clark", "Reeves", "Smith", "Thomas", "Uren", "Zhang", "Williams", "X", "Yangley", "Narayanan", "Liang", "Durgham", "Brescher", "Jennings", "Waters", "Feng", "Chenevert"};
    private static string[] streetName = {"Amiens", "Blue", "Bourbon", "Chester", "Dutch", "East", "Elm", "Greenwood", "Highland", "Hilcrest", "Lakeview", "James", "Springfield", "Main", "North", "Oakland", "Peppermint", "Quarter", "Riverbend", "South", "Town", "Glasgow", "Plank", "Village", "West", "Martin Luther King", "Nash", "Daniel Donze", "Andrew Webb", "John Luke Denny", "Washington"};
    private static string[] streetType = {"Alley", "Avenue", "Boulevard", "Street", "Court", "Drive", "Lane", "Plaza", "Road", "Way"};
    string[] stateAbbreviations = new string[]
    {
        "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
        "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
        "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
        "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
        "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
    };
    Dictionary<string, string[]> stateCities = new Dictionary<string, string[]>
    {
        { "AL", new string[] { "Birmingham", "Montgomery", "Mobile", "Huntsville", "Tuscaloosa" } },
        { "AK", new string[] { "Anchorage", "Fairbanks", "Juneau", "Sitka", "Wasilla" } },
        { "AZ", new string[] { "Phoenix", "Tucson", "Mesa", "Chandler", "Glendale" } },
        { "AR", new string[] { "Little Rock", "Fort Smith", "Fayetteville", "Springdale", "Jonesboro" } },
        { "CA", new string[] { "Los Angeles", "San Diego", "San Jose", "San Francisco", "Fresno" } },
        { "CO", new string[] { "Denver", "Colorado Springs", "Aurora", "Fort Collins", "Lakewood" } },
        { "CT", new string[] { "Bridgeport", "New Haven", "Stamford", "Hartford", "Waterbury" } },
        { "DE", new string[] { "Wilmington", "Dover", "Newark", "Middletown", "Smyrna" } },
        { "FL", new string[] { "Jacksonville", "Miami", "Tampa", "Orlando", "St. Petersburg" } },
        { "GA", new string[] { "Atlanta", "Augusta", "Columbus", "Savannah", "Athens" } },
        { "HI", new string[] { "Honolulu", "Pearl City", "Hilo", "Kailua", "Waipahu" } },
        { "ID", new string[] { "Boise", "Meridian", "Nampa", "Idaho Falls", "Pocatello" } },
        { "IL", new string[] { "Chicago", "Aurora", "Rockford", "Joliet", "Naperville" } },
        { "IN", new string[] { "Indianapolis", "Fort Wayne", "Evansville", "South Bend", "Carmel" } },
        { "IA", new string[] { "Des Moines", "Cedar Rapids", "Davenport", "Sioux City", "Iowa City" } },
        { "KS", new string[] { "Wichita", "Overland Park", "Kansas City", "Topeka", "Olathe" } },
        { "KY", new string[] { "Louisville", "Lexington", "Bowling Green", "Owensboro", "Covington" } },
        { "LA", new string[] { "New Orleans", "Baton Rouge", "Shreveport", "Lafayette", "Lake Charles" } },
        { "ME", new string[] { "Portland", "Lewiston", "Bangor", "South Portland", "Auburn" } },
        { "MD", new string[] { "Baltimore", "Frederick", "Rockville", "Gaithersburg", "Bowie" } },
        { "MA", new string[] { "Boston", "Worcester", "Springfield", "Cambridge", "Lowell" } },
        { "MI", new string[] { "Detroit", "Grand Rapids", "Warren", "Sterling Heights", "Ann Arbor" } },
        { "MN", new string[] { "Minneapolis", "Saint Paul", "Rochester", "Duluth", "Bloomington" } },
        { "MS", new string[] { "Jackson", "Gulfport", "Southaven", "Hattiesburg", "Biloxi" } },
        { "MO", new string[] { "Kansas City", "Saint Louis", "Springfield", "Independence", "Columbia" } },
        { "MT", new string[] { "Billings", "Missoula", "Great Falls", "Bozeman", "Butte" } },
        { "NE", new string[] { "Omaha", "Lincoln", "Bellevue", "Grand Island", "Kearney" } },
        { "NV", new string[] { "Las Vegas", "Henderson", "Reno", "North Las Vegas", "Sparks" } },
        { "NH", new string[] { "Manchester", "Nashua", "Concord", "Derry", "Dover" } },
        { "NJ", new string[] { "Newark", "Jersey City", "Paterson", "Elizabeth", "Edison" } },
        { "NM", new string[] { "Albuquerque", "Las Cruces", "Rio Rancho", "Santa Fe", "Roswell" } },
        { "NY", new string[] { "New York City", "Buffalo", "Rochester", "Yonkers", "Syracuse" } },
        { "NC", new string[] { "Charlotte", "Raleigh", "Greensboro", "Durham", "Winston-Salem" } },
        { "ND", new string[] { "Fargo", "Bismarck", "Grand Forks", "Minot", "West Fargo" } },
        { "OH", new string[] { "Columbus", "Cleveland", "Cincinnati", "Toledo", "Akron" } },
        { "OK", new string[] { "Oklahoma City", "Tulsa", "Norman", "Broken Arrow", "Lawton" } },
        { "OR", new string[] { "Portland", "Eugene", "Salem", "Gresham", "Hillsboro" } },
        { "PA", new string[] { "Philadelphia", "Pittsburgh", "Allentown", "Erie", "Reading" } },
        { "RI", new string[] { "Providence", "Warwick", "Cranston", "Pawtucket", "East Providence" } },
        { "SC", new string[] { "Columbia", "Charleston", "North Charleston", "Mount Pleasant", "Rock Hill" } },
        { "SD", new string[] { "Sioux Falls", "Rapid City", "Aberdeen", "Brookings", "Watertown" } },
        { "TN", new string[] { "Nashville", "Memphis", "Knoxville", "Chattanooga", "Clarksville" } },
        { "TX", new string[] { "Houston", "San Antonio", "Dallas", "Austin", "Fort Worth" } },
        { "UT", new string[] { "Salt Lake City", "West Valley City", "Provo", "West Jordan", "Orem" } },
        { "VT", new string[] { "Burlington", "South Burlington", "Rutland", "Barre", "Montpelier" } },
        { "VA", new string[] { "Virginia Beach", "Norfolk", "Chesapeake", "Richmond", "Newport News" } },
        { "WA", new string[] { "Seattle", "Spokane", "Tacoma", "Vancouver", "Bellevue" } },
        { "WV", new string[] { "Charleston", "Huntington", "Parkersburg", "Morgantown", "Wheeling" } },
        { "WI", new string[] { "Milwaukee", "Madison", "Green Bay", "Kenosha", "Racine" } },
        { "WY", new string[] { "Cheyenne", "Casper", "Laramie", "Gillette", "Rock Springs" } }
    };
    #endregion
    bool hasSpouse;
    bool filingJointly;

    public void newFileSet()
    {
        System.Random rand = new System.Random();
        hasSpouse = false;
        filingJointly = false;
        if (rand.Next(0, 101) <= 70) {
            hasSpouse = true;
            filingStatus = "Married Filing Seperately";
            if (rand.Next(0, 101) <= 60) {
                filingJointly = true;
                filingStatus = "Married Filing Jointly";
            }
        }
        InitializeTrue();
        Generate1040();
        GenerateW2();
    }

    void InitializeTrue() {
        System.Random rand = new System.Random();
        Identity identity = SSNDB.instance.getAdult();
        selfIdentity = identity;

        if (filingJointly) {
            while (identity == selfIdentity) identity = SSNDB.instance.getAdult();
            spouseIdentity = identity;
        }

        if (filingJointly) {
            filingStatus = "Married Filing Jointly";
        } else if (hasSpouse) {
            filingStatus = "Married Filing Seperately";
        } else {
            filingStatus = "Single";
        }

        int[] weightedDependentNum = {0, 0, 0, 1, 1, 2, 2, 2, 3, 4};
        int dependentNum = weightedDependentNum[rand.Next(weightedDependentNum.Length)];
        int dependentDeduction = 0;
        for (int i = 0; i < dependentNum; i++) {
                identity = SSNDB.instance.getPerson();
                while (identity == selfIdentity || identity == spouseIdentity) identity = SSNDB.instance.getPerson();
                Dependent dependent = new Dependent(identity.name, identity.SSN, Int32.Parse(identity.age) >= 18 ? false : true);
                if (dependent.childTax) {
                    dependentDeduction += 3000;
                } else {
                    dependentDeduction += 1000;
                }
                dependents[i] = dependent;
        }

        // w2
        while (identity == selfIdentity || identity == spouseIdentity) identity = SSNDB.instance.getAdult();
        employerIdentity = identity;
                
        int[] weightedIncomeClass = {0, 0, 0, 0, 0, 1, 1, 1, 2, 2};
        int incomeClass = weightedIncomeClass[rand.Next(weightedIncomeClass.Length)];
        if (incomeClass == 0) {
            wages = rand.Next(15000, 56600);
        } else if (incomeClass == 1) {
            wages = rand.Next(56600, 169800);
        } else {
            wages = rand.Next(169800, 500000);
        }

        fedTax = 12 * (wages / 100);
        socSec = 62 * (wages / 1000);
        withMed = 145 * (wages/10000);
        netWages = wages - fedTax - socSec - withMed;
        w2Total = netWages;

        // 1040 income
        householdWages = rand.Next(0, 100) < 90 ? 0 : rand.Next(1302, 5139);
        tipIncome = rand.Next(0, 100) < 40 ? 0 : rand.Next(2230, 6023);
        tipIncome = incomeClass > 0 ? 0 : tipIncome;
        otherIncome = rand.Next(0, 10023);

        totalIncome = w2Total + householdWages + tipIncome + otherIncome;

        if (filingJointly) {
            standardDeductionAmt = 27700;
        } else {
            standardDeductionAmt = 13850;
        }

        taxableIncome = totalIncome - standardDeductionAmt - dependentDeduction;
    }

    void Generate1040() {
        System.Random rand = new System.Random();
        GameObject form1040Obj = Instantiate(form1040Prefab, new Vector3(-3, 0, 0), Quaternion.identity);
        form1040 = form1040Obj.GetComponent<IndividualTax>();
        // true data
        form1040.fullName = selfIdentity.name;
        form1040.SSN = selfIdentity.SSN;
        form1040.address = selfIdentity.address;
        form1040.city = selfIdentity.city;
        form1040.state = selfIdentity.state;

        if (90 >= rand.Next(0, 101)) { //random name
            form1040.fullName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
        } 
        if (90 >= rand.Next(0, 101)) { //random name
            form1040.SSN = $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}";
        } 

        if (filingJointly) {
            form1040.spouseFullName = spouseIdentity.name;
            // add chaos to the ssn
            form1040.spouseSSN = rand.Next(0, 101) > 90 ? $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}" : spouseIdentity.SSN;
            Debug.Log("True Spouse SSN is " + spouseIdentity.SSN);
        }
        // bubble filing status
        if (filingJointly && rand.Next(0, 101) > 90) {
            form1040.filingStatus = "Married Filing Jointly";
        } else if (hasSpouse && rand.Next(0, 101) > 90) {
            if (filingStatus.Equals("Single")) { //avoids condition of true single but filed seperately; no possible way to tell
                form1040.filingStatus = "Single";
            } else form1040.filingStatus = "Married Filing Seperately";
        // } 
        // else if (hasSpouse) {
        //     form1040.filingStatus = "Head Of Household";
        } else {
            form1040.filingStatus = "Single";
        }
        Debug.Log("True filing status is " + filingStatus);


        if (hasSpouse) {
            //standard deduction
        } else if (hasSpouse && 90 >= rand.Next(0, 101)) { // slide through an error

        }

        form1040.dependents = dependents;

        foreach (Dependent dependent in form1040.dependents) {
            if (dependent == null) continue;
            if (rand.Next(0, 101) > 80) { // manipulate existing data
                int choice = rand.Next(2);
                if (choice == 0) {
                    dependent.name = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];   
                } else {
                    dependent.childTax = !dependent.childTax;
                }
            }
        }

        bool IncomeAltered = false; //makes sure only one of these get changed so theres no fucky wucky business
        form1040.totalW2 = (!IncomeAltered && 86 < rand.Next(0, 101)) ? w2Total + rand.Next(-13025, 1638) : w2Total;
        IncomeAltered = (!IncomeAltered && form1040.totalW2 == w2Total) ? false : true;
        form1040.household = householdWages;
        form1040.tipIncome = tipIncome;
        form1040.other = otherIncome;
        form1040.summedIncome = (!IncomeAltered && 86 < rand.Next(0, 101)) ? totalIncome + rand.Next(-219, 1230): totalIncome;
        IncomeAltered = (!IncomeAltered && form1040.summedIncome == totalIncome) ? false : true;
        form1040.deductions = (!IncomeAltered && 86 < rand.Next(0, 101)) ? standardDeductionAmt + rand.Next(12020, 25030) : standardDeductionAmt;
        IncomeAltered = (!IncomeAltered && form1040.deductions == standardDeductionAmt) ? false : true;
        form1040.taxableIncome = (!IncomeAltered && 86 < rand.Next(0, 101)) ? taxableIncome + rand.Next(-235, 338): taxableIncome;
    }

    void GenerateW2() {
        System.Random rand = new System.Random();
        formW2Obj = Instantiate(formW2Prefab, new Vector3(3, 0, 0), Quaternion.identity);
        formW2 = formW2Obj.GetComponent<W2>();
        
        formW2.fullEmployeeName = selfIdentity.name;
        formW2.employeeSSN = selfIdentity.SSN;
        formW2.employeeAddress = selfIdentity.address;
        formW2.fullEmployerName = employerIdentity.name;
        formW2.employerSSN = employerIdentity.SSN;
        formW2.employerAddress = employerIdentity.address;

        bool numbersAltered = false; //makes sure only one of these get changed so theres no fucky wucky business
        formW2.wages = (!numbersAltered && 86 < rand.Next(0, 101)) ? wages : + rand.Next(-5312, 4129);
        // numbersAltered = (!numbersAltered && formW2.wages == wages) ? false : true;
        formW2.fedTax = fedTax;
        formW2.socialSecurity = socSec;
        formW2.withheldMedicare = withMed;
        formW2.netWages = netWages;
    }
}
