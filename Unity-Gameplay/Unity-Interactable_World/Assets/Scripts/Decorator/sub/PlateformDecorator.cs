using UnityEngine;

public class PlateformDecorator : ObjectDecorator
{
    private Rigidbody rb;

    public PlateformDecorator(IInteractable decoratorinstance, Rigidbody rb) : base(decoratorinstance)
    {
        if (!rb)
        {
            LogWarning("Rigidbody Argument is Null");
            return;
        }
        this.rb = rb;
        // Component initialization phase
        this.rb.isKinematic = true;
    }

    public override void PlayInteraction()
    {
        Debug.Log("Plateform Decorator Interaction Action");
        rb.isKinematic = false;
    }

    private void LogWarning(string msg) => Debug.LogWarning("[Plateform Decorator] : " + msg);
}
