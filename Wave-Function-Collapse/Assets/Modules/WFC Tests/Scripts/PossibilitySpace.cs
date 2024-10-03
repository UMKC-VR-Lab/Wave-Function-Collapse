using System.Collections.Generic;
using WaveFunctionCollapse;
using UnityEngine;
using System.Collections;

public class PossibilitySpace : MonoBehaviour
{
    // Reference to the visualizer
    public ModuleVisualizer module;
    
    // The radius it will check for when finding neighbors
    public float maxNeighborDistance = 10.0f;

    // The layermask to use when checking for layers
    public LayerMask possibilitySpaceLayer;

    // If the cell has constraints propagated to it
    public List<GameObject> validModules;

    // Called to collapse this cell and propagate constraints
    public IEnumerator Collapse()
    {
        yield return new WaitForSeconds(0.1f);

        // Choose a valid module at random and instantiate it
    }
    
    // Calculate entropy
    public float CalculateEntropy(int numberOfPossibleModules)
    {
        return (float)validModules.Count / ((float)numberOfPossibleModules);
    }

    // Find adjacent neighbors
    public List<PossibilitySpace> FindNeighbors()
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
