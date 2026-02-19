using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string ItemId;
    public string ItemName;
    public Sprite ItemIcon;
    public bool IsStackable;
}
