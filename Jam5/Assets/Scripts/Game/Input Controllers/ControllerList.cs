using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerList : MonoBehaviour {
    private InputData control;
    private bool[] isSet = new bool[4];

    //public InputData Controls { get{ return controls; } }

    public List<InputData> controllers = new List<InputData>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Joystick1_AButton") && isSet[0] == false)
        {
            control = new InputData();
            control.SetControllerNumber(1);
            controllers.Add(control);
            isSet[0] = true;
        }
        else if (Input.GetButtonDown("Joystick2_AButton") && isSet[1] == false)
        {
            control = new InputData();
            control.SetControllerNumber(2);
            controllers.Add(control);
            isSet[1] = true;
        }
        else if (Input.GetButtonDown("Joystick3_AButton") && isSet[2] == false)
        {
            control = new InputData();
            control.SetControllerNumber(3);
            controllers.Add(control);
            isSet[2] = true;
        }
        else if (Input.GetButtonDown("Joystick4_AButton") && isSet[3] == false)
        {
            control = new InputData();
            control.SetControllerNumber(4);
            controllers.Add(control);
            isSet[3] = true;
        }
    }
}
