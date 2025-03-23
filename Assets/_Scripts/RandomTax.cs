// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Random = System.Random;

// public class RandomTax : MonoBehaviour
// {
//     public GameObject W2Prefab;
//     public GameObject form1040Prefab;

//     //Basic info
//     public static string[] firstName = {"Aaron", "Bob", "Christian", "Donald", "Earl", "Felicia", "Gerald", "Harry", "Isadore", "Johnny", "Kim", "Larry", "Monique", "Nate", "Oliver", "Perry", "Quinn", "Rachel", "Sally", "Toddy", "Ursula", "Veronica", "Wally", "Xavier", "Yelena", "Zoe"};
//     public static string[] lastName = {"Anderson", "Barnes", "Cason", "Dewey", "Eagan", "Frazier", "Grimwood", "Howard", "Ida", "Johnson", "Kerkman", "Libberton", "Marlow", "Narcross", "Oxford", "Pearson", "Questead", "Reeves", "Southerwood", "Taterfield", "Uren", "Vousdon", "Waddesworth", "Xanthopoulos", "Yarsley", "Zealand"};
//     public static string name;
//     public static string employerName;
//     public static int age;
//     public static bool married;
//     public static string socialSecurity;
//     public static string workSocialSecurity;
    
//     //Address
//     public static string address;
//     public static string workAddress;
//     public static string[] streetName = {"Amiens", "Blue", "Chester", "Dutch", "East", "Greenwood", "Highland", "Inverted", "James", "Springfield", "Lake", "Main", "North", "Oak", "Peppermint", "Quarter", "Roundhouse", "South", "Town", "Underside", "Plank", "Village", "West", "Martin Luther King", "Yellow", "Daniel Donze", "Andrew Webb", "John Luke Denny", "Zigzag"};
//     public static string[] streetType = {"Alley", "Avenue", "Street", "Court", "Drive", "Lane", "Plaza", "Road", "Way"};

