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
    private GameObject MEASURE_TUBE;
    [SerializeField]
    private GameObject Fix_Insertion_TUBE;
    [SerializeField]
    private GameObject FIX_NASOGASTRIC_TUBE;
    [SerializeField]
    private GameObject WATER_SOLUBLE_LUBRICANT;
    [SerializeField]
    private GameObject GLASS_OF_WATER;
    [SerializeField]
    private GameObject TAPE;
    [SerializeField]
    private GameObject SmallTape;
    [SerializeField]
    private GameObject EMESIS_BASIN;
    [SerializeField]
    private GameObject SCISSOR;
    [SerializeField]
    private GameObject NG_Highlighted;
    [SerializeField]
    private GameObject Tape_Highlighted;
    [SerializeField]
    private GameObject gow_Highlighted;
    [SerializeField]
    private GameObject wsl_Highlighted;
    [SerializeField]
    private GameObject smallTape_Highlighted;



    public GameObject character_animation;
    public GameObject bed_animation;
    public GameObject pushHand_animation;
    public GameObject washHand_animation;
    public GameObject measure_animation;
    public GameObject tube_insert_animation;

    //Labels
    public GameObject NGTUBE_Name;
    public GameObject Tape_Name;
    public GameObject WSL_Name;
    public GameObject GOW_Name;


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
        yield return new WaitForSeconds(intro_VO[0].length);

        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);

        Debug.Log("playing vo2");
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);
        yield return new WaitForSeconds(3f);

        //Show Apparatus
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[5]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[5].length);
        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        Guides[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(intro_VO[7]);
        character_animation.GetComponent<Animator>().Play("Eyeblink_Talk_clone");
        yield return new WaitForSeconds(intro_VO[7].length);

        //wash Handswash
        audioSource.PlayOneShot(intro_VO[8]);
        Guides[1].SetActive(true);
        pushHand_animation.SetActive(true);
        washHand_animation.SetActive(true);
        yield return new WaitForSeconds(intro_VO[8].length);
        pushHand_animation.GetComponent<Animator>().Play("Hand_push_anim_clone");
        washHand_animation.GetComponent<Animator>().Play("Hand_wash_anim_clone");
        yield return new WaitForSeconds(3f);
        pushHand_animation.SetActive(false);
        washHand_animation.SetActive(false);
        Guides[1].SetActive(false);
        yield return new WaitForSeconds(5f);



        audioSource.PlayOneShot(intro_VO[9]);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[9].length);
        character_animation.GetComponent<Animator>().Play("Getup_idle_clone");
        yield return new WaitForSeconds(3f);
        bed_animation.GetComponent<Animator>().Play("Mattress_rotation2_clone");
        yield return new WaitForSeconds(3f);
        character_animation.GetComponent<Animator>().Play("Leaning_back_clone");
        yield return new WaitForSeconds(3f);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        //Enable NASOGASTRIC_TUBE
        NG_Highlighted.SetActive(true);
        NASOGASTRIC_TUBE.SetActive(false);
        NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = true;
        NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if (NASOGASTRIC_TUBE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            NGTUBE_Name.SetActive(false); 
            Guides[3].SetActive(false);
            Guides[4].SetActive(true);
            MEASURE_TUBE.SetActive(true);
            measure_animation.SetActive(true);
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;

            TAPE.GetComponent<BoxCollider>().enabled = true;
            TAPE.GetComponent<Rigidbody>().useGravity = true; 
        }

        if (TAPE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            Tape_Name.SetActive(false);
            Guides[11].SetActive(false);
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;

            WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = true;
            WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = true;
        }

        if (WATER_SOLUBLE_LUBRICANT.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            WSL_Name.SetActive(false);
            Guides[12].SetActive(false);
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;

            GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = true;
            GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = true;
        }

        if (GLASS_OF_WATER.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            GOW_Name.SetActive(false);
            Guides[15].SetActive(false);
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

        NASOGASTRIC_TUBE.SetActive(true);
        TAPE.SetActive(true);
        WATER_SOLUBLE_LUBRICANT.SetActive(true);
        GLASS_OF_WATER.SetActive(true);
        SmallTape.SetActive(false);
        smallTape_Highlighted.SetActive(false);
        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = false;
        WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = false;
        GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = false;
        TAPE.GetComponent<BoxCollider>().enabled = false;
       

        // 2) Disable all Gravity since Box Colliders are off
        NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = false;
        WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = false;
        GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = false;
        TAPE.GetComponent<Rigidbody>().useGravity = false;
    
    }

   

    IEnumerator Step1()
    {
        // STEP 1 Pick Nasogastric Tube

        audioSource.PlayOneShot(intro_VO[10]); 
        measure_animation.GetComponent<Animator>().Play("Hand_measure");
        yield return new WaitForSeconds(intro_VO[10].length);
        Guides[4].SetActive(false);
        MEASURE_TUBE.SetActive(false);
        measure_animation.SetActive(false);
        Guides[11].SetActive(true);

    }

    IEnumerator Step2()
    {
        // step 2 Highlight Tape and Attach to Nasogastric Tube
        Guides[5].SetActive(true);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
        Guides[5].SetActive(false);
        Guides[13].SetActive(true);
        smallTape_Highlighted.SetActive(true);
        yield return new WaitForSeconds(5f);
        Guides[13].SetActive(false);
        Guides[12].SetActive(true);
    }

    IEnumerator Step3()
    {
        // Step 3 Highlight Water Soluble Lubricant
        // Lubricate about 2 – 4 inches of the tube with a lubricant
        Guides[6].SetActive(true);
        audioSource.PlayOneShot(intro_VO[12]);
        yield return new WaitForSeconds(intro_VO[12].length);
        Guides[6].SetActive(false);
        yield return new WaitForSeconds(4f);

        // play insert tube animation

        Guides[7].SetActive(true);
        audioSource.PlayOneShot(intro_VO[13]);
        Fix_Insertion_TUBE.SetActive(true);
        tube_insert_animation.SetActive(true);
        tube_insert_animation.GetComponent<Animator>().Play("Hand_insertTube_movement");
        character_animation.GetComponent<Animator>().Play("Rising_head_forTubeInsertion_clone");
        yield return new WaitForSeconds(intro_VO[13].length);
        Guides[7].SetActive(false);
        tube_insert_animation.SetActive(false);
        yield return new WaitForSeconds(4f);

        Guides[8].SetActive(true);
        audioSource.PlayOneShot(intro_VO[14]);
        yield return new WaitForSeconds(intro_VO[14].length);
        Guides[8].SetActive(false);
        yield return new WaitForSeconds(2f);

        Guides[15].SetActive(true);
        yield return new WaitForSeconds(2f);

    }

    IEnumerator Step4()
    {

        Guides[9].SetActive(true);
        audioSource.PlayOneShot(intro_VO[15]);
        character_animation.GetComponent<Animator>().Play("Drinking_water_after_Discomfort_clone");
        yield return new WaitForSeconds(intro_VO[15].length);

        Guides[9].SetActive(false);
        yield return new WaitForSeconds(3f);

        Guides[14].SetActive(true);
        Fix_Insertion_TUBE.SetActive(false);
        yield return new WaitForSeconds(3f);
        Guides[14].SetActive(false);

        Guides[10].SetActive(true);
        FIX_NASOGASTRIC_TUBE.SetActive(true);
        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);
        Guides[10].SetActive(false);

    }
}
