using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Panel;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Panel.SetActive(true);
            UI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("Pressed Key");
        }
    }
    public void closeUI()
    {
        Panel.SetActive(false);
        UI.SetActive(false);
        Time.timeScale = 1;
    }
}
