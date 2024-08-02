using UnityEngine;

public static class PossibilitySpaceVisualizer
{
    public static GameObject Visualize(Vector3 position, GameObject blockPrefab, GameObject invalidBlockPrefab, int totalPossibilities, int validPossibilities)
    {
        GameObject parent = new GameObject("VisualizationParent");
        parent.transform.position = position;

        // Find the smallest n such that n^3 >= totalPossibilities
        int cubeEdgeDimension = MinimumCubeDimension(totalPossibilities);

        float scale = 1.0f / cubeEdgeDimension;

        for (int i = 0; i < cubeEdgeDimension; i++)
        {
            for (int j = 0; j < cubeEdgeDimension; j++)
            {
                for (int k = 0; k < cubeEdgeDimension; k++)
                {
                    int index = k + j * cubeEdgeDimension + i * cubeEdgeDimension * cubeEdgeDimension;
                        

                    Vector3 newPrefabPos = Vector3.one * -0.5f + (Vector3.one * (scale / 2.0f));
                    newPrefabPos.x += (k * scale);
                    newPrefabPos.y += (i * scale);
                    newPrefabPos.z += (j * scale);

                    GameObject newVisualizerPrefab = (index >= validPossibilities) ?
                        newVisualizerPrefab = GameObject.Instantiate(invalidBlockPrefab, position + newPrefabPos, Quaternion.identity, parent.transform) :
                        newVisualizerPrefab = GameObject.Instantiate(blockPrefab, position + newPrefabPos, Quaternion.identity, parent.transform);
                        newVisualizerPrefab.transform.localScale = Vector3.one * scale * 0.9f;
                }
            }
        }

        return parent;
    }

    // Utility method to find the smallest integer n such that n^3 >= x
    private static int MinimumCubeDimension(int x)
    {
        int n = 1;
        while (n * n * n < x)
        {
            n++;
        }
        return n;
    }
}
