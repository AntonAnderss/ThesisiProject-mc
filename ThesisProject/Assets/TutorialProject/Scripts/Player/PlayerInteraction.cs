using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class PlayerInteraction : MonoBehaviour
{
    [Header("External")]
    [SerializeField] private Camera playerCamera;

    void OnInteract()
    {
        RaycastHit hit;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit);

        IInteractable obj = hit.transform.gameObject.GetComponent<IInteractable>();
        if (obj != null)
            obj.Interact();
    }
}
