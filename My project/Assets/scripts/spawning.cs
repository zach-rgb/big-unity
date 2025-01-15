using UnityEngine;

public class spawning : MonoBehaviour
{
    public timer timer;
    public cost_checker cost_checker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn(float max_time,float cost,GameObject ObjectToSpawn,Vector3 position,Quaternion rotation,GameObject ParentObject)
    {
        if (timer.timer_func(max_time) && cost_checker.cost_check(cost))
        {
            Instantiate(ObjectToSpawn, position, rotation, ParentObject.transform);
        }
    }
}
