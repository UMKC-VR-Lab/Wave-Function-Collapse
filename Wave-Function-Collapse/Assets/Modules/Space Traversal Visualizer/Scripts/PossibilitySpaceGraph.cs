using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace WaveFunctionCollapse
{
    

    public class PossibilitySpaceGraph : MonoBehaviour
    {
        // Maps from a position to a list of adjacent nodes
        public Dictionary<Vector3Int, List<PossibilitySpace>> adjacencyGraph;
        public List<PossibilitySpace> possibilitySpaces;

        // Prefab for possibility spaces
        public GameObject possibilitySpacePrefab;

        // Generator Functions
        public PossibilitySpaceGraph GenerateRectangularVolume(int xDimension, int yDimension, int zDimension)
        {
            PossibilitySpaceGraph result = new PossibilitySpaceGraph();
            
            // Iterator so we don't have to keep creating new ones
            Vector3Int index = Vector3Int.zero;

            // Instatiate the possibility spaces
            for(int x = 0; x < xDimension; x++)
            {
                for(int y = 0; y < yDimension; y++)
                {
                    for(int z = 0; z < zDimension; z++)
                    {
                        // Check if it is already in the graph
                        index.x = x;
                        index.y = y;
                        index.z = z;
                        if(adjacencyGraph.ContainsKey(index)) 
                            continue;
                        
                        // If it isn't in the graph, add it
                        GameObject newObject = Instantiate(possibilitySpacePrefab);
                        newObject.transform.parent = gameObject.transform;
                        newObject.transform.position = index;
                    }
                }
            }

            return result;
        }

        // Have each possibility space find its neighbors
        public void FindNeighbors()
        {
            foreach(Transform child in transform)
            {

            }
        }
    }
}
