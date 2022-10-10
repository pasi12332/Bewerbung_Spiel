using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private GameObject platformCol;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            platformCol.SetActive(true);
            Debug.Log("is drinne");
           
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            platformCol.SetActive(false);
            Debug.Log("is nicht drinne");
        }
    }
}
