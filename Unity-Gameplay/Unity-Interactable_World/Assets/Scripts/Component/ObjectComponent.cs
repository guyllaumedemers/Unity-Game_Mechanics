using System.Collections.Generic;
using UnityEngine;

public class ObjectComponent : MonoBehaviour, IInteractable
{
    protected List<ObjectDecorator> Modifiers = new List<ObjectDecorator>();

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (this.gameObject.tag.Equals("InteractableObject") && collider.tag.Equals("Player"))  // ONLY ALLOW Player Interaction with object,
                                                                                                // we dont want NPC to activate traps
        {
            PlayInteraction();
            foreach (var item in Modifiers) item.PlayInteraction();
        }
    }

    public void PlayInteraction()
    {
        Debug.Log("Play Object Component Base Interaction");
    }

    protected void RegisterModifier(ObjectDecorator interaction) => Modifiers.Add(interaction);
}
