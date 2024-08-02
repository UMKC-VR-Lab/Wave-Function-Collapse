using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PossibilitySpaceVisualizer
{
    public static GameObject Visualize(Vector3 position, GameObject blockPrefab, int totalPossibilities, int validPossibilities)
    {
        // Create a parent gameobject to return
        GameObject parent = new GameObject();

        // Calculate the matrix
        int cubeEdgeDimension = (int)Mathf.Pow((float)totalPossibilities, (1.0f / 3.0f));

        // Calculate the size of the objects within a 1 meter cube scaled by 90% to give a margin between elements
        float scale = (1.0f / cubeEdgeDimension) * 0.90f;

        // Instantiate all the visualization objects
        for(int i = 0; i < cubeEdgeDimension; i++)
        {
            for(int j = 0; j < cubeEdgeDimension; j++)
            {
                for (int k = 0; k < cubeEdgeDimension; k++)
                {

                }
            }
        }

        // Loop and instantiate objects
        
        
        return parent;
    }
}
