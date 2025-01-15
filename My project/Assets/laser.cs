using UnityEngine;
using UnityEngine.Animations;

public class laser : MonoBehaviour
{
    public timer timer;
    [SerializeField] private float laser_time;
    [SerializeField] private float charge_time;
    public target_finding target_finding;
    private bool charging=false;
    private bool hit=false;
    [SerializeField] private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!timer.timer_func(laser_time) && !charging)
        {
            transform.LookAt(target_finding.findingGameObjectLayer(6).transform, Vector3.up);
            if (!hit)
            {
                transform.localScale += new Vector3(0,0,speed);
            }
        }
        else if(charging&& timer.timer_func(charge_time))
        {
            charging=false;
            hit = false;
        }
        else if (timer.timer_func(laser_time))
        {
            charging=true;
            hit = false;
            transform.localScale = new Vector3(1,1,1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            hit = true;
            
        }
    }
}
