using UnityEngine;


public class ApplicationExit : MonoBehaviour
{
    public GameObject exitPanel;
    public void OnClickExit() //예 버튼 눌렀을 때 게임종료
    {
        Application.Quit();
    }

    public void OnClickCancel() //아니요 버튼 눌렀을 때 패널 비활성화 후 게임 정지 해제
    {
        Time.timeScale = 1f;
        exitPanel.SetActive(false);
    }

    private void Update() => ExitCheck();

    void ExitCheck() //뒤로가기 혹은 ESC키 눌렀을때 Exit패널 활성화 후 게임 정지
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            exitPanel.SetActive(true);
        }
    }
}