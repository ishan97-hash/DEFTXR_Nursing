using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTZone_A : MonoBehaviour
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




    [SerializeField]
    private GameObject biohazard_Bag;
    [SerializeField]
    private GameObject BloodTubing;
    [SerializeField]
    private GameObject BloodProduct;
    [SerializeField]
    private GameObject NS_Bag;
    [SerializeField]
    private GameObject saline_flush;
    [SerializeField]
    private GameObject gloves;




    private void Start()
    {

        InitializeDefaultData();

        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        // Introduction
        Debug.Log("Play VO1");
        audioSource.PlayOneShot(intro_VO[1]);
        // Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);


        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);

        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);

        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);


        //Step 1
        Debug.Log("Play VO2");
        audioSource.PlayOneShot(intro_VO[5]);
        PlayGuide(0);                                               //Playing Hand Washing Animation.
        yield return new WaitForSeconds(intro_VO[5].length);

        Debug.Log("Play VO3");
        audioSource.PlayOneShot(intro_VO[6]);
        PlayGuide(1);                         //Playing Animation of procedure area getting cobered with curtains.
        yield return new WaitForSeconds(intro_VO[6].length);


        //Step 2: Show Equipments
        Debug.Log("Play VO4");
        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);

        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);

        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);



        // Step 3 : Proper Body Mechanism
        Debug.Log("Play VO5");
        audioSource.PlayOneShot(intro_VO[10]);
        PlayGuide(2);    //Playing Animation of bed in semi-fold position and patient getting lie down on the back.
        yield return new WaitForSeconds(intro_VO[10].length);


        // Step 4: 

        Debug.Log("Play VO6");
        audioSource.PlayOneShot(intro_VO[11]);
        PlayGuide(3);                           // Playing Animation of transparent hands wearing gloves.
        yield return new WaitForSeconds(intro_VO[11].length);
        gloves.GetComponent<BoxCollider>().enabled = true;
        gloves.GetComponent<Rigidbody>().useGravity = true;


    }

    void Update()
    {
        if (gloves.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[1] = true;


        }

    }
    void PlayGuide(int guideno)
    {
        if (guideno >= 0)
        {
            Guides[guideno - 1].SetActive(false);
            Guides[guideno].SetActive(true);

        }
        else
        {
            Guides[guideno].SetActive(true);
        }

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
        gloves.GetComponent<BoxCollider>().enabled = false;
        BloodTubing.GetComponent<BoxCollider>().enabled = false;
        BloodProduct.GetComponent<BoxCollider>().enabled = false;
        NS_Bag.GetComponent<BoxCollider>().enabled = false;
        saline_flush.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        gloves.GetComponent<Rigidbody>().useGravity = false;
        BloodTubing.GetComponent<BoxCollider>().enabled = false;
        BloodProduct.GetComponent<BoxCollider>().enabled = false;
        NS_Bag.GetComponent<BoxCollider>().enabled = false;
        saline_flush.GetComponent<BoxCollider>().enabled = false;


    }


    IEnumerator Step4()
    {

        // Step 4
        PlayGuide(4); // Transparent Hand taking cannula from equipments and getting venous access.
        yield return new WaitForSeconds(3f);
    }

    IEnumerator Step5()
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


}
