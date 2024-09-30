using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

namespace WaveFunctionCollapse
{
    public class PossibilitySpace 
    {
        // All the possible states this space could be in
        public List<ModuleData> possibleStates;
        // All faces valid on each side of the cube
        public List<HashSet<string>> possibleFaces;

        // References to neighboring possibility spaces
        public PossibilitySpace posXNeighbor, negXNeighbor, posZNeighbor, negZNeighbor, posYNeighbor, negYNeighbor;
        


        // Called by the collapse function and then by neighbors
        public void Constrain(List<ModuleData> newValidStates, List<HashSet<string>> newPossibleFaces)
        {
            // For each face
            for(int i = 0; i < possibleFaces.Count; i++)
            {
                // if we lost faces on this face
                if(newPossibleFaces[i].Count < possibleFaces[i].Count)
                {
                    // propagate that to adjacent neighbors if so

                }
            }
        }


    }

    public class PossibilitySpaceMatrix : MonoBehaviour
    {
    }
}
