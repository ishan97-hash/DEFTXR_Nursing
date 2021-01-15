using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_GameManager : MonoBehaviour
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
    private bool[] stepscompleted= { false};



    [SerializeField]
    private GameObject biohazard_Bag;
    [SerializeField]
    private GameObject cannula;
    [SerializeField]
    private GameObject BloodProduct;
    [SerializeField]
    private GameObject NS_Bag;
    [SerializeField]
    private GameObject saline_flush;
    [SerializeField]
    private GameObject gloves;

    [SerializeField]
    private GameObject iv_tubing;


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


        //Step 1 Introuction.
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


        // Step 4: Assure patency of IV Line.

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
            stepscompleted[4] = true;

        }       

        if (cannula.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[2] = true;
            stepscompleted[5] = true;

        }

        if (saline_flush.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step5());
            ActionsCompleted[3] = true;
            stepscompleted[6] = true;

        }

        if (NS_Bag.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step6());
            ActionsCompleted[4] = true;
            stepscompleted[7] = true;

        }

        if (BloodProduct.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[5] == false)
        {
            StartCoroutine(Step7());
            ActionsCompleted[5] = true;
            stepscompleted[8] = true;

        }
        if (iv_tubing.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[6] == false)
        {
            StartCoroutine(Step8());
            ActionsCompleted[5] = true;
            stepscompleted[9] = true;
        }

        if (iv_tubing.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[7] == false)
        {
            StartCoroutine(Step9());
            ActionsCompleted[7] = true;
        }

        if (BloodProduct.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[8] == false)
        {
            StartCoroutine(Step10());
            ActionsCompleted[8] = true;
        }

        if (biohazard_Bag.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[9] == false)
        {
            StartCoroutine(Step11());
            ActionsCompleted[9] = true;
        }

        if (gloves.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[10] == false && stepscompleted[4] == true)
        {
            StartCoroutine(Step11());
            ActionsCompleted[10] = true;
        }

        if (cannula.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[11] == false && stepscompleted[5]==true )
        {
            StartCoroutine(Step11());
            ActionsCompleted[11] = true;
        }
        if (saline_flush.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[12] == false && stepscompleted[6] == true)
        {
            StartCoroutine(Step11());
            ActionsCompleted[12] = true;
        }

        if (NS_Bag.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[13] == false && stepscompleted[7] == true)
        {
            StartCoroutine(Step11());
            ActionsCompleted[13] = true;
        }

        if (BloodProduct.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[14] == false && stepscompleted[8] == true)
        {
            StartCoroutine(Step11());
            ActionsCompleted[14] = true;
        }

        if (iv_tubing.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[15] == false && stepscompleted[9] == true)
        {
            StartCoroutine(Step11());
            ActionsCompleted[15] = true;
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
        cannula.GetComponent<BoxCollider>().enabled = false;
        BloodProduct.GetComponent<BoxCollider>().enabled = false;
        NS_Bag.GetComponent<BoxCollider>().enabled = false;
        saline_flush.GetComponent<BoxCollider>().enabled = false;
        iv_tubing.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        gloves.GetComponent<Rigidbody>().useGravity = false;
        cannula.GetComponent<Rigidbody>().useGravity = false;
        BloodProduct.GetComponent<Rigidbody>().useGravity = false;
        NS_Bag.GetComponent<Rigidbody>().useGravity = false;
        saline_flush.GetComponent<Rigidbody>().useGravity = false;
        iv_tubing.GetComponent<Rigidbody>().useGravity = false;

    }


    IEnumerator Step4()
    {

        // Step 4 from storyboard
      
        Debug.Log("Play VO7");
        audioSource.PlayOneShot(intro_VO[12]);
        PlayGuide(4);                           // Playing Animation of transparent hand taking cannula from table of equipmenst and getting venous access.
        yield return new WaitForSeconds(intro_VO[12].length);
        cannula.GetComponent<BoxCollider>().enabled = true;
        cannula.GetComponent<Rigidbody>().useGravity = true;

    }

  

    IEnumerator Step5()
    {
        // Step 4 from storyboard
        audioSource.PlayOneShot(intro_VO[13]);
        PlayGuide(5);                               //Play Animation of Transparent hand picking saline flush bag and setting up to the IV Pole.

        yield return new WaitForSeconds(intro_VO[13].length);
        saline_flush.GetComponent<BoxCollider>().enabled = true;
        saline_flush.GetComponent<Rigidbody>().useGravity = true;


    }

    IEnumerator Step6()
    {
        // Step 4 from storyboard
        audioSource.PlayOneShot(intro_VO[14]);
        PlayGuide(6); //Play Animation of Transparent hand taking normal saline bag and prime tubing from table of equipments and showing connection between them.

        yield return new WaitForSeconds(intro_VO[14].length);
        NS_Bag.GetComponent<BoxCollider>().enabled = true;
        NS_Bag.GetComponent<Rigidbody>().useGravity = true;

        audioSource.PlayOneShot(intro_VO[15]);
        PlayGuide(7);   //Play Animation of Transparent hand showing how to close the saline roller clamp.

        yield return new WaitForSeconds(intro_VO[15].length);

    }

    IEnumerator Step7()
    {
        // Step 5 from storyboard
        audioSource.PlayOneShot(intro_VO[16]);
        PlayGuide(8); //Play Animation of Transparent hand picking up the blood bag and connecting it filling it completely.
        yield return new WaitForSeconds(intro_VO[16].length);
        BloodProduct.GetComponent<BoxCollider>().enabled = true;
        BloodProduct.GetComponent<Rigidbody>().useGravity = true;

        audioSource.PlayOneShot(intro_VO[17]);
        PlayGuide(9);   //Play Animation of Transparent hand opening the blood roller clamp and emptying it completely.


        yield return new WaitForSeconds(intro_VO[17].length);

    }


        IEnumerator Step8()
    {
        // Step 6 from storyboard
        audioSource.PlayOneShot(intro_VO[18]);
        PlayGuide(10); //Play Animation of Transparent hand  connecting the IV Tube to patients IV Access.
        yield return new WaitForSeconds(intro_VO[18].length);
        iv_tubing.GetComponent<BoxCollider>().enabled = true;
        iv_tubing.GetComponent<Rigidbody>().useGravity = true;

        audioSource.PlayOneShot(intro_VO[19]);
        PlayGuide(11);   //Play Animation of Transparent hand  connecting the IV Tube to patients IV Access.
        yield return new WaitForSeconds(intro_VO[19].length);

    }

    IEnumerator Step9()
    {
        // Step 7 from storyboard
        audioSource.PlayOneShot(intro_VO[20]);
        PlayGuide(11);                                   //Play Animation of Transparent hand  disconnecting the blood tubing and flushing the IV Line.
        yield return new WaitForSeconds(intro_VO[18].length);
        iv_tubing.GetComponent<BoxCollider>().enabled = true;
        iv_tubing.GetComponent<Rigidbody>().useGravity = true;

        audioSource.PlayOneShot(intro_VO[21]);
        yield return new WaitForSeconds(intro_VO[19].length);

    }

    IEnumerator Step10()
    {
        // Step 7 from storyboard
        audioSource.PlayOneShot(intro_VO[22]);
        PlayGuide(12);                                   //Play Animation of Transparent hand removing the tubing and blood bag.
        yield return new WaitForSeconds(intro_VO[22].length);
        BloodProduct.GetComponent<BoxCollider>().enabled = true;
        BloodProduct.GetComponent<Rigidbody>().useGravity = true;

    }
    IEnumerator Step11()
    {
        // Step 7 from storyboard
        audioSource.PlayOneShot(intro_VO[23]);
        PlayGuide(13);                                   //Play Animation of Transparent hand   disposing the utilized items into the biohazard bag.

        yield return new WaitForSeconds(intro_VO[23].length);
        biohazard_Bag.GetComponent<BoxCollider>().enabled = true;
        biohazard_Bag.GetComponent<Rigidbody>().useGravity = true;
        audioSource.PlayOneShot(intro_VO[24]);
        PlayGuide(13);                                   //Play Animation of Transparent Hand taking sanitizer and washing hands
        yield return new WaitForSeconds(intro_VO[24].length);

        audioSource.PlayOneShot(intro_VO[25]);
        yield return new WaitForSeconds(intro_VO[25].length);

    }

   

}
