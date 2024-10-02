using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace WaveFunctionCollapse
{
    /*
     * Maintains a list of Possibility Spaces (PS) and an
     * adjacency graph from an int position to a list of neighbors
     * Adds volumes of new PSs in via Generate Rectangular Volume and other functions
     * Sets up neighbors with FindNeighbors
     */

    public class PossibilitySpaceGraph : MonoBehaviour
    {
        // A link to all of the valid modules
        public List<GameObject> modules;

        // Maps from a position to a list of adjacent nodes
        public Dictionary<Vector3Int, List<PossibilitySpace>> adjacencyGraph;
        public List<PossibilitySpace> possibilitySpaces;

        // Prefab for possibility spaces
        public GameObject possibilitySpacePrefab;


        // Test in start
        private void Start()
        {
            modules = new();
            adjacencyGraph = new();
            possibilitySpaces = new();
            
            GenerateRectangularVolume(Vector3.zero, 4, 2, 5);
            FindNeighbors();
            DebugAdjacencyGraph();
        }

        // Link up the graph (very expensive operation)
        //    could just call it on newly added ps and as it adds neighbors, add itself to their list of neighbors
        //    and if a ps is removed, have it remove itself from its neighbors before deleting itself
        public void FindNeighbors()
        {
            for(int i = 0; i < possibilitySpaces.Count; i++)
            {
                List<PossibilitySpace> newNeighbors = possibilitySpaces[i].GetNeighbors();
                Vector3Int psPosition = Vector3Int.zero;
                psPosition.x = (int)possibilitySpaces[i].transform.position.x;
                psPosition.y = (int)possibilitySpaces[i].transform.position.y;
                psPosition.z = (int)possibilitySpaces[i].transform.position.z;
                adjacencyGraph[psPosition] = newNeighbors;
            }
        }

        // Generator Functions
        public void GenerateRectangularVolume(Vector3 offset, int xDimension, int yDimension, int zDimension)
        {
            // Iterator so we don't have to keep creating new ones
            Vector3Int index = Vector3Int.zero;

            // Instantiate the possibility spaces
            for(int x = 0; x < xDimension; x++)
            {
                for(int y = 0; y < yDimension; y++)
                {
                    for(int z = 0; z < zDimension; z++)
                    {
                        // Check if there is already a possibility space there
                        index.x = x;
                        index.y = y;
                        index.z = z;
                        if(adjacencyGraph.ContainsKey(index)) 
                            continue;
                        
                        // If it isn't in the graph, add it     
                        GameObject newObject = Instantiate(possibilitySpacePrefab, offset + index, Quaternion.identity, transform);
                        possibilitySpaces.Add(newObject.GetComponent<PossibilitySpace>());
                    }
                }
            }
        }

        // Function to debug the adjacency graph
        public void DebugAdjacencyGraph()
        {
            foreach (var node in adjacencyGraph)
            {
                // Print the position of the current PossibilitySpace
                Vector3Int position = node.Key;
                List<PossibilitySpace> neighbors = node.Value;

                Debug.Log($"PossibilitySpace at {position}:");

                // Print the positions of its neighbors
                if (neighbors.Count > 0)
                {
                    foreach (var neighbor in neighbors)
                    {
                        if (neighbor != null)
                        {
                            Vector3Int neighborPosition = new Vector3Int(
                                (int)neighbor.transform.position.x,
                                (int)neighbor.transform.position.y,
                                (int)neighbor.transform.position.z
                            );
                            Debug.Log($"  Neighbor at {neighborPosition}");
                        }
                    }
                }
                else
                {
                    Debug.Log("  No neighbors.");
                }
            }
        }
    }
}
