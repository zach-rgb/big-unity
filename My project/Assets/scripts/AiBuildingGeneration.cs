using System.Collections.Generic;
using UnityEngine;

public class AiBuildingGeneration : MonoBehaviour
{
    private float max_distance=36.5f;
    private float build_time;
    [SerializeField] private float grow_time;
    public timer timer;
    public target_finding target_Finding;
    [SerializeField] private GameObject building;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.timer_func(grow_time)){
            max_distance += 36.5f;
        }

        if (timer.timer_func(build_time)){
            List<GameObject> objects = target_Finding.findingGameObjectsTaginRange("placeable", max_distance);
            Instantiate(building,objects[Random.Range(0,objects.Count)].transform.position,Quaternion.Euler(0,0,0));
        }
    }
    
    

}
