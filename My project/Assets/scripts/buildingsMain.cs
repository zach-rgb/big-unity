using UnityEngine;

public class buildingsMain : MonoBehaviour
    
{
    private float t = 0.0f;
    private float duration = 1.5f;
    private bool change = false;
    public harvesting Harvesting;
    [SerializeField] private float max_time;
    
    public float cost;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            for (int i = 0; i < transform.childCount; i++)
            {

                transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.blue, t);
                if (t < 1)
                {
                    t += Time.deltaTime / duration;
                }
            }
            Harvesting.Harvesting(max_time);
            


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "builder vehichle") { 
            change= true;   
        transform.SetParent(GameObject.Find("buildings").transform);
    }
        
    }

   
}
