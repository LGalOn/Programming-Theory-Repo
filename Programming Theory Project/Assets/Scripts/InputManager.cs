using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    Camera cam;

    void Start() => cam = Camera.main;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && !EventSystem.current.IsPointerOverGameObject())
        {
            TalkBubble.Ins.Close();

            CheckToSelect();
        }
    }

    // ABSTRACTION
    void CheckToSelect()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)
            && hit.collider.TryGetComponent(out Character character))
            character.DisplayText();
    }
}
