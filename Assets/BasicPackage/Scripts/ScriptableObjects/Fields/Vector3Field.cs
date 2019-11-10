using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3", menuName = "Basic/Vector3 Field")]
public class Vector3Field : ScriptableObject {

    [SerializeField]
    Vector3 value;

    [Tooltip("You don't have to use it!")]
    public GameEvent onChangeEvent;

    public void SetValue(Vector3 v)
    {
        value = v;
        //fire event here
        if (onChangeEvent != null)
            onChangeEvent.Raise();
    }

    public Vector3 GetValue()
    {
        return value;
    }
}
