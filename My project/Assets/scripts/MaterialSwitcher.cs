using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public GameObject prefab;
    public Material idleMaterial;
    public Material aciveMaterial;

    void Update()
    {
        MeshRenderer meshRenderer = prefab.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material = idleMaterial;
        }
    }
}
