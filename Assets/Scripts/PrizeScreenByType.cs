using System;
using UnityEngine;

[Serializable]
public class PrizeScreenByType
{
    [field:SerializeField]
    public PrizeType Type { get; private set; }
    [field:SerializeField]
    public PrizeScreen Screen { get; private set; }
}