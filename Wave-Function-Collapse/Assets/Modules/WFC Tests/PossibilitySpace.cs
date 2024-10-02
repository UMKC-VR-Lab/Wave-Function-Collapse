using System.Collections.Generic;
using WaveFunctionCollapse;
using UnityEngine;

public class PossibilitySpace : MonoBehaviour
{
    // If the cell has been collapsed, store the module data in it
    public ModuleData moduleData;
    
    // The radius it will check for when finding neighbors
    public float maxNeighborDistance = 10.0f;

    // The layermask to use when checking for layers
    public LayerMask possibilitySpaceLayer;

    // If the cell has constraints propagated to it
    public List<ModuleData> invalidModulesIndices;

    // Calculate entropy
    public float CalculateEntropy(int numberOfPossibleModules)
    {
        return 1.0f - (((float)invalidModulesIndices.Count) / ((float)numberOfPossibleModules));
    }

    // Find adjacent neighbors
    public List<PossibilitySpace> GetNeighbors()
    {
        List<PossibilitySpace> result = new();

        Collider[] neighbors = Physics.OverlapSphere(transform.position, maxNeighborDistance, possibilitySpaceLayer);

        // Add all the hits to result unless it is this gameObject
        for (int i = 0; i < neighbors.Length; i++) 
        {
            PossibilitySpace neighbor = neighbors[i].GetComponent<PossibilitySpace>();
            if (neighbor != null && neighbors[i].gameObject != gameObject)
            {
                result.Add(neighbor);
            }
        }
        return result;
    }
}
