using UnityEngine;

public class reset : MonoBehaviour
{
    public storage storage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        storage.player_metal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
