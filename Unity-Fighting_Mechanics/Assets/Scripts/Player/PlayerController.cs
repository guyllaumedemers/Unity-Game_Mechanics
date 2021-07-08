using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    PlayerInputActions inputs;
    public bool CanReceiveInput { get; private set; }
    public bool InputReceived { get; private set; }

    private const float speed = 50.0f;

    /****************FLOW********************/

    private void Awake()
    {
        Instance = this;
        inputs = new PlayerInputActions();
        inputs.Player.Move.performed += ctx => Move();
        //inputs.Player.Fire.performed += ctx => PerformAttack();
    }

    private void Start() => CanReceiveInput = true;

    /****************ACTIONS*****************/

    private void Move()
    {
        Vector2 move = inputs.Player.Move.ReadValue<Vector2>();
        transform.position += new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
    }

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
