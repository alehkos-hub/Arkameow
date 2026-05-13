using UnityEngine;
public class PaddleController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float limitX = 7f;
    [SerializeField] GameManager gameManager;

    public KeyCode LeftKey = KeyCode.D;
    public KeyCode RightKey = KeyCode.A;

    void Update()
    {
        if (gameManager.CurrentState != GameState.Playing) return;

        float input = 0f;
        if (Input.GetKey(LeftKey))
        {
            input = 1f;
        }
        else if (Input.GetKey(RightKey))
        {
            input = -1f;
        }

        //float input = Input.GetAxis("Horizontal");

        Vector3 movement = Vector3.right * input * speed * Time.deltaTime;

        transform.Translate(movement);

        float clampedX = Mathf.Clamp(transform.position.x, -limitX, limitX);

        transform.position = new Vector3(clampedX, transform.position.y,

        transform.position.z);
    }
}