

using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
