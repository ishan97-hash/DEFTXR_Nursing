using UnityEngine;
using System.Collections;
using System;

public class myGrabbableObtManager : MonoBehaviour
{
    public GameObject myGrabbaleObj;


    public void OnTriggerEnter(Collider other)
    {
        if (String.Compare(other.gameObject.name, "touchInput") == 0)
        {
            Debug.Log("workinggggg");

            myGrabbaleObj.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("not working");
        }
    }

 
}
