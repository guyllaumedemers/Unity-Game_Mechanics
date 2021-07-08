using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    PlayerInputActions inputs;
    public bool CanReceiveInput { get; private set; }
    public bool InputReceived { get; private set; }

    /****************FLOW********************/

    private void Awake()
    {
        Instance = this;
        inputs = new PlayerInputActions();
        inputs.Player.Fire.performed += ctx => PerformAttack();
    }

    private void Start() => CanReceiveInput = true;

    /****************ACTIONS*****************/

    public void PerformAttack()
    {
        if (CanReceiveInput)
        {
            CanReceiveInput = false;
            InputReceived = true;
        }
    }

    public void UpdateInputManagement(bool inputStatus, bool value) => inputStatus = value;

    /****************INPUTS*****************/

    private void OnEnable() => inputs.Enable();

    private void OnDisable() => inputs.Disable();
}
