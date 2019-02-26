using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {
    public PlayerController playerController;
    public PlayerSpawnData playerData;
    public PlayerManager playerManager;

    [SerializeField] float jumpPower = 5f;

    public InputData inputData;

    // Use this for initialization
    void Awake () {
        playerController = GetComponent<PlayerController>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (inputData == null) return;

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis(inputData.horizontalAxis);
        inputDirection.y = Input.GetAxis(inputData.verticalAxis);

        if (inputDirection == Vector3.zero)
            playerController.arrow.gameObject.SetActive(false);
        else
        {
            playerController.arrow.gameObject.SetActive(true);
            playerController.arrow.up = inputDirection;
        }

        if (Input.GetButtonDown(inputData.aButton))
        {
            playerController.Jump(inputDirection, jumpPower);
        }

        if (Input.GetButtonDown(inputData.bButton))
        {
            playerController.Use(inputDirection);
        }

        if (Input.GetButtonDown(inputData.bButton))
        {
            playerManager.selectionGrids[inputData.controllerNum - 1].color = Color.red;
            playerManager.readyUp[inputData.controllerNum - 1] = true;
        }

    }
}
