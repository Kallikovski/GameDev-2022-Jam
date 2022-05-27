using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileVelocity;

    private Vector3 moveDircetion;
    private Vector3 velocity;

    [SerializeField] private float mouseSensetivity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float gravity;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Rotate();
        //Shoot();
        Transfer();

    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            //velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDircetion = new Vector3(moveX, 0, moveZ).normalized;
        moveDircetion = transform.TransformDirection(moveDircetion);

        if (isGrounded)
        {
            if (moveDircetion != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDircetion != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDircetion == Vector3.zero)
            {
                Idle();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        moveDircetion *= moveSpeed;

        controller.Move(moveDircetion * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        // Idel Animation
    }

    private void Walk()
    {
        // Walk Animation
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        // Run Animation
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        Debug.Log("Jump");
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(projectilePrefab, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, projectileVelocity, 0));
        }
        // Projectile to kill enemies
    }

    private void Transfer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    Debug.Log(hit.rigidbody);
                    GameObject target = hit.transform.gameObject;
                    PlayerController controllerScript = target.AddComponent<PlayerController>() as PlayerController;
                    CopyValues(controllerScript);
                    CameraController cameraScript = target.AddComponent<CameraController>() as CameraController;
                    GameObject targetCameraPivot = target.transform.GetChild(0).gameObject;
                    Camera camera = Camera.main;
                    camera.transform.SetParent(targetCameraPivot.transform);
                    camera.transform.position = target.transform.position;
                    GameObject targetGroundCheck = target.transform.GetChild(1).gameObject;
                    controllerScript.groundCheck = targetGroundCheck.transform;
                    Destroy(gameObject);
                }
            }
        }
        // Transfere to new body, after health points fell to 0, raycast
    }

    private void CopyValues(PlayerController other)
    {
        other.moveSpeed = moveSpeed;
        other.walkSpeed = walkSpeed;
        other.runSpeed = runSpeed;
        other.jumpHeight = jumpHeight;

        other.projectilePrefab = projectilePrefab;
        other.projectileVelocity = projectileVelocity;

        other.moveDircetion = moveDircetion;
        other.velocity = velocity;

        other.mouseSensetivity = mouseSensetivity;

        other.isGrounded = isGrounded;
        other.groundCheckDistance = groundCheckDistance;
        other.groundMask = groundMask;
        //other.groundCheck = groundCheck;
        other.gravity = gravity;

        other.controller = controller;
    }
}

