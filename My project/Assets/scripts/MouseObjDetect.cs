using UnityEngine;

public class RaycastHighlighter : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject lastHoveredObject;

    void Update(){
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)){
            GameObject currentObject = hit.collider.gameObject;

            if (lastHoveredObject != currentObject){
                if (lastHoveredObject != null){
                    lastHoveredObject.SendMessage("OnHoverExit", SendMessageOptions.DontRequireReceiver);
                }

                currentObject.SendMessage("OnHoverEnter", SendMessageOptions.DontRequireReceiver);
                lastHoveredObject = currentObject;
            }
        }
        else{
            if (lastHoveredObject != null)
            {
                lastHoveredObject.SendMessage("OnHoverExit", SendMessageOptions.DontRequireReceiver);
                lastHoveredObject = null;
            }
        }
    }
}
