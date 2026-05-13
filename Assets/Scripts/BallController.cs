using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [SerializeField] float maxBounceAngle = 75f;
    [SerializeField] float initialSpeed = 7f;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform paddleTransform;
    [SerializeField] Vector2 attachOffset = new Vector2(0f, 0.6f);


    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bounceClip;
    [SerializeField] AudioClip blockClip;

    [SerializeField] private GameObject bounceEffectPrefab;

    bool isAttached = true;

   

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       // Launch();
    }
    //void Launch()
    //{
    //    Vector2 direction = new Vector2(0.5f, 1f).normalized;
    //    rb.linearVelocity = direction * initialSpeed;
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boundaries"))
        {
            audioSource.PlayOneShot(bounceClip);
        }
            if (collision.collider.CompareTag("Paddle"))
        {
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 hitPoint = contact.point;

            float paddleX = collision.transform.position.x;
            float hitX = transform.position.x;

            float normalizedHit = Mathf.Clamp((paddleX - hitX) / 1.0f, -1f, 1f);

            float angle = normalizedHit * maxBounceAngle;

            Vector2 newDir = (Quaternion.Euler(0f, 0f, angle) * Vector2.up).normalized;

            float speed = rb.linearVelocity.magnitude;

            rb.linearVelocity = newDir * speed;

            audioSource.PlayOneShot(bounceClip);

            Instantiate(bounceEffectPrefab, hitPoint, Quaternion.identity);
        }
        Block block = collision.collider.GetComponent<Block>();
        if (block != null)
        {
            audioSource.PlayOneShot(blockClip);
            block.TakeHit();
            return;
        }
    }
    void Update()
    {
        if (gameManager.CurrentState != GameState.Playing) rb.simulated = false;
        if (isAttached && paddleTransform != null)
        {
            transform.position = paddleTransform.position + (Vector3)attachOffset;

            if (gameManager.CurrentState == GameState.Playing &&
            Input.GetKeyDown(KeyCode.Space))

                Launch();
        }
    }
    public void ResetBall(Vector2 position)
    {
        transform.position = position;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;
        isAttached = true;
    }
    public void Launch()
    {
        if (!isAttached) return;
        isAttached = false;
        rb.simulated = true;
        Vector2 dir = new Vector2(Random.Range(-0.3f, 0.3f), 1f).normalized;

        rb.linearVelocity = dir * initialSpeed;
    }
}