//     string[] stateAbbreviations = new string[]
//     {
//         "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
//         "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
//         "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
//         "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
//         "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
//     };
//         Dictionary<string, string[]> stateCities = new Dictionary<string, string[]>
//     {
//         { "AL", new string[] { "Birmingham", "Montgomery", "Mobile", "Huntsville", "Tuscaloosa" } },
//         { "AK", new string[] { "Anchorage", "Fairbanks", "Juneau", "Sitka", "Wasilla" } },
//         { "AZ", new string[] { "Phoenix", "Tucson", "Mesa", "Chandler", "Glendale" } },
//         { "AR", new string[] { "Little Rock", "Fort Smith", "Fayetteville", "Springdale", "Jonesboro" } },
//         { "CA", new string[] { "Los Angeles", "San Diego", "San Jose", "San Francisco", "Fresno" } },
//         { "CO", new string[] { "Denver", "Colorado Springs", "Aurora", "Fort Collins", "Lakewood" } },
//         { "CT", new string[] { "Bridgeport", "New Haven", "Stamford", "Hartford", "Waterbury" } },
//         { "DE", new string[] { "Wilmington", "Dover", "Newark", "Middletown", "Smyrna" } },
//         { "FL", new string[] { "Jacksonville", "Miami", "Tampa", "Orlando", "St. Petersburg" } },
//         { "GA", new string[] { "Atlanta", "Augusta", "Columbus", "Savannah", "Athens" } },
//         { "HI", new string[] { "Honolulu", "Pearl City", "Hilo", "Kailua", "Waipahu" } },
//         { "ID", new string[] { "Boise", "Meridian", "Nampa", "Idaho Falls", "Pocatello" } },
//         { "IL", new string[] { "Chicago", "Aurora", "Rockford", "Joliet", "Naperville" } },
//         { "IN", new string[] { "Indianapolis", "Fort Wayne", "Evansville", "South Bend", "Carmel" } },
//         { "IA", new string[] { "Des Moines", "Cedar Rapids", "Davenport", "Sioux City", "Iowa City" } },
//         { "KS", new string[] { "Wichita", "Overland Park", "Kansas City", "Topeka", "Olathe" } },
//         { "KY", new string[] { "Louisville", "Lexington", "Bowling Green", "Owensboro", "Covington" } },
//         { "LA", new string[] { "New Orleans", "Baton Rouge", "Shreveport", "Lafayette", "Lake Charles" } },
//         { "ME", new string[] { "Portland", "Lewiston", "Bangor", "South Portland", "Auburn" } },
//         { "MD", new string[] { "Baltimore", "Frederick", "Rockville", "Gaithersburg", "Bowie" } },
//         { "MA", new string[] { "Boston", "Worcester", "Springfield", "Cambridge", "Lowell" } },
//         { "MI", new string[] { "Detroit", "Grand Rapids", "Warren", "Sterling Heights", "Ann Arbor" } },
//         { "MN", new string[] { "Minneapolis", "Saint Paul", "Rochester", "Duluth", "Bloomington" } },
//         { "MS", new string[] { "Jackson", "Gulfport", "Southaven", "Hattiesburg", "Biloxi" } },
//         { "MO", new string[] { "Kansas City", "Saint Louis", "Springfield", "Independence", "Columbia" } },
//         { "MT", new string[] { "Billings", "Missoula", "Great Falls", "Bozeman", "Butte" } },
//         { "NE", new string[] { "Omaha", "Lincoln", "Bellevue", "Grand Island", "Kearney" } },
//         { "NV", new string[] { "Las Vegas", "Henderson", "Reno", "North Las Vegas", "Sparks" } },
//         { "NH", new string[] { "Manchester", "Nashua", "Concord", "Derry", "Dover" } },
//         { "NJ", new string[] { "Newark", "Jersey City", "Paterson", "Elizabeth", "Edison" } },
//         { "NM", new string[] { "Albuquerque", "Las Cruces", "Rio Rancho", "Santa Fe", "Roswell" } },
//         { "NY", new string[] { "New York City", "Buffalo", "Rochester", "Yonkers", "Syracuse" } },
//         { "NC", new string[] { "Charlotte", "Raleigh", "Greensboro", "Durham", "Winston-Salem" } },
//         { "ND", new string[] { "Fargo", "Bismarck", "Grand Forks", "Minot", "West Fargo" } },
//         { "OH", new string[] { "Columbus", "Cleveland", "Cincinnati", "Toledo", "Akron" } },
//         { "OK", new string[] { "Oklahoma City", "Tulsa", "Norman", "Broken Arrow", "Lawton" } },
//         { "OR", new string[] { "Portland", "Eugene", "Salem", "Gresham", "Hillsboro" } },
//         { "PA", new string[] { "Philadelphia", "Pittsburgh", "Allentown", "Erie", "Reading" } },
//         { "RI", new string[] { "Providence", "Warwick", "Cranston", "Pawtucket", "East Providence" } },
//         { "SC", new string[] { "Columbia", "Charleston", "North Charleston", "Mount Pleasant", "Rock Hill" } },
//         { "SD", new string[] { "Sioux Falls", "Rapid City", "Aberdeen", "Brookings", "Watertown" } },
//         { "TN", new string[] { "Nashville", "Memphis", "Knoxville", "Chattanooga", "Clarksville" } },
//         { "TX", new string[] { "Houston", "San Antonio", "Dallas", "Austin", "Fort Worth" } },
//         { "UT", new string[] { "Salt Lake City", "West Valley City", "Provo", "West Jordan", "Orem" } },
//         { "VT", new string[] { "Burlington", "South Burlington", "Rutland", "Barre", "Montpelier" } },
//         { "VA", new string[] { "Virginia Beach", "Norfolk", "Chesapeake", "Richmond", "Newport News" } },
//         { "WA", new string[] { "Seattle", "Spokane", "Tacoma", "Vancouver", "Bellevue" } },
//         { "WV", new string[] { "Charleston", "Huntington", "Parkersburg", "Morgantown", "Wheeling" } },
//         { "WI", new string[] { "Milwaukee", "Madison", "Green Bay", "Kenosha", "Racine" } },
//         { "WY", new string[] { "Cheyenne", "Casper", "Laramie", "Gillette", "Rock Springs" } }
//     };

//     //Incomes
//     public static int wages;
//     public static int tax;
//     public static int withheldSocialSecurity;
//     public static int withheldMedicare;
//     public static int net;

//     //Outputs
//     public static string nameOutput;
//     public static string employerNameOutput;
//     public static int ageOutput;
//     public static string addressOutput;
//     public static string workAddressOutput;
//     public static string socialSecurityOutput;
//     public static string workSocialSecurityOutput;
//     public static int wagesOutput;
//     public static int taxOutput;
//     public static int withheldSSOutput;
//     public static int withheldMedicareOutput;
//     public static int netOutput;

