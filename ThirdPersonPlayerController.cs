using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified code from: https://www.youtube.com/watch?v=7nxpDwnU0uU&ab_channel=StephenBarr

public class ThirdPersonPlayerController : MonoBehaviour
{
    public GameManager gm;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody playerRB = null;
    public PlayerInventory playerInv;

    public float jumpForce;

    public bool isOnGround;
    public float speed;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!playerRB) { gameObject.GetComponent<Animator>(); }
    }

    void Start()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRB = GetComponent<Rigidbody>();
        playerInv = GameObject.Find("PlayerInventory").GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("Grounded", isOnGround);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            m_animator.SetTrigger("Jump");
            isOnGround = false;
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        m_animator.SetFloat("MoveSpeed", hor + ver);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") == true)
        {
            isOnGround = true;
            m_animator.SetTrigger("Land");
        }
        if (collision.collider.CompareTag("Food") == true)
        {
            playerInv.updateFood(collision.collider.gameObject.name, 1);
            Destroy(collision.collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Pickup");
        }
        if (collision.collider.CompareTag("Poison") == true || collision.collider.CompareTag("Enemy") == true)
        {
            FindObjectOfType<AudioManager>().Play("Die");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gm.GameOver();
        }
    }
}
