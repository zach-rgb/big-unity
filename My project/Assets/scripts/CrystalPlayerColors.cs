using UnityEngine;

public class CrystalPlayerColors : MonoBehaviour
{
    private MeshRenderer renderer;
    private SelectedMaterial selectedMaterial;
    public Material PlayerColor;
    public Material AIColor;

    void Start(){
        renderer = GetComponent<MeshRenderer>();
        selectedMaterial = GetComponent<SelectedMaterial>();
    }

    void Update(){

        if(selectedMaterial.claimedAI || selectedMaterial.claimedYOU){

            gameObject.tag = "ClaimedCrystal";
        }

        if (selectedMaterial.claimedAI)
        {
            renderer.material = AIColor;

        }
        else if (selectedMaterial.claimedYOU)
        {
            renderer.material = PlayerColor;
        }
    }
}
