using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Planet", menuName ="Vodafone/Planet Data")]
public class PlanetData : ScriptableObject
{
    [TextArea]
    public string description;
}
