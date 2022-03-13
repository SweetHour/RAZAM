using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrystalActivation : MonoBehaviour
{
    [SerializeField] private GameObject GatePart;
    [SerializeField] private Color _crystalColor;
    private Renderer GatePartRenderer;
    private GameObject player;
    private bool isUsed,isShown;
    private GameObject lore;
    [SerializeField] private TextMeshProUGUI loreText;
    [SerializeField] private GameObject interactText;
    public string message;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = _crystalColor;
        GatePartRenderer = GatePart.GetComponent<Renderer>();
        GatePartRenderer.material.color = new Color(0.1f, 0.1f, 0.1f, 1f);
        player = GameObject.Find("Player");
        lore = GameObject.Find("Lore");
      
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude < 5 && Input.GetKeyDown(KeyCode.E)&&!isUsed)
        {
            GatePartRenderer.material.color = _crystalColor;
            GameObject.Find("Gate").GetComponent<GateManager>().gatePartCountLeft--;
            gameObject.GetComponent<AudioSource>().Play();
            transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
            StartCoroutine(Hide());
            isUsed = true;
            StartCoroutine(ShowLore());
        }
        if((player.transform.position - transform.position).magnitude < 5 &&!isUsed) 
        {
            
            isShown = true;
            interactText.SetActive(true);
        } 
        else 
        {
           
            if (isShown)
            {
                isShown = false;
                interactText.SetActive(false);
            }
        }
        
        





    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }
    IEnumerator ShowLore()
    {
        yield return new WaitForSeconds(0.5f);
        loreText.text = message;
        lore.SetActive(true);

    }
}
