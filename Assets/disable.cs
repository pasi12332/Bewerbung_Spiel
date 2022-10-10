using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            this.gameObject.SetActive(false);
        }       
    }
}
