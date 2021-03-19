using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.IsLastModule)
        {

            Debug.Log("Finish");
            other.GetComponent<Movement>().enabled = false;
        }
    }
}
