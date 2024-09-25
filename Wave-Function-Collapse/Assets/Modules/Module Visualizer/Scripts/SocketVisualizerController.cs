using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SocketVisualizerController : MonoBehaviour
{
    // left, right, front, back, top, bottom
    public List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>(); 
    public ModuleData moduleData;

    private void Start()
    {
        DisplayModuleData();
    }

    // Indexes for corresponding sides: 
    // 0 = Left, 1 = Right, 2 = Front, 3 = Back, 4 = Top, 5 = Bottom
    public void DisplayModuleData()
    {
        if (moduleData == null || textMeshProUGUIs.Count < 6)
        {
            Debug.LogError("ModuleData or textMeshProUGUIs not set up correctly!");
            return;
        }

        // Display the module data along with the "S" if symmetrical
        textMeshProUGUIs[0].text = $"Left: {moduleData.left}" + (moduleData.isLeftSymmetrical ? " S" : "");
        textMeshProUGUIs[1].text = $"Right: {moduleData.right}" + (moduleData.isRightSymmetrical ? " S" : "");
        textMeshProUGUIs[2].text = $"Front: {moduleData.front}" + (moduleData.isFrontSymmetrical ? " S" : "");
        textMeshProUGUIs[3].text = $"Back: {moduleData.back}" + (moduleData.isBackSymmetrical ? " S" : "");
        textMeshProUGUIs[4].text = $"Top: {moduleData.top}" + (moduleData.isTopSymmetrical ? " S" : "");
        textMeshProUGUIs[5].text = $"Bottom: {moduleData.bottom}" + (moduleData.isBottomSymmetrical ? " S" : "");
    }
}
