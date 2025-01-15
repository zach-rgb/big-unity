using UnityEngine;

public class cost_checker : MonoBehaviour
{
    public storage storage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool cost_check(float cost)
    {
        if (cost > storage.player_metal)
        {
            return false;
        }
        else
        {
            
            storage.player_metal -= cost;
            return true;
        }
    }
}
