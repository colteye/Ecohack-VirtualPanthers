using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHeightmap : MonoBehaviour
{

    [SerializeField]
    Material[] materials; 
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update

    public void ToggleHeightMapMaterial()
    {
        if (meshRenderer.sharedMaterial.name == materials[0].name)
        {
            meshRenderer.material = materials[1];
            //Debug.Log("mesh now has material [1]");
            return;
        }
        else
        {
            //Debug.Log("Mesh Renderer had a material named: " + meshRenderer.sharedMaterial.name + "\n" 
                      //+ "which is not the same as " + materials[0].name);
        }

        if (meshRenderer.sharedMaterial.name == materials[1].name)
        {
            meshRenderer.material = materials[0];
            //Debug.Log("mesh now has material [0]");
            return;
        }
        else
        {
            //Debug.Log("Mesh Renderer had a material named: " + meshRenderer.sharedMaterial.name + "\n"
            //          + "which is not the same as " + materials[1].name);
        }

    }
}
