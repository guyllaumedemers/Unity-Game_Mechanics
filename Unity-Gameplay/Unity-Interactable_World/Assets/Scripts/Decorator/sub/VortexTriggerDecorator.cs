using UnityEngine;
using UnityEngine.VFX;

public class VortexTriggerDecorator : ObjectDecorator
{
    private VisualEffect vfxgraph;

    public VortexTriggerDecorator(IInteractable instanceDecorator, VisualEffect vfxComponent) : base(instanceDecorator)
    {
        this.vfxgraph = vfxComponent;
    }

    public override void PlayInteraction()
    {
        Debug.Log("Vortex Decorator interaction Action");
        vfxgraph.enabled = true;
    }
}
