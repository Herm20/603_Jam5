using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {
    public PlayerController playerController;
    public PlayerSpawnData playerData;
    public ControllerList GM;

    [SerializeField] float jumpPower = 5f;

    // Use this for initialization
    void Start () {
        playerData.playerInput = GM;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerData.playerInput.controllers.Count == 0)
            return;
        else 
        {
            for (int i = 0; i < playerData.playerInput.controllers.Count; i++)
            {
                // Add some type of conditional to where to player tell the script that it's been paired to a controller
                if (playerData.playerInput.controllers[i].controllerNum == 1)
                {
                    playerInput(i);
                }
                if (playerData.playerInput.controllers[i].controllerNum == 2)
                {
                    playerInput(i);
                }
                if (playerData.playerInput.controllers[i].controllerNum == 3)
                {
                    playerInput(i);
                }
                if (playerData.playerInput.controllers[i].controllerNum == 4)
                {
                    playerInput(i);
                }
            }
        }
    }

    void playerInput(int index) {
        if (Input.GetButtonDown(playerData.playerInput.controllers[index].aButton))
        {
            Vector3 inputDirection = Vector3.zero;
            inputDirection.x = Input.GetAxis(playerData.playerInput.controllers[index].horizontalAxis);
            inputDirection.y = Input.GetAxis(playerData.playerInput.controllers[index].verticalAxis);
            playerController.Jump(inputDirection, jumpPower);
        }

        if (Input.GetButtonDown(playerData.playerInput.controllers[index].bButton))
        {
            Vector3 inputDirection = Vector3.zero;
            inputDirection.x = Input.GetAxis(playerData.playerInput.controllers[index].horizontalAxis);
            inputDirection.y = Input.GetAxis(playerData.playerInput.controllers[index].verticalAxis);
            playerController.Use(inputDirection);
        }
    }
}
