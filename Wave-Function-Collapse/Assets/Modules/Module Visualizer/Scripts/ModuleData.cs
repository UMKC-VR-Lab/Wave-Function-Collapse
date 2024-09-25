using UnityEngine;

[CreateAssetMenu(fileName = "New Module Data", menuName = "Wave Function Collapse/Module Data")]
public class ModuleData : ScriptableObject
{
    // Module sides
    public string moduleName;
    public string top;
    public string bottom;
    public string left;
    public string right;
    public string front;
    public string back;

    // Whether the sides are symmetrical or not
    public bool isTopSymmetrical;
    public bool isBottomSymmetrical;
    public bool isLeftSymmetrical;
    public bool isRightSymmetrical;
    public bool isFrontSymmetrical;
    public bool isBackSymmetrical;
}
