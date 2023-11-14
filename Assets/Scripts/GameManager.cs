using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
public GameObject ui;
public GameObject[] nights;
int currentNight=0;
GameObject currentInstance;
public GameObject menuCamera;
public Text text;
public Text button;
public Font titleFont;
public Font inGameFont;
    // Start is called before the first frame update
    void Start()
    {
      FirstNightUI();

    }

    void FirstNightUI(){
        ui.SetActive (true);
        text.font = titleFont;
        button.font = titleFont;
        text.text = "Cleaning Simulator: The Hallway Dweller";
        button.text = "New Game";


    }

    void ContinueNightUI(){
        ui.SetActive (true);
        text.font = inGameFont;
        button.font = inGameFont;
        text.text = "You Escaped!!!";
        button.text = "Next Night";


    }

 void FinalNightUI(){
        ui.SetActive (true);
        text.font = titleFont;
        button.font = titleFont;
        text.text = "The janintor finnishes his first week, never to be seen again. THE END";
        button.text = "Back To Menu";


    }
    public void HandleButtonPress(){
    
        if (currentNight == nights.Length){
        FirstNightUI();
        currentNight = 0;


        } else {
menuCamera.SetActive(false);
    currentInstance = GameObject.Instantiate (nights[currentNight]);
     ui.SetActive (false);
    Cursor.lockState = CursorLockMode.Locked;

        }
        

    }
      public void HandleNightEnd(){
        currentNight++;
        if(currentNight == nights.Length){
        FinalNightUI();
         }else{
          ContinueNightUI();
         }
          
       menuCamera.SetActive(true);
       GameObject.Destroy(currentInstance);
       Cursor.lockState = CursorLockMode.None;



      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
