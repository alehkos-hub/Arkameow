using UnityEngine;

public class DeathZone : MonoBehaviour
{
    GameManager gm;
    void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.GetComponent<BallController>() != null)
        {
            gm.LoseLife();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
