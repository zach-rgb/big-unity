
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;


public class ballsMovement : MonoBehaviour
{

    
    
    
    
    private GameObject closetTarget;
    
    
    public target_finding Target_Finding; 




    private void Update()
    
    {
        

            for (int i = 0; i < transform.childCount; i++)
            {
                closetTarget = Target_Finding.findingGameObjectTag("temp");
                

                transform.GetChild(i).GetComponent<NavMeshAgent>().destination = closetTarget.transform.position;

                



            }
        
        if (closetTarget = null) {
        
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<NavMeshAgent>().destination = transform.position;
            }
        }
    }

    
}
        
        



    

