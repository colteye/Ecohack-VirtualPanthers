using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProgressor : MonoBehaviour
{
    int currentScene = 0;
    [SerializeField]
    GameObject scene0Objects;
    [SerializeField]
    GameObject scene1Objects;
    [SerializeField]
    GameObject scene2Objects;
    [SerializeField]
    GameObject scene3Objects;
    [SerializeField]
    GameObject scene4Objects;


    public void GoToNextScene()
    {
        currentScene++;
        SwitchingMenuAssets();
    }

    private void SwitchingMenuAssets()
    {
        switch (currentScene)
        {
            case 1:
                scene0Objects.SetActive(false);
                scene1Objects.SetActive(true);
                Debug.Log("this is scene 1");
                break;

            case 2:
                scene1Objects.SetActive(false);
                scene2Objects.SetActive(true);
                Debug.Log("this is scene 2");
                break;
            case 3:
                scene2Objects.SetActive(false);
                scene3Objects.SetActive(true);
                Debug.Log("this is scene 3");
                break;
            case 4:
                scene3Objects.SetActive(false);
                scene4Objects.SetActive(true);
                Debug.Log("this is the outro");
                break;
        }

    }
}
