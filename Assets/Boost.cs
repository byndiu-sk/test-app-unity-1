using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Boost : MonoBehaviour
{
    [SerializeField] private BoostType _type;

    public BoostType Type => _type;
}