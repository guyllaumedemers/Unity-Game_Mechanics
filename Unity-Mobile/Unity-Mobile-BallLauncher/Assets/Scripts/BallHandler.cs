using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private float delayTime;
    [SerializeField] Rigidbody2D pivot;
    SpringJoint2D sj2D_ball;
    Rigidbody2D r2D_ball;

    private void Awake()
    {
        r2D_ball = GetComponent<Rigidbody2D>();
        sj2D_ball = GetComponent<SpringJoint2D>();
        r2D_ball.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update()
    {
        if (!r2D_ball)
        {
            return;
        }
        else if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 screenpos = Touchscreen.current.primaryTouch.position.ReadValue();
            r2D_ball.position = ConvertFromTouchToWorld(screenpos);
            r2D_ball.bodyType = RigidbodyType2D.Kinematic;
            return;
        }
        else if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame)
        {
            LaunchBall();
            Invoke(nameof(DetachBall), delayTime);
            Invoke(nameof(ResetBall), 2.0f);
        }
    }

    private void LaunchBall()
    {
        r2D_ball.bodyType = RigidbodyType2D.Dynamic;
        //r2D_ball = null;
    }

    private void DetachBall()
    {
        sj2D_ball.enabled = false;
        //sj2D_ball = null;
    }

    //You could either instanciate new ball or reset the position depending on what you are looking for in your game
    //Angry birds keep their birds alive on the screen but it implies calling Instanciate which is a processing mid-heavy function call
    private void ResetBall()
    {
        transform.position = pivot.position;
        sj2D_ball.enabled = true;
        r2D_ball.velocity = Vector2.zero;
    }

    private Vector2 ConvertFromTouchToWorld(Vector2 screenpos)
    {
        return Camera.main.ScreenToWorldPoint(screenpos);
    }
}
