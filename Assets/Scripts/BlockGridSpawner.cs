using UnityEngine;
public class BlockGridSpawner : MonoBehaviour
{
    [Header("Prefab y contenedor")]
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform parent;
    [Header("Grid")]
    [SerializeField] int rows = 5;
    [SerializeField] int cols = 10;
    [SerializeField] Vector2 spacing = new Vector2(1.1f, 0.6f);
    [SerializeField] Vector2 startPosition = new Vector2(-5f, 3f);
    
    [ContextMenu("Spawn Grid")]
    public void Spawn()
    {
        if (blockPrefab == null)
        {
            Debug.LogError("Block");
            return;
        }
        if (parent == null)
            parent = transform;
        ClearParent();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Vector2 pos = startPosition + new Vector2(
                c * spacing.x,
                -r * spacing.y
                );
                Instantiate(blockPrefab, pos, Quaternion.identity, parent);
            }
        }
    }
    public int GetTotalBlocks()
    {
        return rows * cols;
    }
    [ContextMenu("ClearParent")]
    void ClearParent()
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }
}