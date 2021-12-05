using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 10.0f;
    public float minZ = -94.0f;
    public float timeOnCollision = 0.0f;

    public Vector3 drag = new Vector3(0.1f, 0, 1.0f);

    private float m_HorizontalInput;
    private float m_VerticalInput;

    private bool m_onCollision;

    private Rigidbody m_PlayerRb;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerRb = GetComponent<Rigidbody>();
        m_onCollision = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.hasWon && !GameManager.hasLost)
        {
            m_HorizontalInput = Input.GetAxis("Horizontal");
            m_VerticalInput = Input.GetAxis("Vertical");

            m_PlayerRb.AddRelativeForce(Vector3.right * movementSpeed * m_VerticalInput, ForceMode.Force);
            m_PlayerRb.AddRelativeTorque(Vector3.up * rotationSpeed * m_HorizontalInput, ForceMode.Force);
        }

        // Add drag
        Vector3 localNormalVelocity = transform.InverseTransformVector(m_PlayerRb.velocity).normalized;
        m_PlayerRb.AddRelativeForce(Vector3.Scale(m_PlayerRb.velocity.sqrMagnitude * drag, -localNormalVelocity), ForceMode.Force);

        if (transform.position.z < minZ)
        {
            m_PlayerRb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }
    }

    private void Update()
    {
        if (m_onCollision && m_PlayerRb.velocity.magnitude < 0.05f)
        {
            timeOnCollision += Time.deltaTime;
        }
        else
        {
            timeOnCollision = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_onCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        m_onCollision = false;
    }
}
