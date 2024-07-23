using System;
using UnityEngine;

[Serializable]
public class HpConfig
{
    [field: SerializeField, Min(1)] public int Hp { get; private set; }
}
