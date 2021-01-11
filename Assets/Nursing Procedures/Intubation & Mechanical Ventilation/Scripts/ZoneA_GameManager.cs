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
    [SerializeField]
    private OVRGrabbable grabbableObject1;
    [SerializeField]
    private OVRGrabbable grabbableObject2;
    [SerializeField]
    private OVRGrabbable grabbableObject3;
    [SerializeField]
    private OVRGrabbable grabbableObject4;

    private void Start()
    {
        InitializeDefaultData();
        //StartCoroutine(Introduction());
    }

    void Update()
    {
        if(grabbableObject1.isGrabbed == true && ActionsCompleted[1] == false)
        {
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;
            grabbableObject2.GetComponent<BoxCollider>().enabled = true;
        }
        if (grabbableObject2.isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;
            grabbableObject3.GetComponent<BoxCollider>().enabled = true;
        }
        if (grabbableObject3.isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;
            grabbableObject4.GetComponent<BoxCollider>().enabled = true;
        }
        if (grabbableObject4.isGrabbed == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[4] = true;
        }
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
        grabbableObject2.GetComponent<BoxCollider>().enabled = false;
        grabbableObject3.GetComponent<BoxCollider>().enabled = false;
        grabbableObject4.GetComponent<BoxCollider>().enabled = false;
    }

    IEnumerator Step1()
    {

        // Step 1
            audioSource.PlayOneShot(intro_VO[0]);
            Guides[0].SetActive(true);
            yield return new WaitForSeconds(intro_VO[0].length);

    }

     IEnumerator Step2()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[1]);
        Guides[1].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);
    }

    IEnumerator Step3()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[2]);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[2].length);
    }

    IEnumerator Step4()
    {
        // Step 2
        audioSource.PlayOneShot(intro_VO[3]);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[3].length);
    }
}
