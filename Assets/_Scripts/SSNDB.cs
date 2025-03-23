using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Identity {
    public string name;
    public string age;
    public string address;
    public string city;
    public string state;
    public string SSN; // not for display but for passing to fileSet

    public Identity(string name, string age, string address, string city, string state, string SSN) {
        this.name = name;
        this.age = age;
        this.address = address;
        this.city = city;
        this.state = state;
        this.SSN = SSN;
    }
}

public class SSNDB : MonoBehaviour
{
    public static SSNDB instance;
    Dictionary<string, Identity> adultSet = new Dictionary<string, Identity>();
    Dictionary<string, Identity> childSet = new Dictionary<string, Identity>();
    private static string[] firstName = {"Aaron", "Alex", "Bob", "Belle", "Christian", "Christina", "Donald", "Earl", "Felicia", "Frank", "Gerald", "Georgia", "Harry", "Isabella", "Johnny", "Jessica", "Kim", "Larry", "Monique", "Martin", "Nate", "Oliver", "Olivia", "Perry", "Quinn", "Rachel", "Ronald", "Sally", "Sarah", "Toddy", "Ursula", "Veronica", "Wally", "William", "Xavier", "Helena", "Zoe", "Ricky", "Mikey", "Rohan"};
    private static string[] lastName = {"Anderson", "Barnes", "Wu", "Dewey", "Parker", "Frazier", "Phillips", "Howard", "Robinson", "Johnson", "Kirkman", "Lopez", "Martin", "Sanchez", "Oxford", "Pearson", "Clark", "Reeves", "Smith", "Thomas", "Uren", "Zhang", "Williams", "X", "Yangley", "Narayanan", "Liang", "Durgham", "Brescher"};
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
    public int adultSetSize = 40;
    public int childSetSize = 20;
    
    List<string> adultSSNs = new List<string>();
    List<string> childSSNs = new List<string>();

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this);
        } else {
            instance = this;
        }
    
        System.Random rand = new System.Random();
        // generate adults
        for (int i = 0; i < adultSetSize; i++) {
            string fullName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
            string age = rand.Next(18, 76).ToString();
            string address = rand.Next(120, 9658).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
            string state = stateAbbreviations[rand.Next(stateAbbreviations.Length)];
            string city = stateCities[state][rand.Next(stateCities[state].Length)];
            string SSN = $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}";
            Identity identity = new Identity(fullName, age, address, city, state, SSN);
            adultSSNs.Add(SSN);
            adultSet.Add(SSN, identity);
        }

        // generate children
        for (int i = 0; i < childSetSize; i++) {
            string fullName = firstName[rand.Next(firstName.Length)] + " " + lastName[rand.Next(lastName.Length)];
            string age = rand.Next(0, 18).ToString();
            string address = rand.Next(120, 9658).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
            string state = stateAbbreviations[rand.Next(stateAbbreviations.Length)];
            string city = stateCities[state][rand.Next(stateCities[state].Length)];
            string SSN = $"{rand.Next(100, 1000)}-{rand.Next(10, 100)}-{rand.Next(1000, 10000)}";
            Identity identity = new Identity(fullName, age, address, city, state, SSN);
            childSSNs.Add(SSN);
            childSet.Add(SSN, identity);
        }
    }

    public Identity getAdult() {
        System.Random rand = new System.Random();
        return adultSet[adultSSNs[rand.Next(0, adultSSNs.Count)]];
    }

    public Identity getChild() {
        System.Random rand = new System.Random();
        return childSet[childSSNs[rand.Next(0, childSSNs.Count)]];
    }

    public Identity getPerson() {
        System.Random rand = new System.Random();
        if (rand.Next(0, 100) < 80) { //children are weighted much much higher
            return childSet[childSSNs[rand.Next(0, childSSNs.Count)]];
        } else {
            return adultSet[adultSSNs[rand.Next(0, adultSSNs.Count)]];
        }
    }
}
