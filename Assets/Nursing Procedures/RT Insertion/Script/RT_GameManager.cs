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


    public GameObject character_animation;
    public GameObject bed_animation;

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

        //wash Hands
        audioSource.PlayOneShot(intro_VO[7]);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[7].length);
        yield return new WaitForSeconds(3f);
        //character_animation.GetComponent<Animator>().Play("Getup_idle_clone");
        yield return new WaitForSeconds(3f);


        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);

        character_animation.GetComponent<Animator>().Play("Getup_idle_clone");
        bed_animation.GetComponent<Animator>().Play("Bed_mattressRotation_clone");

        //Enable NASOGASTRIC_TUBE
        NASOGASTRIC_TUBE.GetComponent<MeshCollider>().enabled = true;
        NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if (NASOGASTRIC_TUBE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;
        }

        if (TAPE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;
        }

        if(WATER_SOLUBLE_LUBRICANT.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;
        }

        if (GLASS_OF_WATER.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[4] = true;
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
        NASOGASTRIC_TUBE.GetComponent<MeshCollider>().enabled = false;
        FT_NG_TUBE.GetComponent<BoxCollider>().enabled = false;
        WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = false;
        GLASS_OF_WATER.GetComponent<MeshCollider>().enabled = false;
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

    }


    IEnumerator Step1()
    {
        // STEP 1 Pick Nasogastric Tube

        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);
        yield return new WaitForSeconds(4f);

        StartCoroutine(Step2());
    }

    IEnumerator Step2()
    {
        // step 2 Highlight Tape and Attach to Nasogastric Tube

        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);

        // Enable Tape

        TAPE.GetComponent<BoxCollider>().enabled = true;
        TAPE.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step3()
    {
       // Step 3 Highlight Water Soluble Lubricant

        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
        yield return new WaitForSeconds(4f);

        // Lubricate about 2 – 4 inches of the tube with a lubricant

        audioSource.PlayOneShot(intro_VO[12]);
        yield return new WaitForSeconds(intro_VO[12].length);

        // Enable water Soluble Lubricant

        WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = true;
        WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Step4()
    {
        // step 4 Pick Glass Of Water 

        audioSource.PlayOneShot(intro_VO[13]);
        yield return new WaitForSeconds(intro_VO[13].length);
        yield return new WaitForSeconds(3f);
        
        // Have a patient to take sip of water 

        audioSource.PlayOneShot(intro_VO[14]);
        yield return new WaitForSeconds(intro_VO[14].length);
        yield return new WaitForSeconds(3f);

        // Secure Tube in Place 

        audioSource.PlayOneShot(intro_VO[15]);
        yield return new WaitForSeconds(intro_VO[15].length);

        // Enable Glass Of Water

        GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = true;
        GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = true;
    }
}
