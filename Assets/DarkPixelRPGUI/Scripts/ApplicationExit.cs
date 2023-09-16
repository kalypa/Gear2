using UnityEngine;


public class ApplicationExit : MonoBehaviour
{
    public GameObject exitPanel;
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickCancel()
    {
        Time.timeScale = 1f;
        exitPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            exitPanel.SetActive(true);
        }
    }
}