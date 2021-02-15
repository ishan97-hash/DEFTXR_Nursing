using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class Pose : MonoBehaviour
{
    public Transform handpos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = handpos.position;
    }
}
