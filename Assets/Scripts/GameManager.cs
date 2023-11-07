using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public GameObject ui;
public GameObject[] nights;
int currentNight=0;
GameObject currentInstance;
public GameObject menuCamera;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive (true);

    }






    public void HandleNightBegin(){
    menuCamera.SetActive(false);
    currentInstance = GameObject.Instantiate (nights[currentNight]);
     ui.SetActive (false);
    Cursor.lockState = CursorLockMode.Locked;

    }
      public void HandleNightEnd(){
        ui.SetActive(true);
       menuCamera.SetActive(true);
       GameObject.Destroy(currentInstance);
       Cursor.lockState = CursorLockMode.None;



      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
