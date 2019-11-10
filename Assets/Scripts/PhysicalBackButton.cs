using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalBackButton : MonoBehaviour, IGazeInput
{
    public GameEvent ResumeRotationEvent;

    public void OnGaze()
    {
        ResumeRotationEvent.Raise();
    }
}
