using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Class called to manage the hand and switch between teleport controller and base controller
/// This example is an analogy for all the controller switches needed when multiple controllers 
/// for the same hand are required
/// </summary>
public class HandTPManager : MonoBehaviour
{
    public GameObject baseController;
    public GameObject telepportController;

    public InputActionReference teleportationActivationReference;

    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;

    // Start is called before the first frame update
    /// <summary>
    /// At the start, we'll initialize the actions that we need for the teleport.
    /// We are adding to the action.performed the activate Behaviour and same for the cancel
    /// </summary>
    void Start()
    {
        teleportationActivationReference.action.performed += TeleportModeActivate;
        teleportationActivationReference.action.canceled += TeleportModeCancel;
    }


    private void TeleportModeActivate(InputAction.CallbackContext obj)
    {
        onTeleportActivate.Invoke();
    }

    /// <summary>
    /// This method, instead of invoking the event directly, will instead call another method first and
    /// the latter one will call the event, with a delay given by the Invoke method.
    /// </summary>
    /// <param name="obj"></param>
    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", 0.1f);
    }

    private void DeactivateTeleporter()
    {
        onTeleportCancel.Invoke();
    }

}