//     //Correct or Incorrect
//     public static bool nameCorrect = true;
//     public static bool employerNameCorrect = true;
//     public static bool ageCorrect = true;
//     public static bool addressCorrect = true;
//     public static bool workAddressCorrect = true;
//     public static bool socialSecurityCorrect = true;
//     public static bool workSocialSecurityCorrect = true;
//     public static bool wagesCorrect = true;
//     public static bool taxCorrect = true;
//     public static bool withheldSSCorrect = true;
//     public static bool withheldMedicareCorrect = true;
//     public static bool netCorrect = true;

//     public static Random random = new Random();

//     // Start is called before the first frame update
//     void Start()
//     {
//         Randomization();
//         MessUp();
//         GenerateW2();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
    
//     public static string[] Randomization() {
//         var rand = new Random(Guid.NewGuid().GetHashCode());
//         name = (firstName[rand.Next(firstName.Length)]) + " " + (lastName[rand.Next(lastName.Length)]);
//         employerName = (firstName[rand.Next(firstName.Length)]) + " " + (lastName[rand.Next(lastName.Length)]);
//         age = rand.Next(18, 76);
//         socialSecurity = String.Format("{0:000}-{1:00}-{2:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));
//         workSocialSecurity = String.Format("{0:000}-{1:00}-{2:0000}", rand.Next(1000), rand.Next(100), rand.Next(10000));

//         address = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];
//         workAddress = rand.Next(1000).ToString() + " " + streetName[rand.Next(streetName.Length)] + " " + streetType[rand.Next(streetType.Length)];

//         if(rand.Next(2) == 0) {
//             married = false;
//         }
//         else {
//             married = true;
//         }

//         wages = rand.Next(10000, 1000000);
//         tax = rand.Next(0, wages/10);
//         withheldSocialSecurity = rand.Next(0, wages/10);
//         withheldMedicare = rand.Next(0, wages/10);
//         net = wages - tax - withheldSocialSecurity - withheldMedicare;

//         string[] dataSet = {name, age.ToString(), address, socialSecurity, workSocialSecurity, married.ToString(), wages.ToString("N0"), tax.ToString("N0"), withheldSocialSecurity.ToString("N0"), withheldMedicare.ToString("N0"), net.ToString("N0")};
//         return dataSet;
//     }

//     void Randomize1040() {
//         var rand = new Random();
//         GameObject form1040Obj = Instantiate(form1040Prefab, new Vector3(0, 0, 0), Quaternion.identity);
//         IndividualTax formContents = form1040Obj.GetComponent<IndividualTax>();
//         formContents.firstName = firstName[rand.Next(firstName.Length)];
//         formContents.lastName = lastName[rand.Next(lastName.Length)];
//         formContents.address = address;
//         formContents.state = stateAbbreviations[rand.Next(stateAbbreviations.Length)];
//         formContents.city = stateCities[formContents.state][rand.Next(stateCities[formContents.state].Length)];
//         formContents.SSN = socialSecurity;

//         InformationManager.instance.setTrue1040(formContents.firstName, formContents.lastName, formContents.address, formContents.city, formContents.state, formContents.SSN, "the", new string[]{"the"});
//     }

//     void GenerateW2() {
//         var rand = new Random();
//         GameObject W2Obj = Instantiate(W2Prefab, new Vector3(0, 0, 0), Quaternion.identity);
//         W2 formContents = W2Obj.GetComponent<W2>();
//         formContents.fullEmployeeName = nameOutput;
//         formContents.employeeAddress = addressOutput;
//         formContents.employeeSSN = socialSecurityOutput;
//         formContents.fullEmployerName = employerName;
//         formContents.employerAddress = workAddress;
//         formContents.employerSSN = workSocialSecurityOutput;
//         formContents.wages = wagesOutput;
//         formContents.fedTax = taxOutput;
//         formContents.socialSecurity = withheldSSOutput;
//         formContents.withheldMedicare = withheldMedicareOutput;
//         formContents.netWages = netOutput;
//     }

//     void MessUp() {
//         var rand = new Random();

//         nameOutput = name;
//         if(rand.Next(2) == 0) {
//             nameCorrect = false;
//             nameOutput = nameOutput.Replace(nameOutput[rand.Next(0, nameOutput.Length)].ToString(), "");
//         }
//         Debug.Log(("Name: " + nameOutput + " (" + nameCorrect + ")"));

