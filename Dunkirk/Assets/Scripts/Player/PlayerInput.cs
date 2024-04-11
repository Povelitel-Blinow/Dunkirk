using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputPad _pad;

    public float GetRotation()
    {
        return _pad.GetRotDirection();
    }
}
