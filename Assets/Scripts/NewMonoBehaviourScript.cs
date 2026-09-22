using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            horizontalInput,
            0f,
            verticalInput
        );

        rb.MovePosition(
            rb.position + movement * speed * Time.fixedDeltaTime
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Зіткнення з об'єктом: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Гравець зіткнувся з фізичною перешкодою!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Вхід у тригерну зону: " + other.gameObject.name);

        if (other.CompareTag("TriggerZone"))
        {
            Debug.Log("Гравець увійшов у контрольну зону!");
        }
    }
}