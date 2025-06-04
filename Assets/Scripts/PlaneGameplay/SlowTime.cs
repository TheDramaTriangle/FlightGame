using UnityEngine;
using System.Collections; 

public class SlowTime : MonoBehaviour
{
    public float slowTimeScale = 0.5f;
    public float duration = 5f;
    public float coolDown = 5f; 
    public float zoomTime = 10f; 
    private float lastSlowTime = 0f; 
    public AudioSource slowTimeAudio; 

    void Start()
    {
        if (!UnlockedUpgrades.isSlowTimeUnlocked)
            this.enabled = false; 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            if (Time.time - lastSlowTime >= coolDown)
            {
                slowTimeAudio.Play(); 
                lastSlowTime = Time.time; 
                StartCoroutine(SlowTimeForSeconds());
            }
    }

    IEnumerator SlowTimeForSeconds()
    {
        Time.timeScale = slowTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        float startFOV = Camera.main.fieldOfView;
        float targetFOV = startFOV - 10f;
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            Camera.main.fieldOfView = Mathf.Lerp(startFOV, targetFOV, elapsed);
            elapsed += Time.unscaledDeltaTime * zoomTime;
            yield return null;
        }

        Camera.main.fieldOfView = targetFOV;

        yield return new WaitForSecondsRealtime(duration);

        elapsed = 0f;
        while (elapsed < 1f)
        {
            Camera.main.fieldOfView = Mathf.Lerp(targetFOV, startFOV, elapsed);
            elapsed += Time.unscaledDeltaTime * zoomTime;
            yield return null;
        }

        Camera.main.fieldOfView = startFOV;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
