using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private float torque;                      // rotational force
    private int dir;
    private Vector3 centerLocation;

    private void Awake()
    {
        wheels = GetComponentsInChildren<WheelCollider>();
        torque = 200.0f;
    }

    private void Update()
    {
        float acc = Input.GetAxis("Vertical");                              // need to convert the key input to handle Touchscreen
        Accelerate(acc);
    }

    public void Accelerate(float acc)
    {
        for (int i = 0; i < wheels.Length; ++i)
        {
            wheels[i].motorTorque = torque * Mathf.Clamp(acc, -1, 1);

            Quaternion quat;
            Vector3 position;
            wheels[i].GetWorldPose(out position, out quat);
            wheels[i].gameObject.transform.position = position;
            wheels[i].gameObject.transform.rotation = quat;
        }
    }

    public void Steer(int dir)
    {
        for (int j = 0; j < wheels.Length / 2; ++j)
        {
            //wheels[j].steerAngle += torque * dir * Time.deltaTime;
        }
    }
}
