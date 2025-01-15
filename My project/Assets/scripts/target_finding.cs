using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class target_finding : MonoBehaviour
{
    public List<(float, GameObject)> Targetdistances = new List<(float, GameObject)>();
    public List <GameObject> InRange = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject findingGameObjectTag(string tag)
    {
        Targetdistances.Clear();

         GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

    foreach( GameObject target in targets){
            Targetdistances.Add((Vector3.Distance(target.transform.position, transform.position), target));
        }
    Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
    return Targetdistances[0].Item2;
    }
    public float findingDistanceTag(string tag)
    {
        Targetdistances.Clear();

        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject target in targets)
        {
            Targetdistances.Add((Vector3.Distance(target.transform.position, transform.position), target));
        }
        Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        return Targetdistances[0].Item1;
    }
    public GameObject findingGameObjectLayer(int layer)
    {
        Targetdistances.Clear();
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject target in allObjects)
            if (target.layer == layer)
            {
                Targetdistances.Add((Vector3.Distance(target.transform.position, transform.position), target));
            }
        Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        return Targetdistances[0].Item2;

    }
    public float findingDistanceLayer(int layer)
    {
        Targetdistances.Clear();
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (GameObject target in allObjects)
            if (target.layer == layer)
            {
                Targetdistances.Add((Vector3.Distance(target.transform.position, transform.position), target));
            }
        Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
        return Targetdistances[0].Item1;

    }
    public List<GameObject> findingGameObjectsTaginRange(string tag,float distance)
    {
        
        InRange.Clear();
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        

        foreach (GameObject target in targets)
        {
            if (Vector3.Distance(target.transform.position, transform.position)<distance){
                InRange.Add(target);
            }
        }
        
        return InRange;
    }
}
