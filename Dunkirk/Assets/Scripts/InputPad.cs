using UnityEngine;
using UnityEngine.UI;

public class InputPad : MonoBehaviour
{
    [SerializeField] private Button _buttonL;
    [SerializeField] private Button _buttonR;

    private bool _buttonStateL = false;
    private bool _buttonStateR = false;

    public float GetRotDirection()
    {
        if (_buttonStateL && _buttonStateR) return 0;

        if (_buttonStateL) return 1;

        if (_buttonStateR) return -1;

        return 0;
    }

    public void ButtonPressedL(bool state)
    {
        _buttonStateL = state;
    }

    public void ButtonPressedR(bool state)
    {
        _buttonStateR = state;
    }
}
