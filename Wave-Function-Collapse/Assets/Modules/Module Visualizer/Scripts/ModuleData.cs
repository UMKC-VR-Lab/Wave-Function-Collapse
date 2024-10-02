using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionCollapse 
{
    public enum Direction { North, South, East, West, Top, Bottom }

    [CreateAssetMenu(fileName = "New Module Data", menuName = "Wave Function Collapse/Module Data")]
    public class ModuleData : ScriptableObject
    {
        public string moduleName;
        public List<ModuleData> compositionModules;
        public Face north, south, west, east, top, bottom;
    }

    [Serializable]
    public class Face
    {
        public List<FaceAttribute> Properties;
    }
}
