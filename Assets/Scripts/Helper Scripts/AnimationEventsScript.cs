using UnityEngine;

public class AnimationEventsScript : MonoBehaviour
{

    public GameObject[] mainMenuObjects;

    public void EnableMainMenuObjects()
    {
        for (int i = 0; i < mainMenuObjects.Length; i++)
        {
            mainMenuObjects[i].SetActive(true);
        }
    }

     public void DisableMainMenuObjects()
    {
        for (int i = 0; i < mainMenuObjects.Length; i++)
        {
            mainMenuObjects[i].SetActive(false);
        }
    }
}
