using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_GameManager : MonoBehaviour
{
    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField]
    private bool[] ActionsCompleted = { false };

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

    // Grababble Apparatus
    [SerializeField]
    private GameObject NASOGASTRIC_TUBE;
    [SerializeField]
    private GameObject FT_NG_TUBE;
    [SerializeField]
    private GameObject WATER_SOLUBLE_LUBRICANT;
    [SerializeField]
    private GameObject GLASS_OF_WATER;
    [SerializeField]
    private GameObject TAPE;
    [SerializeField]
    private GameObject SYRINGE;
    [SerializeField]
    private GameObject TOWEL;
    [SerializeField]
    private GameObject EMESIS_BASIN;
    [SerializeField]
    private GameObject STETHOSCOPE;
    [SerializeField]
    private GameObject CLEAN_GLOVE;
    [SerializeField]
    private GameObject FLASHLIGHT;
    [SerializeField]
    private GameObject SCISSOR;




    private void Start()
    {

        InitializeDefaultData();

        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        // Introduction
        Debug.Log("playing vo1");
        audioSource.PlayOneShot(intro_VO[0]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[0].length);

        audioSource.PlayOneShot(intro_VO[1]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);

        Debug.Log("playing vo2");
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(2f);

        audioSource.PlayOneShot(intro_VO[3]);
        Guides[0].SetActive(false);
        Guides[1].SetActive(true);
        yield return new WaitForSeconds(intro_VO[3].length);
        yield return new WaitForSeconds(2f);

        //Show Apparatus
        audioSource.PlayOneShot(intro_VO[4]);
        Guides[1].SetActive(false);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);

        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(intro_VO[7]);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[7].length);
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);

        //Enable NASOGASTRIC_TUBE
        NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = true;
        NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if (NASOGASTRIC_TUBE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;
            //grabbableObject2.AddComponent<OVRGrabbable>();
            //grabbableObject2.GetComponent<OVRGrabbable>().enabled = true;


        }
        if (TAPE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[2] = true;
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

        for (int i = 0; i < Guides.Count; i++)
        {
            Guides[i].SetActive(false);
        }

        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = false;
        FT_NG_TUBE.GetComponent<BoxCollider>().enabled = false;
        WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = false;
        GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = false;
        TAPE.GetComponent<BoxCollider>().enabled = false;
        SYRINGE.GetComponent<BoxCollider>().enabled = false;
        TOWEL.GetComponent<BoxCollider>().enabled = false;
        EMESIS_BASIN.GetComponent<BoxCollider>().enabled = false;
        STETHOSCOPE.GetComponent<BoxCollider>().enabled = false;
        CLEAN_GLOVE.GetComponent<BoxCollider>().enabled = false;
        FLASHLIGHT.GetComponent<BoxCollider>().enabled = false;
        SCISSOR.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = false;
        FT_NG_TUBE.GetComponent<Rigidbody>().useGravity = false;
        WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = false;
        GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = false;
        TAPE.GetComponent<Rigidbody>().useGravity = false;
        SYRINGE.GetComponent<Rigidbody>().useGravity = false;
        TOWEL.GetComponent<Rigidbody>().useGravity = false;
        EMESIS_BASIN.GetComponent<Rigidbody>().useGravity = false;
        STETHOSCOPE.GetComponent<Rigidbody>().useGravity = false;
        CLEAN_GLOVE.GetComponent<Rigidbody>().useGravity = false;
        FLASHLIGHT.GetComponent<Rigidbody>().useGravity = false;
        SCISSOR.GetComponent<Rigidbody>().useGravity = false;


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
        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);

        StartCoroutine(Step2());
    }

    IEnumerator Step2()
    {
        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);
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
