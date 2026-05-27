using UnityEngine;
using System.Collections;

public enum BlockTypeSecret
{
    Normal,
    Hard,
    Unbreakable
}

public class BlockSecret : MonoBehaviour
{
    [Header("Configuraci�n")]
    GameManager gameManager;

    [SerializeField] int points = 10;
    [SerializeField] int hitPoints = 1;
    int maxHitPoints;

    [SerializeField] bool countsForVictory = true;

    [Header("Sprites")]
    [SerializeField] Sprite normalSprite;
  

    private bool isBreaking = false;
    private SpriteRenderer sr;
    private BlockTypeSecret blockType;

    public int Points => points;
    public bool CountsForVictory => countsForVictory;

    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Configure(BlockTypeSecret newType)
    {
        blockType = newType;
        isBreaking = false;

        switch (blockType)
        {
            case BlockTypeSecret.Normal:
                maxHitPoints = 1;
                hitPoints = maxHitPoints;
                points = 30;
                countsForVictory = true;
                sr.sprite = normalSprite;
                break;
        }
    }
    public void TakeHit()
    {
        if (isBreaking) return;

        if (blockType == BlockTypeSecret.Unbreakable)
        {
            // M�s adelante podemos poner aqu� sonido/animaci�n de impacto.
            return;
        }
    }
}