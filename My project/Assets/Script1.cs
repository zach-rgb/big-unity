using UnityEngine;

public class Script1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject closestTarget;

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = closestTarget.transform.position;
    }
}
