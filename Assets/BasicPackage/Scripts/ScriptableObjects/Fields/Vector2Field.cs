using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector2", menuName = "Basic/Vector2 Field")]
public class Vector2Field : ScriptableObject {

    [SerializeField]
    Vector2 value;

    [Tooltip("You don't have to use it!")]
    public GameEvent onChangeEvent;

    public void SetValue(Vector2 v)
    {
        value = v;
        //fire event here
        if (onChangeEvent != null)
            onChangeEvent.Raise();
    }

    public Vector2 GetValue()
    {
        return value;
    }
}
