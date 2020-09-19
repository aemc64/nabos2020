using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private MovementTemplate m_template = null;

    private SolidObject m_solidObject = null;

    private float m_currentSpeed = 0f;
    private bool m_initialized = false;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (m_template == null) return;

        m_solidObject = GetComponent<SolidObject>();

        m_currentSpeed = m_template.Speed;

        m_initialized = true;
    }

    public void Move(Vector3 direction)
    {
        if (!m_initialized || direction.Equals(Vector3.zero)) return;

        float distance = m_currentSpeed * Time.deltaTime;
        Vector3 movement = direction * distance;
        Vector3 newPosition = transform.position + movement;

        if (m_solidObject != null && m_solidObject.IsInContactWithObject(newPosition, direction)) return;

        transform.position = newPosition;
    }
}
