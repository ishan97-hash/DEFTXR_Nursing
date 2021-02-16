using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReplace : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "NGTube_Grabbable")
        {

            this.gameObject.SetActive(false);
            go2.SetActive(false);

            go3.SetActive(true);
        }
    }
}
