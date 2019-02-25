using System;

[Serializable]
public class InputData {
    public int controllerNum;
    public string horizontalAxis;
    public string verticalAxis;
    public string aButton;
    public string bButton;
    public string startButton;

    public void SetControllerNumber(int number)
    {
        controllerNum = number;
        horizontalAxis = "Joystick" + controllerNum + "_Horizontal";
        verticalAxis = "Joystick" + controllerNum + "_Vertical";
        aButton = "Joystick" + controllerNum + "_AButton";
        bButton = "Joystick" + controllerNum + "_BButton";
        startButton = "Joystick" + controllerNum + "_StartButton";
    }
}
