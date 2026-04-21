using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ChooseDoor : MonoBehaviour //IPointerClickHandler
{
    public GameObject leftDoor;
    public GameObject rightDoor;

    private Camera mainCamera;

    InputAction clickAction;

    private Vector2 MousePos;

    private void Start()
    {
        clickAction = InputSystem.actions.FindAction("Click");
        mainCamera = Camera.main;
    }

   

    #region PlayerSelects

    /*public void OnPointerClick(PointerEventData eventData)
    {
        print("click");
    }*/

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(pos: (Vector3)Mouse.current.position.ReadValue()));

        if (!rayHit.collider) return;

        Debug.Log(rayHit.collider.gameObject.name);
    }







    #endregion


}
