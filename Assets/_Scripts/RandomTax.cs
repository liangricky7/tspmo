using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomTax : MonoBehaviour
{
    public GameObject W2Prefab;
    public GameObject form1040Prefab;

    //Basic info
    public static string[] firstName = {"Aaron", "Bob", "Christian", "Donald", "Earl", "Felicia", "Gerald", "Harry", "Isadore", "Johnny", "Kim", "Larry", "Monique", "Nate", "Oliver", "Perry", "Quinn", "Rachel", "Sally", "Toddy", "Ursula", "Veronica", "Wally", "Xavier", "Yelena", "Zoe"};
    public static string[] lastName = {"Anderson", "Barnes", "Cason", "Dewey", "Eagan", "Frazier", "Grimwood", "Howard", "Ida", "Johnson", "Kerkman", "Libberton", "Marlow", "Narcross", "Oxford", "Pearson", "Questead", "Reeves", "Southerwood", "Taterfield", "Uren", "Vousdon", "Waddesworth", "Xanthopoulos", "Yarsley", "Zealand"};
    public static int age;
    public static bool married;
    public static string socialSecurity;
    public static string workSocialSecurity;
    
    //Address
    public static string address;
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

        address = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
        
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

        RandomizeW2();
    }

    void Randomize1040() {
        var rand = new Random();
        GameObject form1040Obj = Instantiate(form1040Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        IndividualTax formContents = form1040Obj.GetComponent<IndividualTax>();
        formContents.firstName = firstName[rand.Next(firstName.Length)];
        formContents.lastName = lastName[rand.Next(lastName.Length)];
        formContents.address = address;
        formContents.state = stateAbbreviations[rand.Next(stateAbbreviations.Length)];
        formContents.city = stateCities[formContents.state][rand.Next(stateCities[formContents.state].Length)];
        
        // socialSecurity
        // workAddress
        // workSocialSecurity
        // wages.ToString("N0")
        // tax.ToString("N0")
        // withheldSocialSecurity.ToString("N0")
        // withheldMedicare.ToString("N0") 
        // net.ToString("N0")
        ;
    }
    void RandomizeW2() {
        var rand = new Random();
        GameObject W2Obj = Instantiate(W2Prefab, new Vector3(0, 0, 0), Quaternion.identity);
        W2 formContents = W2Obj.GetComponent<W2>();
        formContents.fullEmployeeName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
        formContents.employeeAddress = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
        formContents.employeeSSN = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
        formContents.fullEmployerName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
        formContents.employerAddress = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
        formContents.employerSSN = String.Format("{0:000}-{0:00}-{0:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
        formContents.wages = wages;
        formContents.fedTax = tax;
        formContents.socialSecurity = withheldSocialSecurity;
        formContents.withheldMedicare = withheldMedicare;
        formContents.netWages = net;
    }
}
