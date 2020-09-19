using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class SolidObject : MonoBehaviour
{
    private static readonly List<Vector3> m_directions = new List<Vector3>()
    {
        new Vector3(1f, 0f, 0f), new Vector3(-1f, 0f, 0f), new Vector3(0f, 0f, 1f), new Vector3(0f, 0f, -1f), 
        new Vector3(1f, 0f, 1f), new Vector3(-1f, 0f, -1f), new Vector3(1f, 0f, -1f), new Vector3(-1f, 0f, 1f)
    };

    [SerializeField] private float m_raycastDistance = 0.5f;
    [SerializeField] private Vector3 m_raycastOffset = Vector3.zero;
    [SerializeField] private float m_sphereRadius = 0.5f;
    [SerializeField] LayerMask m_layers;

    [Header("Debug")]
    [SerializeField] private float m_raycastTime = 0.5f;
    [SerializeField] private Color m_raycastColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool IsInContactWithObject(Vector3 position, Vector3 direction)
    {
        return IsInContactWithObject(position, m_directions);
    }

    private bool IsInContactWithObject(Vector3 position, List<Vector3> directions)
    {
        int size = directions.Count;
        for (int i = 0; i < size; i++)
        {
            if (CheckContactInDirection(position, directions[i])) return true;
        }

        return false;
    }

    private bool CheckContactInDirection(Vector3 position, Vector3 direction)
    {
        Vector3 center = position + m_raycastOffset + (direction * m_raycastDistance);

        DrawDebugLine(center, Vector3.right, m_sphereRadius);
        DrawDebugLine(center, Vector3.forward, m_sphereRadius);

        Collider[] colliders = Physics.OverlapSphere(center, m_sphereRadius, m_layers.value);
        return colliders != null && colliders.Length > 0;
    }

    private void DrawDebugLine(Vector3 pos, Vector3 axis, float radius)
    {
        Debug.DrawLine(pos + axis, pos - axis, m_raycastColor, m_raycastTime);
    }

}
