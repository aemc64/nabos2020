using UnityEngine;

[CreateAssetMenu(fileName = "new_collectableItemTemplate", menuName = "Templates/CollectableItem")]
public class CollectableItemTemplate : ScriptableObject
{
    [SerializeField] private Sprite m_image = null;

    public Sprite Image { get => m_image; }
}
