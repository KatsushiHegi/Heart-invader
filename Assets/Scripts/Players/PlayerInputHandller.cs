using UnityEngine;

public class PlayerInputHandller : MonoBehaviour
{
    bool _fireInputWasHeld;
    Plane _rayPlane = new Plane();

    private void LateUpdate()
    {
        _fireInputWasHeld = GetFireInputHeld();
    }

    //止めたり
    public bool CanProcessInput()
    {
        return true;
    }
    public Vector3 GetMoveInput()
    {
        //if (CanProcessInput())
        {
            Vector3 move = new Vector3(Input.GetAxisRaw(PlayerConstants.AXIS_NAME_HORIZONTAL), 0f, Input.GetAxisRaw(PlayerConstants.AXIS_NAME_VERTICAL));

            move = Vector3.ClampMagnitude(move, 1);
            return move;
        }

        return Vector3.zero;
    }

    public bool GetFireInputDown()
    {
        if(GetFireInputHeld() && !_fireInputWasHeld) Debug.Log("Down");
        return GetFireInputHeld() && !_fireInputWasHeld;
    }

    public bool GetFireInputReleased()
    {
        return !GetFireInputHeld() && _fireInputWasHeld;
    }

    public bool GetFireInputHeld()
    {
        //if (CanProcessInput())
        {
            return Input.GetButton(PlayerConstants.BUTTON_NAME_FIRE);
        }

        return false;
    }

    public Vector3 GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _rayPlane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (_rayPlane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }

}
