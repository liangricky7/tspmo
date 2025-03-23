// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Lookup : MonoBehaviour
// {
//     /*string SSInput;
//     string name = RandomTax.name;
//     int age = RandomTax.age;
//     string address = RandomTax.address;
//      bool married = RandomTax.married;
//     string socialSecurity = RandomTax.socialSecurity;
//     string workSocialSecurity = RandomTax.socialSecurity;
//     int wages = RandomTax.wages;
//     int tax = RandomTax.tax;
//     int withheldSocialSecurity = RandomTax.withheldSocialSecurity;
//     int withheldMedicare = RandomTax.withheldMedicare;
//     int net = RandomTax.net; */
//     Dictionary<int, string[]> sets = new Dictionary<int, string[]>();
//     public static int index = 1;
//     // Start is called before the first frame update
//     void Start()
//     {
//         for(int i = 1; i <= 10; i++) {
//             sets.Add(i, RandomTax.Randomization());
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.DownArrow)) {
//             if(index < 10) {
//                 index++;
//                 outputData(sets[index]);
//             }
//         }
//         if (Input.GetKeyDown(KeyCode.UpArrow)) {
//             if(index > 1) {
//                 index--;
//                 outputData(sets[index]);
//             }
//         }
//     }

//     public void outputData(string[] set) {
//         string infoOutput = (set[0] + " is a " + set[1] + " year old with the social security number " + set[3] + ". \n" 
//                         + "They work at " + set[2] +" and their employer has a social security number of " + set[4] + ". \n"
//                         + "They've made $" + set[6] + " and owe $" + set[7] + " in taxes, along with $" + set[8] + " and $" + set[9] + " in withheld social security/medicare. \n"
//                         + "Their net should be $" + set[10] + ".").ToString();
//         Debug.Log(infoOutput);
//     }
// }
