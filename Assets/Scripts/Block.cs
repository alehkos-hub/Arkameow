using UnityEngine;
using System.Collections;
public class Block : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] int points = 10;
    [SerializeField] int hitPoints = 2;
    [SerializeField] private GameObject breakEffect;
    [SerializeField] private Animator breakAnimator;
    [SerializeField] private float destroyDelay = 0.25f;
    [SerializeField] private Sprite[] damageSprites;
    private SpriteRenderer sr;
    private bool isBreaking = false;
    public int Points => points;
    void Start()
    {
        UpdateVisual();
    }
    public void DestroyBlock()
    {
        Destroy(gameObject);
    }
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void TakeHit()
    {
        if (isBreaking) return;
        hitPoints--;
        if (hitPoints <= 0)
        {
            isBreaking = true;
            gameManager.AddScore(Points);
            if (breakEffect != null)
                breakEffect.SetActive(true);

            if (sr != null)
                sr.enabled = false;
            if (breakAnimator != null)
                breakAnimator.SetTrigger("Break");
            StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            sr.color = Color.red;
            UpdateVisual();
        }
    }
    IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
    void UpdateVisual()
    {
        if (damageSprites == null || damageSprites.Length == 0) return;
        int index = Mathf.Clamp(hitPoints - 1, 0, damageSprites.Length - 1);
        sr.sprite = damageSprites[index];
    }
}