using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Shows string and then hides it with time step
public class FlashingText : MonoBehaviour
{
    // Attributes
    [SerializeField] private Text textToUse;
    [SerializeField] private bool useText;
    [SerializeField] private string flashingString;
    [SerializeField] private float pauseTime;

    // Initialize
    private void Start()
    {
        if (useText)
        {
            textToUse = GetComponent<Text>();
            flashingString = textToUse.text;
        }            

        textToUse.text = "";

        StartCoroutine(TypeText(textToUse, flashingString, pauseTime));
    }

    // Writes out text after waiting for the timeout
    private IEnumerator TypeText(Text text, string stringToUse, float timePause)
    {
        bool show = true;
        while (true)
        {
            if (show)
                textToUse.text = stringToUse;
            else
                textToUse.text = "";

            show = !show;
            yield return 0;
            yield return new WaitForSeconds(timePause);
        }
    }
}