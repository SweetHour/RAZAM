using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject plug, creator,cameraObject,options;




    public Slider VolumeSlider;
    public Slider FontSizeSlider;
    public Image main, side;

    public TextMeshProUGUI[] texts;
    public float[] textsSizes;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        for (int i = 0; i < texts.Length; i++)
        {
            textsSizes[i] = texts[i].fontSize;
        }

        main = GameObject.Find("Main").GetComponent<Image>();
        side = options.GetComponent<Image>();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
    public void Home()
    {
        Application.OpenURL("https://www.sweethour.art/");
    }
    public void Creator()
    {
        plug.SetActive(!plug.activeSelf);
        creator.SetActive(!creator.activeSelf);
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/OurSweetHour");
    }


    
  
   
   








}
   
