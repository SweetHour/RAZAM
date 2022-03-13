using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loreText;
    private GameObject lore,menu;
    private bool isPaused;


    private void Start()
    {
        lore = GameObject.Find("Lore");
        menu = GameObject.Find("Pause Menu");
       
        StartCoroutine(FirstLore());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
           
        }

        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }
    IEnumerator FirstLore()
    {
        yield return new WaitForSeconds(6f);
        loreText.text = "Once there was a world without light, and its inhabitants never saw each other. But the day the light appeared, they discovered that they were all different.";
        lore.SetActive(true);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
