using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int layerMask = 1 << 7;  // Interactable

        if (Physics.Raycast( transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.2f, layerMask))
        {
            if (hit.transform.CompareTag("Yummy"))
            {
                Debug.Log("YUM YUM");
                hit.transform.GetComponent<IEatable>().Eat();
                
            }
            else if (hit.transform.CompareTag("NotGood"))
            {
                Debug.Log("ew");
            }
            Debug.DrawRay( transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }

    }
    
}
