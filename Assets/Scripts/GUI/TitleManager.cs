

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject TitleUI; 
    public GameObject StoreUI; 

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void EnterStore()
    {
        TitleUI.SetActive(false);
        StoreUI.SetActive(true);
    }
}
