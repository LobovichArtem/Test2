using System;
using UnityEngine;

[Serializable]
public class GunConfig
{
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField, Min(1)] public int Damage { get; private set; }
    [field: SerializeField] public float BulletSpeed { get; private set; }
    [field: SerializeField] public float Radius { get; private set; }

}
