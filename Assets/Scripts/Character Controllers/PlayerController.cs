using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
[System.Serializable]
public class PlayerController : ICharacterController
{
    
    public void HandleInput(Character3D character)
    {

        float mouseX = 0;
        float mouseY = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;

            mouseX = Input.GetTouch(0).deltaPosition.x;
            mouseY = Input.GetTouch(0).deltaPosition.y;
        }

        character.Look(mouseX, mouseY);
    }
}
