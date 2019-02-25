using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerList : MonoBehaviour {

    //public InputData Controls { get{ return controls; } }

    public List<InputData> controllers = new List<InputData>();

    private bool[] isSet = new bool[4];

    public Color[] playerColors;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Joystick1_AButton") && isSet[0] == false)
        {
            InputData control = new InputData();
            control.SetControllerNumber(1);
            PlayerManager.Instance.SpawnPlayer(control, playerColors[0]);
            isSet[0] = true;
        }
        else if (Input.GetButtonDown("Joystick2_AButton") && isSet[1] == false)
        {
            InputData control = new InputData();
            control.SetControllerNumber(2);
            PlayerManager.Instance.SpawnPlayer(control, playerColors[1]);
            isSet[1] = true;
        }
        else if (Input.GetButtonDown("Joystick3_AButton") && isSet[2] == false)
        {
            InputData control = new InputData();
            control.SetControllerNumber(3);
            PlayerManager.Instance.SpawnPlayer(control, playerColors[2]);
            isSet[2] = true;
        }
        else if (Input.GetButtonDown("Joystick4_AButton") && isSet[3] == false)
        {
            InputData control = new InputData();
            control.SetControllerNumber(4);
            PlayerManager.Instance.SpawnPlayer(control, playerColors[3]);
            isSet[3] = true;
        }
    }
}
