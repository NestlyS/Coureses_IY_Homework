using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private IInteractable _interactable;

    public void Init(IInteractable interactable)
    {
        _interactable = interactable;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            _interactable.OnInteraction();
        }
    }
}
