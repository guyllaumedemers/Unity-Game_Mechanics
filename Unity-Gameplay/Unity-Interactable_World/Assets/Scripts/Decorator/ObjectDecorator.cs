using UnityEngine;

public abstract class ObjectDecorator : IInteractable
{
    IInteractable instance;

    public ObjectDecorator(IInteractable decoratorInstance)
    {
        instance = decoratorInstance;
    }


    public virtual void PlayInteraction()
    {
        Debug.Log("Object Decorator interaction Action");   // THIS LINE SHOULD NEVER BE OUTPUTED
        instance.PlayInteraction();
    }
}
