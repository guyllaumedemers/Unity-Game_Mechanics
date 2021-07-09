using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    PlayerInputActions inputs;
    Animator anim;

    private const float speed = 50.0f;

    /****************FLOW********************/

    private void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        inputs = new PlayerInputActions();
        inputs.Player.Dir_pad.performed += ctx => RegisterKey(GetDPadDirection());
        inputs.Player.ActionButton_1.performed += ctx => RegisterKey(new InputKey(Globals.sqr, Time.time));
        inputs.Player.ActionButton_2.performed += ctx => RegisterKey(new InputKey(Globals.trg, Time.time));
        inputs.Player.ActionButton_3.performed += ctx => RegisterKey(new InputKey(Globals.cir, Time.time));
        inputs.Player.ActionButton_4.performed += ctx => RegisterKey(new InputKey(Globals.x, Time.time));
    }

    /****************ACTIONS*****************/

    private void RegisterKey(InputKey key)
    {
        // register the value to the event queue handle by the combo system
        //
        // how would i go about registering the player movement from the d-pad but also switch from simple movement to registering the direction pressed
    }

    // will handle later the diagonal values of combining dpad values
    private InputKey GetDPadDirection()
    {
        Vector2 dir = inputs.Player.Dir_pad.ReadValue<Vector2>();
        if (dir.x >= Globals.max) return new InputKey(DirectionEnum.RIGHT.ToString().ToLower(), Time.time);
        else if (dir.x <= Globals.min) return new InputKey(DirectionEnum.LEFT.ToString().ToLower(), Time.time);
        else if (dir.y <= Globals.min) return new InputKey(DirectionEnum.DOWN.ToString().ToLower(), Time.time);
        else if (dir.y >= Globals.max) return new InputKey(DirectionEnum.UP.ToString().ToLower(), Time.time);
        throw new System.ArgumentOutOfRangeException();
    }

    private void Move()
    {
        Vector2 move = inputs.Player.Dir_pad.ReadValue<Vector2>();
        transform.position += new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
    }

    /****************INPUTS*****************/

    private void OnEnable() => inputs.Enable();

    private void OnDisable() => inputs.Disable();
}
