using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {
    public PlayerController playerController;
    public PlayerSpawnData playerData;
    public PlayerManager playerManager;

    [SerializeField][Range(0, 1)] private float initialJumpPower = 0.4f;
    [SerializeField] private float jumpChargeSpeed = 1.2f;

    private float currentJumpPower = 0;

    public InputData inputData;

    private bool initializationDone = false;

    // Use this for initialization
    void Awake () {
        playerController = GetComponent<PlayerController>();
        playerManager = GameObject.Find("GameManager").GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inputData == null) return;

        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxis(inputData.horizontalAxis);
        inputDirection.y = Input.GetAxis(inputData.verticalAxis);

        if (inputDirection == Vector3.zero)
        {
            playerController.arrow.gameObject.SetActive(false);
            currentJumpPower = 0;
        }
        else
        {
            playerController.arrow.gameObject.SetActive(true);
            playerController.arrow.up = inputDirection;

            playerController.arrowSprite.color = Color.Lerp(Color.black, Color.red, currentJumpPower);
        }

        if (playerController.jumpsRemaining > 0)
        {
            if (Input.GetButton(inputData.aButton))
            {
                currentJumpPower = Mathf.Max(initialJumpPower, Mathf.Min(1f, currentJumpPower + jumpChargeSpeed * Time.deltaTime));
            }

            if (Input.GetButtonUp(inputData.aButton))
            {
                if (initializationDone)
                {
                    playerController.Jump(inputDirection, currentJumpPower);
                    currentJumpPower = 0;
                }
                else
                    initializationDone = true;
            }
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
