using System.Collections.Generic;
using WaveFunctionCollapse;
using UnityEngine;
using TMPro;

public class ModuleVisualizer : MonoBehaviour
{
    // Indices for corresponding sides: 
    // 0 = North, 1 = South, 2 = East, 3 = West, 4 = Top, 5 = Bottom
    public List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>();
    
    public void DisplayModuleData(ModuleData targetData)
    {
        // Display the module data along with the "S" if symmetrical
        textMeshProUGUIs[0].text = $"North: {targetData.north.ToString()}";
        textMeshProUGUIs[1].text = $"South: {targetData.south.ToString()}";
        textMeshProUGUIs[2].text = $"East: {targetData.east.ToString()}";
        textMeshProUGUIs[3].text = $"West: {targetData.west.ToString()}";
        textMeshProUGUIs[4].text = $"Top: {targetData.top.ToString()}";
        textMeshProUGUIs[5].text = $"Bottom: {targetData.bottom.ToString()}";
    }
}
