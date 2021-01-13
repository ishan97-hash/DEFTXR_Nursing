using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneA_GameManager : MonoBehaviour
{
    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField]
    private bool[] ActionsCompleted = {false};

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Guides;

    [SerializeField]
    private AudioSource audioSource;

    // Model of Patient lying on Bed
    [SerializeField]
    private GameObject patient;

    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;


    // Grabbable Apparatus Eg. Scissor, Syringe
    /*[SerializeField]
    private OVRGrabbable grabbableObject1;
    [SerializeField]
    private OVRGrabbable grabbableObject2;
    [SerializeField]
    private OVRGrabbable grabbableObject3;
    [SerializeField]
    private OVRGrabbable grabbableObject4;*/

    [SerializeField]
    private GameObject grabbableObject1;
    [SerializeField]
    private GameObject grabbableObject2;
    [SerializeField]
    private GameObject grabbableObject3;
    [SerializeField]
    private GameObject grabbableObject4;

    [SerializeField]
    private GameObject laryngoscope;
    [SerializeField]
    private GameObject endotrachealTube;
    [SerializeField]
    private GameObject inflatingBag;
    [SerializeField]
    private GameObject syringe;




    private void Start()
    {
       
        InitializeDefaultData();

        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        // Introduction
        Debug.Log("playing vo1");
        audioSource.PlayOneShot(intro_VO[1]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);

        Debug.Log("playing vo2");
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);

        //Show Apparatus
        audioSource.PlayOneShot(intro_VO[3]);
        Guides[0].SetActive(false);
        Guides[1].SetActive(true);
        yield return new WaitForSeconds(intro_VO[3].length);

        audioSource.PlayOneShot(intro_VO[4]);
        Guides[1].SetActive(false);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[4].length);

        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);

        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);

        //Step 1 Beginning
        audioSource.PlayOneShot(intro_VO[7]);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[7].length);
        //Enable Laryngoscope
        laryngoscope.GetComponent<BoxCollider>().enabled = true;
        laryngoscope.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if(laryngoscope.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;
            //grabbableObject2.AddComponent<OVRGrabbable>();
            //grabbableObject2.GetComponent<OVRGrabbable>().enabled = true;


        }
        /*if (grabbableObject2.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;
            //grabbableObject3.AddComponent<OVRGrabbable>();
            // grabbableObject3.GetComponent<OVRGrabbable>().enabled = true;
            //grabbableObject3.GetComponent<BoxCollider>().enabled = true;
            //grabbableObject3.GetComponent<Rigidbody>().useGravity = true;
        }
        if (grabbableObject3.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;
            // grabbableObject4.AddComponent<OVRGrabbable>();
            // grabbableObject4.GetComponent<OVRGrabbable>().enabled = true;
            //grabbableObject4.GetComponent<BoxCollider>().enabled = true;
            //grabbableObject4.GetComponent<Rigidbody>().useGravity = true;
        }
        if (grabbableObject4.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[4] = true;

        }*/
    }

    void InitializeDefaultData()
    {
        // Disable all models
        //patient.SetActive(false);

        for (int i=0; i<Guides.Count; i++)
        {
            Guides[i].SetActive(false);
        }

        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        laryngoscope.GetComponent<BoxCollider>().enabled = false;
        endotrachealTube.GetComponent<BoxCollider>().enabled = false;
        syringe.GetComponent<BoxCollider>().enabled = false;
        inflatingBag.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        laryngoscope.GetComponent<Rigidbody>().useGravity = false;
        endotrachealTube.GetComponent<Rigidbody>().useGravity = false;
        syringe.GetComponent<Rigidbody>().useGravity = false;
        inflatingBag.GetComponent<Rigidbody>().useGravity = false;

        /*Destroy(grabbableObject2.GetComponent<OVRGrabbable>());
        Destroy(grabbableObject3.GetComponent<OVRGrabbable>());
        Destroy(grabbableObject4.GetComponent<OVRGrabbable>());*/

        /*grabbableObject1.AddComponent<OVRGrabbable>();
        grabbableObject1.GetComponent<OVRGrabbable>().enabled = true;

        grabbableObject2.AddComponent<OVRGrabbable>();
        grabbableObject2.GetComponent<OVRGrabbable>().enabled = true;*/
    }


    IEnumerator Step1()
    {

        // Step 1
        Guides[3].SetActive(false);
        Guides[4].SetActive(true);
        yield return new WaitForSeconds(3f);
        Guides[4].SetActive(false);
        Guides[5].SetActive(true);
        yield return new WaitForSeconds(3f);


        //Enable Next GrabbableObject
        //grabbableObject2.GetComponent<BoxCollider>().enabled = true;
        //grabbableObject2.GetComponent<Rigidbody>().useGravity = true;

    }

     IEnumerator Step2()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[1]);
        Guides[0].SetActive(false);
        Guides[1].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);

        //Enable Next GrabbableObject
        //grabbableObject3.GetComponent<BoxCollider>().enabled = true;
        //grabbableObject3.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step3()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[2]);
        Guides[1].SetActive(false);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[2].length);

        //Enable Next GrabbableObject
        //grabbableObject4.GetComponent<BoxCollider>().enabled = true;
        //grabbableObject4.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step4()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[3]);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[3].length);

        //Enable Next GrabbableObject
    }
}