//         employerNameOutput = employerName;
//         if(rand.Next(2) == 0) {
//             employerNameCorrect = false;
//             employerNameOutput = employerNameOutput.Replace(employerNameOutput[rand.Next(0, employerNameOutput.Length)].ToString(), "");
//         }
//         Debug.Log(("Employer Name: " + employerNameOutput + " (" + employerNameCorrect + ")"));

//         ageOutput = age;
//         if(rand.Next(2) == 0) {
//             ageCorrect = false;
//             ageOutput = ageOutput + rand.Next(-5, 5);
//         }
//         Debug.Log(("Age: " + ageOutput + " (" + ageCorrect + ")"));

//         addressOutput = address;
//         if(rand.Next(2) == 0) {
//             addressCorrect = false;
//             addressOutput = addressOutput.Replace(addressOutput[rand.Next(0, addressOutput.Length)].ToString(), "");
//         }
//         Debug.Log(("Address: " + addressOutput + " (" + addressCorrect + ")"));

//         workAddressOutput = workAddress;
//         if(rand.Next(2) == 0) {
//             workAddressCorrect = false;
//             workAddressOutput = workAddressOutput.Replace(workAddressOutput[rand.Next(0, workAddressOutput.Length)].ToString(), "");
//         }
//         Debug.Log(("Address: " + workAddressOutput + " (" + workAddressCorrect + ")"));

//         socialSecurityOutput = socialSecurity;
//         if(rand.Next(2) == 0) {
//             socialSecurityCorrect = false;
//             while(socialSecurityOutput == socialSecurity) {
//                 socialSecurityOutput = socialSecurityOutput.Replace(socialSecurityOutput[rand.Next(0, socialSecurityOutput.Length)].ToString(), rand.Next(0, 10).ToString());
//             }
//         }
//         Debug.Log("Social Security: " + socialSecurityOutput + " (" + socialSecurityCorrect + ")");

//         workSocialSecurityOutput = workSocialSecurity;
//         if(rand.Next(2) == 0) {
//             workSocialSecurityCorrect = false;
//             while (workSocialSecurityOutput == workSocialSecurity) {
//                 workSocialSecurityOutput = workSocialSecurityOutput.Replace(workSocialSecurityOutput[rand.Next(0, workSocialSecurityOutput.Length)].ToString(), rand.Next(0, 10).ToString());
//             }
//         }
//         Debug.Log("Work Social Security: " + workSocialSecurityOutput + " (" + workSocialSecurityCorrect + ")");

//         wagesOutput = wages;
//         if(rand.Next(2) == 0) {
//             wagesCorrect = false;
//             while(wagesOutput == wages) {
//                 wagesOutput = wagesOutput + rand.Next(-5, 5);
//             }
//         }
//         Debug.Log(("Wages: " + wagesOutput + " (" + wagesCorrect + ")"));

//         taxOutput = tax;
//         if(rand.Next(2) == 0) {
//             taxCorrect = false;
//             while(taxOutput == tax) {
//                 taxOutput = taxOutput + rand.Next(-5, 5);
//             }
//         }
//         Debug.Log(("Taxes: " + taxOutput + " (" + taxCorrect + ")"));

//         withheldSSOutput = withheldSocialSecurity;
//         if(rand.Next(2) == 0) {
//             withheldSSCorrect = false;
//             while(withheldSSOutput == withheldSocialSecurity) {
//                 withheldSSOutput = withheldSSOutput + rand.Next(-5, 5);
//             }
//         }
//         Debug.Log(("Withheld Social Security: " + withheldSSOutput + " (" + withheldSSCorrect + ")"));

//         withheldMedicareOutput = withheldMedicare;
//         if(rand.Next(2) == 0) {
//             withheldMedicareCorrect = false;
//             while(withheldMedicareOutput == withheldMedicare) {
//                 withheldMedicareOutput = withheldMedicareOutput + rand.Next(-5, 5);
//             }
//         }
//         Debug.Log(("Withheld Medicare: " + withheldMedicareOutput + " (" + withheldMedicareCorrect + ")"));

//         netOutput = net;
//         netOutput = wagesOutput - taxOutput - withheldSSOutput - withheldMedicareOutput;
//         if(netOutput != net) {
//             netCorrect = false;
//         }
//         Debug.Log(("Net: " + netOutput + " (" + netCorrect + ")"));
//     }
// }