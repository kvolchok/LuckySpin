using UnityEngine;

[CreateAssetMenu(fileName = "PrizeModel", menuName = "ScriptableObject/PrizeModel", order = 50)]
public class PrizeModel : ScriptableObject
{
    [field:SerializeField]
    public float MinAngle { get; private set; }
    [field:SerializeField]
    public float MaxAngle { get; private set; }
    
    [field:SerializeField]
    public PrizeType Type { get; private set; }
    [field:SerializeField]
    public string Name { get; private set; }
    [field:SerializeField]
    public Sprite Icon { get; private set; }
    [field:SerializeField]
    public int Value { get; private set; }
}