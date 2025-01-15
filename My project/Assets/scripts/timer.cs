using UnityEngine;

public class timer : MonoBehaviour
{
    public float time_elasped = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool timer_func(float time)
    {
        time_elasped += Time.deltaTime;

        if (Mathf.FloorToInt(time_elasped % 60) >= time)
        {
            time_elasped = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
