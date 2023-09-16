using UnityEngine;


public class ApplicationExit : MonoBehaviour
{
    public GameObject exitPanel;
    public void OnClickExit() //�� ��ư ������ �� ��������
    {
        Application.Quit();
    }

    public void OnClickCancel() //�ƴϿ� ��ư ������ �� �г� ��Ȱ��ȭ �� ���� ���� ����
    {
        Time.timeScale = 1f;
        exitPanel.SetActive(false);
    }

    private void Update() => ExitCheck();

    void ExitCheck() //�ڷΰ��� Ȥ�� ESCŰ �������� Exit�г� Ȱ��ȭ �� ���� ����
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            exitPanel.SetActive(true);
        }
    }
}