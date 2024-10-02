using System.Collections.Generic;
using WaveFunctionCollapse;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ModuleData))]
public class ModuleVisualizer : MonoBehaviour
{
    public ModuleData moduleData;

    // Indices for corresponding sides: 
    // 0 = North, 1 = South, 2 = East, 3 = West, 4 = Top, 5 = Bottom
    public List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>();

    private void Start()
    {
        if(moduleData == null)
            moduleData = GetComponent<ModuleData>();
        
        DisplayModuleData();
    }

    public void DisplayModuleData()
    {
        // Display the module data along with the "S" if symmetrical
        textMeshProUGUIs[0].text = $"North: {moduleData.north.ToString()}";
        textMeshProUGUIs[1].text = $"South: {moduleData.south.ToString()}";
        textMeshProUGUIs[2].text = $"East: {moduleData.east.ToString()}";
        textMeshProUGUIs[3].text = $"West: {moduleData.west.ToString()}";
        textMeshProUGUIs[4].text = $"Top: {moduleData.top.ToString()}";
        textMeshProUGUIs[5].text = $"Bottom: {moduleData.bottom.ToString()}";
    }
}
