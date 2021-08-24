using UnityEngine;

public class PlateformComponent : ObjectComponent
{
    private Rigidbody rb;
    private Collider col;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
        this.col = GetComponent<Collider>();
        if (!rb)
        {
            LogWarning("There is no Rigidbody Component Attach to this gameobject : " + gameObject.name);
            return;
        }
        else if (!col)
        {
            LogWarning("There is no Collider Component Attach to this gameobject : " + gameObject.name);
            return;
        }

        RegisterModifier(new PlateformDecorator(this, rb));
    }

    private void LogWarning(string msg) => Debug.LogWarning("[Plateform Component] : " + msg);
}
