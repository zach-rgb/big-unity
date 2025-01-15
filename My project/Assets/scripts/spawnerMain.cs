using UnityEngine;
using UnityEngine.UIElements;

public class spawnerMain : MonoBehaviour
{
    public spawning spawning;
    [SerializeField] private float max_time;
    [SerializeField] private GameObject ObjectToSpawn;
    public target_finding target_finding;
    [SerializeField] private float max_distance;
    private bool spawn=false;
    [SerializeField] private int mode;
    [SerializeField] private int layer;
    [SerializeField] private string tag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mode==1)
        {
            
            if (target_finding.findingDistanceTag(tag) < max_distance)
            {
                spawn = true;
            }
        }
        else if ( mode==2)
        {
            if (target_finding.findingDistanceLayer(layer) < max_distance)
            {
                spawn = true;
            }
        }

        
        
        if (spawn)
        {
            Debug.Log("hallo");
            spawning.spawn(max_time, ObjectToSpawn.GetComponent<cost>().CostOfObject, ObjectToSpawn, transform.position, transform.rotation, this.gameObject);
        }
    }
}

