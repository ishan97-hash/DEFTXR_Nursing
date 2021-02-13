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

    // Grabbable Apparatus
    [SerializeField]
    private GameObject laryngoscope;
    [SerializeField]
    private GameObject endotrachealTube;
    [SerializeField]
    private GameObject inflatingBag;
    [SerializeField]
    private GameObject syringe;

    
    private bool step1Completed = false;


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
        PlayGuide(1);
        yield return new WaitForSeconds(intro_VO[3].length);

        audioSource.PlayOneShot(intro_VO[4]);
        PlayGuide(2);
        yield return new WaitForSeconds(intro_VO[4].length);

        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);

        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);

        //Step 1 Beginning
        audioSource.PlayOneShot(intro_VO[7]);
        PlayGuide(3);
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

        }
        if (endotrachealTube.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[2] = true;
        }
        if (syringe.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step5());
            ActionsCompleted[3] = true;
        }
        if (laryngoscope.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false && step1Completed == true)
        {
            StartCoroutine(Step7());
            ActionsCompleted[4] = true;
        }
        if (inflatingBag.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[5] == false)
        {
            StartCoroutine(Step9());
            ActionsCompleted[5] = true;
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


    void PlayGuide(int guideNo)
    {       
        if(guideNo >= 0)
        {
            //Disable previous guide
            Guides[guideNo - 1].SetActive(false);
            //Enable current guide
            Guides[guideNo].SetActive(true);
        }
        else
            Guides[guideNo].SetActive(true);
    }

    IEnumerator Step1()
    {
        // Step 1 Pick laryngoscope and insert
        PlayGuide(4);
        yield return new WaitForSeconds(3f);
        PlayGuide(5);
        yield return new WaitForSeconds(3f);

        step1Completed = true;
        

        StartCoroutine(Step2());
    }

     IEnumerator Step2()
    {
        // Step 2 Raise Epiglottis
        audioSource.PlayOneShot(intro_VO[8]);
        PlayGuide(6);
        yield return new WaitForSeconds(intro_VO[8].length);


        //Raise Epiglottis
        yield return new WaitForSeconds(3f);

        StartCoroutine(Step3());
    }

    IEnumerator Step3()
    {
        // Step 3  Highlight and pick Endotracheal tube
        audioSource.PlayOneShot(intro_VO[9]);
        PlayGuide(7);
        yield return new WaitForSeconds(intro_VO[9].length);

        //Enable Endotracheal Tube
        endotrachealTube.GetComponent<BoxCollider>().enabled = true;
        endotrachealTube.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step4()
    {
        // Step 4 Insert endotracheal tube. Pick syringe.
        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);

        PlayGuide(8);
        yield return new WaitForSeconds(5f);

        //enable Syringe
        syringe.GetComponent<BoxCollider>().enabled = true;
        syringe.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step5()
    {
        // Step 5 Blow balloon
        audioSource.PlayOneShot(intro_VO[11]);
        PlayGuide(9);
        yield return new WaitForSeconds(intro_VO[11].length);
        yield return new WaitForSeconds(3);

        StartCoroutine(Step6());
    }

    IEnumerator Step6()
    {
        // Step 6 Remove Laryngoscope 1/2
        audioSource.PlayOneShot(intro_VO[12]);
        PlayGuide(10);
        yield return new WaitForSeconds(intro_VO[12].length);
    }

    IEnumerator Step7()
    {
        // Step 7 Remove Laryngoscope 2/2
        audioSource.PlayOneShot(intro_VO[13]);
        PlayGuide(11);
        yield return new WaitForSeconds(intro_VO[13].length);

        StartCoroutine(Step8());
    }

    IEnumerator Step8()
    {
        // Step 8 highlight Inflating Bag
        audioSource.PlayOneShot(intro_VO[14]);
        PlayGuide(12);
        yield return new WaitForSeconds(intro_VO[13].length);

        // Enable inflating Bag
        inflatingBag.GetComponent<BoxCollider>().enabled = true;
        inflatingBag.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step9()
    {
        // Step 9 Blow Inflating Bag
        PlayGuide(13);
        yield return new WaitForSeconds(3f);
        //blow bag
        //
        audioSource.PlayOneShot(intro_VO[15]);
        PlayGuide(14);
        yield return new WaitForSeconds(intro_VO[15].length);

        //Play Lung Sound (NOT ADDED YET)
        //
        PlayGuide(15);
        yield return new WaitForSeconds(3);

        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);

        audioSource.PlayOneShot(intro_VO[17]);
        yield return new WaitForSeconds(intro_VO[17].length);

        StartCoroutine(step10());
    }

    IEnumerator step10()
    {
        // Step 10 Attach endo-tube ti mech. ventilator

        audioSource.PlayOneShot(intro_VO[18]);
        PlayGuide(16);
        yield return new WaitForSeconds(intro_VO[18].length);

        audioSource.PlayOneShot(intro_VO[19]);
        yield return new WaitForSeconds(intro_VO[19].length);
    }
}
