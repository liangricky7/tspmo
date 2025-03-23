using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FileSet : MonoBehaviour
{
    #region Prefabs and Objects
    public GameObject form1040Prefab;
    public GameObject formW2Prefab;
    IndividualTax form1040;
    W2 formW2;
    #endregion

    #region fields
    // received from ssn db
    string name;
    string SSN;
    string age;
    string address;
    string city;
    string state;
    // following data will be generated in this file
    // for both 1040 and w2
    int w2Total;
    // 1040
    string spouseName;
    string spouseSSN;
    string filingStatus;
    bool[] standardDeduction;
    Dependent[] dependents;
    int householdWages;
    int tipIncome;
    int otherIncome;
    int totalIncome;
    int standardDeductionAmt;
    int taxableIncome; 
    // w2
    int employerSSN;
    string employerName;
    string employerAddress;
    int wages;
    int fedTax;
    int socSec;
    int withMed;
    int netWages;
    #endregion
    #region Generation Pool
    public static string[] firstName = {"Aaron", "Bob", "Christian", "Donald", "Earl", "Felicia", "Gerald", "Harry", "Isadore", "Johnny", "Kim", "Larry", "Monique", "Nate", "Oliver", "Perry", "Quinn", "Rachel", "Sally", "Toddy", "Ursula", "Veronica", "Wally", "Xavier", "Yelena", "Zoe"};
    public static string[] lastName = {"Anderson", "Barnes", "Cason", "Dewey", "Eagan", "Frazier", "Grimwood", "Howard", "Ida", "Johnson", "Kerkman", "Libberton", "Marlow", "Narcross", "Oxford", "Pearson", "Questead", "Reeves", "Southerwood", "Taterfield", "Uren", "Vousdon", "Waddesworth", "Xanthopoulos", "Yarsley", "Zealand"};
    public static string[] streetName = {"Amiens", "Blue", "Chester", "Dutch", "East", "Greenwood", "Highland", "Inverted", "James", "Springfield", "Lake", "Main", "North", "Oak", "Peppermint", "Quarter", "Roundhouse", "South", "Town", "Underside", "Plank", "Village", "West", "Martin Luther King", "Yellow", "Daniel Donze", "Andrew Webb", "John Luke Denny", "Zigzag"};
    public static string[] streetType = {"Alley", "Avenue", "Street", "Court", "Drive", "Lane", "Plaza", "Road", "Way"};
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
    void Start()
    {
        System.Random rand = new System.Random();
        hasSpouse = false;
        filingJointly = false;
        if (70 >= rand.Next(0, 101)) {
            hasSpouse = true;
            if (50 >= rand.Next(0, 101)) {
                filingJointly = true;
            }
        }
        Generate1040();
    }

    void Generate1040() {
        System.Random rand = new System.Random();
        // determines if 1040 declares a spouse

        GameObject formObject = Instantiate(form1040Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        form1040 = formObject.GetComponent<IndividualTax>();
        //
        // pull name and ssn from db
        //
        if (90 >= rand.Next(0, 101)) { //random name
            form1040.fullName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
        } 
        if (90 >= rand.Next(0, 101)) { //random name
            form1040.SSN = $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}";
        } 

        if (filingJointly) {
            // add spousal name and ssn
        
        }
        // bubble filing status
        if (filingJointly && 90 >= rand.Next(0, 101)) {
            form1040.filingStatus = "Married Filing Jointly";
        } else if (hasSpouse && 90 >= rand.Next(0, 101)) {
            form1040.filingStatus = "Married Filing Seperately";
        } else if (hasSpouse) {
            form1040.filingStatus = "Head Of Household";
        } else {
            form1040.filingStatus = "Single";
        }

        if (hasSpouse) {
            //standard deduction
        } else if (hasSpouse && 90 >= rand.Next(0, 101)) { // slide through an error

        }

        int[] weightedDependentNum = {0, 0, 0, 1, 1, 2, 2, 2, 3, 4};
        int dependentNum = weightedDependentNum[rand.Next(weightedDependentNum.Length)];
        
        for (int i = 0; i < dependentNum; i++) {
            if (86 >= rand.Next(0, 101)) { // generate faulty/fake data
                Dependent dependent = new Dependent(firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)], $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}", rand.Next(2) == 0);
                form1040.dependents[i] = dependent;
            } else { // pull from ssn
                // pull from ssn
            }
        }
        bool IncomeAltered = false; //makes sure only one of these get changed so theres no fucky wucky business
        form1040.totalW2 = 86 < rand.Next(0, 101) && !IncomeAltered ? w2Total : w2Total + rand.Next(-235, 1638);
        IncomeAltered = (form1040.totalW2 == w2Total) ? false : true;
        form1040.household = 86 < rand.Next(0, 101) && !IncomeAltered ? householdWages : householdWages + rand.Next(-235, 2189);
        IncomeAltered = (form1040.household == householdWages) ? false : true;
        form1040.tipIncome = 86 < rand.Next(0, 101) && !IncomeAltered ? tipIncome : tipIncome + rand.Next(-25, 328);
        IncomeAltered = (form1040.tipIncome == tipIncome) ? false : true;
        form1040.other = 86 < rand.Next(0, 101) && !IncomeAltered ? otherIncome : otherIncome + rand.Next(-235, 106);
        IncomeAltered = (form1040.other == otherIncome) ? false : true;        
        form1040.summedIncome = 86 < rand.Next(0, 101) && !IncomeAltered ? totalIncome : totalIncome + rand.Next(-219, 1230);
        IncomeAltered = (form1040.summedIncome == totalIncome) ? false : true;
        form1040.deductions = 86 < rand.Next(0, 101) && !IncomeAltered ? standardDeductionAmt : standardDeductionAmt + rand.Next(-235, 1239);
        IncomeAltered = (form1040.deductions == standardDeductionAmt) ? false : true;
        form1040.taxableIncome = 86 < rand.Next(0, 101) && !IncomeAltered ? taxableIncome : taxableIncome + rand.Next(-235, 338);
    }

    void GenerateW2() {
    //     var rand = new Random();
    //     GameObject W2Obj = Instantiate(W2Prefab, new Vector3(0, 0, 0), Quaternion.identity);
    //     W2 formContents = W2Obj.GetComponent<W2>();
    //     formContents.fullEmployeeName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
    //     formContents.employeeAddress = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
    //     formContents.employeeSSN = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
    //     formContents.fullEmployerName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
    //     formContents.employerAddress = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
    //     formContents.employerSSN = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
    //     formContents.wages = wages;
    //     formContents.fedTax = tax;
    //     formContents.socialSecurity = withheldSocialSecurity;
    //     formContents.withheldMedicare = withheldMedicare;
    //     formContents.netWages = net;
    // }
    }
}
