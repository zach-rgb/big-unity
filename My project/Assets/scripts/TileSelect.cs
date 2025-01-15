using UnityEngine;

public class TileSelect : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;
	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit)){

            GameObject currentObject = hit.collider.gameObject;

            SelectedMaterial selectedMaterial = currentObject.GetComponent<SelectedMaterial>();

            if (!selectedMaterial.claimedAI){
			    Debug.Log(hit.collider.name);
            }
		}
    }
}

