using UnityEngine;
using System.Collections;

public class TapeCollision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SmallTape_Highlighted")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);      
        }
    }
}
