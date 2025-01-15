using Unity.AI.Navigation;
using UnityEngine;

public class SelectedMaterial : MonoBehaviour{
    [SerializeField] private Material highlightMaterial;
    private Material originalMaterial;
    private MeshRenderer renderer;
    public bool claimedAI;
    public bool claimedYOU;

    void Start(){
        claimedAI = false;
        claimedYOU = false;

        renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
        }

        transform.localScale = Vector3.one;
    }

    public void OnHoverEnter(){
        if ((renderer != null) && (claimedAI == false))
        {
            renderer.material = highlightMaterial;
        }
    }

    public void OnHoverExit(){
        if ((renderer != null) || (claimedAI == true))
        {
            renderer.material = originalMaterial;
        }
    }

    void Update(){

        if(claimedAI && claimedYOU){

            claimedAI = false;
        }
    }
}
