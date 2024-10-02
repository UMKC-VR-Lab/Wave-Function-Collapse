using System.Collections.Generic;
using UnityEngine;
using System;

namespace WaveFunctionCollapse 
{
    public enum Direction { North, South, East, West, Top, Bottom }

    public class ModuleData : MonoBehaviour
    {
        public string moduleName;
        public Face north, south, east, west, top, bottom;
    }

    [Serializable]
    public class Face
    {
        public List<FaceAttribute> attributes;
        public bool hasAttributeOnFace(FaceAttribute attribute)
        {
            for(int i = 0; i < attributes.Count; i++)
            {
                if(attributes[i] == attribute)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            string attributesString = "";
            
            for(int i = 0; i < attributes.Count; i++)
                attributesString += attributes[i].attribute + " ";

            return attributesString;
        }
    }
}
