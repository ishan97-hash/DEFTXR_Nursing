using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneA_GameManager : MonoBehaviour
{
    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be done by User
    [SerializeField]
    private List<GameObject> Actions;

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Guides;

    [SerializeField]
    private AudioSource audioSource;

    // Model of Patient lying on Bed
    [SerializeField]
    private GameObject patient;

    private void Start()
    {
        InitializeDefaultData();
        StartCoroutine(Introduction());
    }

    void Update()
    {
        
    }

    void InitializeDefaultData()
    {
        // Disable all models
        patient.SetActive(false);

        for (int i=0; i<Guides.Count; i++)
        {
            Guides[i].SetActive(false);
        }

    }

    IEnumerator Introduction()
    {
        // activate the required component

        yield return new WaitForSeconds(2f);

        // Show Patient
        patient.SetActive(true);

        // Step 1
        audioSource.PlayOneShot(intro_VO[0]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[0].length);

        // Step 2
        audioSource.PlayOneShot(intro_VO[1]);
        Guides[0].SetActive(false);
        Guides[1].SetActive(true);
        yield return new WaitForSeconds(intro_VO[1].length);

        // Step 3
        audioSource.PlayOneShot(intro_VO[2]);
        Guides[1].SetActive(false);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[2].length);

        // Step 4
        audioSource.PlayOneShot(intro_VO[3]);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);
        yield return new WaitForSeconds(intro_VO[3].length);
    }
}
