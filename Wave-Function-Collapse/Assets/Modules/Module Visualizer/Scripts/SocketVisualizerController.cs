using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PossibilitySpace))]
public class SocketVisualizerController : MonoBehaviour
{
    public PossibilitySpace possibilitySpace;
    // left, right, front, back, top, bottom
    public List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>(); 

    private void Start()
    {
        if(possibilitySpace == null)
            possibilitySpace = GetComponent<PossibilitySpace>();
        DisplayModuleData();
    }

    // Indexes for corresponding sides: 
    // 0 = Left, 1 = Right, 2 = Front, 3 = Back, 4 = Top, 5 = Bottom
    public void DisplayModuleData()
    {
        if (possibilitySpace.moduleData == null || textMeshProUGUIs.Count < 6)
        {
            Debug.LogError("ModuleData or textMeshProUGUIs not set up correctly!");
            return;
        }

        // Display the module data along with the "S" if symmetrical
        textMeshProUGUIs[0].text = $"Left: {possibilitySpace.moduleData.left}" + (possibilitySpace.moduleData.isLeftSymmetrical ? " S" : "");
        textMeshProUGUIs[1].text = $"Right: {possibilitySpace.moduleData.right}" + (possibilitySpace.moduleData.isRightSymmetrical ? " S" : "");
        textMeshProUGUIs[2].text = $"Front: {possibilitySpace.moduleData.front}" + (possibilitySpace.moduleData.isFrontSymmetrical ? " S" : "");
        textMeshProUGUIs[3].text = $"Back: {possibilitySpace.moduleData.back}" + (possibilitySpace.moduleData.isBackSymmetrical ? " S" : "");
        textMeshProUGUIs[4].text = $"Top: {possibilitySpace.moduleData.top}" + (possibilitySpace.moduleData.isTopSymmetrical ? " S" : "");
        textMeshProUGUIs[5].text = $"Bottom: {possibilitySpace.moduleData.bottom}" + (possibilitySpace.moduleData.isBottomSymmetrical ? " S" : "");
    }
}
