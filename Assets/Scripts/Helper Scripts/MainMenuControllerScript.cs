using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{


    public Animator levelPanelAnim;

    public void PlayGame()
    {
        levelPanelAnim.Play("SlideIn");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenuFromLevelScreen()
    {
        levelPanelAnim.Play("SlideOut");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level1");
    }


}
