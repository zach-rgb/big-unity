using UnityEngine;

public class harvesting : MonoBehaviour
{
    
    public timer timer;
    public storage storage; //resources
    [SerializeField] private float metal_generation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

       }
    public void Harvesting(float max_time)
    {
        
        if (timer.timer_func(max_time))
        {
            storage.player_metal += metal_generation;

        }
    }
}
