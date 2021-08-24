using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

public class VortexTriggerComponent : ObjectComponent
{
    private VisualEffect vfxgraph;

    public object Matrix4x4 { get; private set; }

    private void Awake()
    {
        vfxgraph = FindObjectsOfType<VisualEffect>().Where(x => x.tag.Equals("Portal")).FirstOrDefault();
        if (!vfxgraph)
        {
            LogWarning("There is no Visual Effect Compopnent on this gameobject " + gameObject.name);
            return;
        }

        vfxgraph.enabled = false;
        RegisterModifier(new VortexTriggerDecorator(this, vfxgraph));
    }


    private void LogWarning(string msg) => Debug.Log("[Vortex Component] : " + msg);
}
