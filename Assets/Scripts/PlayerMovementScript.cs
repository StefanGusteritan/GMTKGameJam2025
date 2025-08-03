using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] LevelManagerScript levelManager;
    [SerializeField] Rigidbody2D body;
    [SerializeField] float speed, jumpForce, gravitationalAcceleration;
    float yMovement = 0;
    bool onFloor, canJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            body.position += Vector2.left * speed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.D))
            body.position += Vector2.right * speed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.W) && canJump)
            yMovement += jumpForce;

        if (!onFloor)
            yMovement -= gravitationalAcceleration / 2 * Time.fixedDeltaTime;

        body.position += Vector2.up * yMovement * Time.fixedDeltaTime;

        if (!onFloor)
            yMovement -= gravitationalAcceleration / 2 * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
            levelManager.Win();
        if (collision.tag == "Floor")
        {
            onFloor = true;
            yMovement = 0;
        }
        if (collision.tag == "JumpArea")
            canJump = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
            onFloor = false;
        if (collision.tag == "JumpArea")
            canJump = false;
    }
}
