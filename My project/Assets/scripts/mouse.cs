using System.Collections.Generic;

using UnityEngine;


public class MousePos : MonoBehaviour
{


    const int MOUSE = 0;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ObjectToSpawn;
    [SerializeField] private GameObject ObjectParent;
    private GameObject current_building;
    private GameObject closestTarget;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject other_target;
    private List<(float, int)> Targetdistances = new List<(float, int)>();
    [SerializeField] private float min_distance;
    public cost_checker cost_Checker;
    public buildingsMain buildingsMain;
    // Use this for initialization1
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && cost_Checker.cost_check(buildingsMain.cost))///fix
        {
            
            createbuilding();
        }
        if (Input.GetMouseButton(1))
        {
            Rotatebuilding();
        }

    }
    void createbuilding()
    {
        Plane plane = new Plane(Vector3.up, player.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            Targetdistances.Clear();
            if (target.transform.childCount > 0|| other_target.transform.childCount>0)
            {
                for (int i = 0; i < other_target.transform.childCount; i++)
                {
                    Targetdistances.Add((Vector3.Distance(other_target.transform.GetChild(i).position, ray.GetPoint(point)), i));

                }
                for (int j = 0; j < target.transform.childCount; j++)
                {
                    Targetdistances.Add((Vector3.Distance(target.transform.GetChild(j).position, ray.GetPoint(point)), j));

                }
                Targetdistances.Sort((a, b) => a.Item1.CompareTo(b.Item1));
                
                if (Targetdistances[0].Item1 > min_distance)
                {
                    Instantiate(ObjectToSpawn, ray.GetPoint(point), Quaternion.Euler(0, 0, 0), ObjectParent.transform);
                    current_building = ObjectParent.transform.GetChild(ObjectParent.transform.childCount - 1).gameObject;
                }
            }
            else
            {
                Instantiate(ObjectToSpawn, ray.GetPoint(point), Quaternion.Euler(0, 0, 0), ObjectParent.transform);
                current_building = ObjectParent.transform.GetChild(ObjectParent.transform.childCount - 1).gameObject;
            }
            
        }

    }
    private void Rotatebuilding()
    {
        Plane plane = new Plane(Vector3.up, player.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            
            current_building.transform.LookAt(ray.GetPoint(point), Vector3.up);
            
            if (current_building.transform.rotation.eulerAngles.y<45 && current_building.transform.rotation.eulerAngles.y >0)
            {
                current_building.transform.eulerAngles = new Vector3 (0, 0, 0);
            }
            else if (current_building.transform.rotation.eulerAngles.y < 135 && current_building.transform.rotation.eulerAngles.y > 45)
            {
                current_building.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            
            else if (current_building.transform.rotation.eulerAngles.y < 225 && current_building.transform.rotation.eulerAngles.y > 135){
                current_building.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            else if (current_building.transform.rotation.eulerAngles.y < 315 && current_building.transform.rotation.eulerAngles.y > 225)
            {
                current_building.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            else
            {
                current_building.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }


    }
}