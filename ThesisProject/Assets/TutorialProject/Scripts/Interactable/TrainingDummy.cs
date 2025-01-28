using UnityEngine;

public class TrainingDummy : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hit Dummy");
    }
}
