
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    
    [SerializeField] private GameObject closetTarget; // now an empty variable that will be the closest of the two object
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {






        transform.GetComponent<NavMeshAgent>().destination = closetTarget.transform.position;
            
        
        
        
    }
}