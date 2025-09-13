using UnityEngine;
using System.Collections.Generic;

public class GrannySkinSelection : MonoBehaviour
{
    [Header("List of Granny Materials")]
    public List<Material> grannyMaterials;

    [Header("Mesh Renderer to Apply Material")]
    public SkinnedMeshRenderer grannyRenderer;

    private void Start()
    {
        CheckSkin();
    }

    private void OnEnable()
    {
        CheckSkin();   
    }

    void CheckSkin()
    {
        // Check if "SelectedGrannyIndex" exists, otherwise set it to 0
        if (!PlayerPrefs.HasKey("SelectedGrannyIndex"))
        {
            PlayerPrefs.SetInt("SelectedGrannyIndex", 0);
        }

        // Get the selected index
        int selectedIndex = PlayerPrefs.GetInt("SelectedGrannyIndex");

        // Make sure the index is within range
        if (selectedIndex >= 0 && selectedIndex < grannyMaterials.Count)
        {
            // Assign the material
            grannyRenderer.material = grannyMaterials[selectedIndex];
        }
        else
        {
            Debug.LogWarning("SelectedGrannyIndex is out of range! Assigning default material.");
            // Fallback to first material
            grannyRenderer.material = grannyMaterials[0];
        }
    }
}
