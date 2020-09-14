using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidObject : MonoBehaviour
{
    [SerializeField] private float m_raycastDistance = 0.5f;
    [SerializeField] private Vector3 m_raycastOffset = Vector3.zero;

    [Header("Debug")]
    [SerializeField] private float m_raycastTime = 0.5f;
    [SerializeField] private Color m_raycastColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool IsInContactWithObject(Vector3 direction, out RaycastHit hit)
    {
        Vector3 origin = transform.position + m_raycastOffset;

#if UNITY_EDITOR
        Debug.DrawRay(transform.position + m_raycastOffset, direction * m_raycastDistance, m_raycastColor, m_raycastTime);
#endif

        return Physics.Raycast(origin, direction, out hit, m_raycastDistance);
    }
}
