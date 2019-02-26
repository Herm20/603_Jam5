using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {
    public PlayerController playerController;
    public PlayerSpawnData playerData;

    [SerializeField] float jumpPower = 5f;

    public InputData inputData;

    // Use this for initialization
    void Awake () {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (inputData == null) return;

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis(inputData.horizontalAxis);
        inputDirection.y = Input.GetAxis(inputData.verticalAxis);

        playerController.arrow.up = inputDirection;

        if (Input.GetButtonDown(inputData.aButton))
            playerController.Jump(inputDirection, jumpPower);

        if (Input.GetButtonDown(inputData.bButton))
            playerController.Use(inputDirection);
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
