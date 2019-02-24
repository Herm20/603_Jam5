using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

// Manages menu Buttons to direct to the proper screens
public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    // Loads the Menu scene
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Loads the Selection scene
    public void Select()
    {
        SceneManager.LoadScene("SelectMenu");
    }

    // Loads the Option popup
    public void OpenOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    // Closes the Option popup
    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    // Loads the Credits scene
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    
    // Quits out the game
    public void Quit()
    {
        Application.Quit();
    }
}
