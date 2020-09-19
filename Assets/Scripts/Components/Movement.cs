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
        if (!m_initialized) return;

        float distance = m_currentSpeed * Time.deltaTime;

        if (m_solidObject != null)
        {
            Vector3 dir = Vector3.zero;
            dir.x = direction.x;

            if (m_solidObject.IsInContactWithObject(dir, out RaycastHit hit)) return;

            dir.x = 0f;
            dir.z = direction.z;

            if (m_solidObject.IsInContactWithObject(dir, out hit)) return;
        }

        Vector3 movement = direction * distance;
        transform.position += movement;
    }
}
