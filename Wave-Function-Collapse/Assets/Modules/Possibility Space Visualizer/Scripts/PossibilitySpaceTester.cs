using UnityEngine;

public class PossibilitySpaceTester : MonoBehaviour
{
    public GameObject blockPrefab, invalidBlockPrefab;
    public Vector3 newPos;
    public int totalPossibilities;
    public int validPossibilities;

    // Call this function from the editor or another script to spawn a visualization
    public void SpawnVisualization()
    {
        // Make sure we have prefabs
        if (blockPrefab == null)
        {
            Debug.LogError("Block prefab is not assigned.");
            return;
        }
        if (invalidBlockPrefab == null)
        {
            Debug.LogError("Invalid Block prefab is not assigned.");
            return;
        }

        // Make sure the number of valid possibilities does not exceed total possibilities
        if (validPossibilities > totalPossibilities)
        {
            Debug.LogError("Valid possibilities cannot exceed total possibilities.");
            return;
        }

        // Create the visual
        GameObject visualization = PossibilitySpaceVisualizer.Visualize(newPos, blockPrefab, invalidBlockPrefab, totalPossibilities, validPossibilities);
        visualization.transform.SetParent(this.transform);
    }

    // Call the function on spacebar down
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnVisualization();
        }
    }
}
