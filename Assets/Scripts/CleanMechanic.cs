using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMechanic : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
          
         // int layerMask = 1 << LayerMask.NameToLayer("Player") ;
          
          
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                   Debug.Log ($"hit,{transform.forward}\n {hit.collider.gameObject}") ;
                if (hit.collider.gameObject.CompareTag("Rubbish"))
                {
               
                 
                 var numRubbish = GameObject.FindGameObjectsWithTag("Rubbish").Length;
                 Debug.Log ($"Rubbish: {numRubbish}");
                  
                  GameObject.Destroy (hit.collider.gameObject) ;
                  if(numRubbish <= 1){ 
                   var go = GameObject.FindWithTag ("GameManager");
                   var gm = go.GetComponent<GameManager>();
                    gm.HandleNightEnd();
                  }
                  
                  
                     //Do something if the hit object has the "rubbish tag
                }
            }
        }

    }
}
