using UnityEngine;

[CreateAssetMenu(fileName = "new_movementTemplate", menuName = "Templates/Movement")]
public class MovementTemplate : ScriptableObject
{
    [SerializeField] private float m_speed = 1f;

    public float Speed { get => m_speed; }
}
