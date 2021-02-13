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
        if (col.gameObject.name == "go2")
        {
            Destroy(this.gameObject);
            Destroy(go2);

            go3.SetActive(true);
        }
    }
}
