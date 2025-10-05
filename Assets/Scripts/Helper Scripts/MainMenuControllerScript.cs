using UnityEngine;

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


}
