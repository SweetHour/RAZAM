using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateManager : MonoBehaviour
{
    public int gatePartCountLeft;
    private GameObject player;
    public GameObject Heavens,doorLight;
    public bool doorActivated,coroutineStarted, isInside, isShown;
    public AudioSource audioGate;
    [SerializeField] private GameObject interactText;

    [SerializeField] private TextMeshProUGUI loreText;
    private GameObject lore;



    void Start()
    {
        player = GameObject.Find("Player");
        lore = GameObject.Find("Lore");
        Heavens.SetActive(false);
       
    }


    void Update()
    {
        if (gatePartCountLeft <= 0 && (player.transform.position - transform.position).magnitude < 5 && Input.GetKeyDown(KeyCode.E))
        { 
            doorActivated = true;
            Heavens.SetActive(true);
            audioGate.Play();
            StartCoroutine(ShowLore("7.But those who accepted each other and respected the differences lived in light and prosperity all this time.And they will live on in unity, razam."));
          
        }
        if (gatePartCountLeft > 0 && (player.transform.position - transform.position).magnitude < 5 && Input.GetKeyDown(KeyCode.E))
        {

            StartCoroutine( ShowLore("Collect all memories, follow the lights. " +gatePartCountLeft+" memories left"));
           
        }
        if (doorActivated && transform.position.y > 40) 
        { 
            transform.Translate(Vector3.down * Time.deltaTime * 2);
            if (coroutineStarted == false) { StartCoroutine(AutoClose()); coroutineStarted = true; } 
        }
        else if (transform.position.y < 54) 
        { 
            transform.Translate(Vector3.up * Time.deltaTime * 2);  
        }

        if (gatePartCountLeft <= 0) doorLight.SetActive(true);


        if ((player.transform.position - transform.position).magnitude < 5 && !doorActivated)
        {
            isInside = true;
            isShown = true;
            interactText.SetActive(true);
        }
        else
        {
            isInside = false;
            if (isShown)
            {
                isShown = false;
                interactText.SetActive(false);
            }
        }

    }
    IEnumerator AutoClose() 
    {
        yield return new WaitForSeconds(10f);
        doorActivated = false;
        coroutineStarted = false;
        audioGate.Play();
    }
    IEnumerator ShowLore(string message)
    {
        yield return new WaitForSeconds(0.5f);
        loreText.text = message;
        lore.SetActive(true);

    }
}
