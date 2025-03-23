// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class correct : MonoBehaviour
// {
//     SpriteRenderer screen;
//     Color red, green;
//     bool toggle;
//     // Start is called before the first frame update
//     void Start()
//     {
//         screen = GetComponent<SpriteRenderer>();
//         red = Color.red;
//         green = Color.green;
//         toggle = false;
//         this.gameObject.setActive(toggle);
//         toggle = !toggle;
//     }




//     void OnSuccess()
//     {
//         screen.color = green;
//         toggle = !toggle;
//         this.gameObject.setActive(toggle);
//         if (shakeDuration > 0)
//         {
//             shakeDuration -= Time.deltaTime * dampingSpeed;
//         }
//         else
//         {
//             shakeDuration = 0f;
//             transform.localPosition = initialPosition;
//         }
//     }
// }
