
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public target_finding Target_Finding;
    [SerializeField] private float follow_speed;
    [SerializeField] private float max_distance;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject other_target;
    private Vector3 Initialposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Hallo
    void Start()
    {
        
        Vector3 point = Target_Finding.findingGameObjectLayer(3).transform.position;
        transform.LookAt(point);
        Initialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * follow_speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, Initialposition) > max_distance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponent<deathcondition>().HP -= 1;
            Destroy(gameObject);
        }
    }
}
