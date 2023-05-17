using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public GameObject newRecord;
    public GameObject machineGun;
    public GameObject pausePanel;
    public GameObject storyPanel;
    public GameObject HTPGPanel;
    public GameObject gameOverPanel;
    public Text scoreText;

    private bool fPause;

    private void Awake()
    {
        Screen.SetResolution(1080, 1920, false);
        if (pausePanel)
        {
            pausePanel.SetActive(false);
        }
        if (storyPanel)
        {
            storyPanel.SetActive(false);
        }
        if (HTPGPanel)
        {
            HTPGPanel.SetActive(false);
        }
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(false);
        }
        if (newRecord)
        {
            newRecord.SetActive(false);
        }
        Time.timeScale = 1;

        if (!PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.SetInt("High Score", 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Main")
            {
                if (Time.timeScale == 1)
                {
                    OnPause();
                }
                else
                {
                    ExitGame();
                }
            }
            else if(SceneManager.GetActiveScene().name == "Title")
            {
                Exit();
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        //���ø����̼ǿ��� Ż���� ��� pause
        if (pause)
        {
            fPause = true;
            OnPause();
            Debug.LogWarning("���� ��Ż");
        }
        else
        {
            if (fPause)
            {
                fPause = false;
                Debug.LogWarning("���� ����");
            }
        }
    }
    public void OnPause()
    {
        ButtonAudioPlay();

        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnRestartGame()
    {
        ButtonAudioPlay();

        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
    public void OnContinue()
    {
        ButtonAudioPlay();

        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        ButtonAudioPlay();

        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        ButtonAudioPlay();

        SceneManager.LoadScene("Main");
        Time.timeScale = 0;
    }

    public void SrotyPanel()
    {
        ButtonAudioPlay();

        storyPanel.SetActive(true);
        HTPGPanel.SetActive(false);
    }
    public void HowToPlayGame()
    {
        ButtonAudioPlay();

        storyPanel.SetActive(false);
        HTPGPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        ButtonAudioPlay();

        storyPanel.SetActive(false);
        HTPGPanel.SetActive(false);
    }
    
    public void GameOver()
    {
        //���� ������ ���
        Time.timeScale = 0;

        int score = machineGun.GetComponent<Shoot>().score;     //Shoot ��ũ��Ʈ���� score ���� ����

        int highScore = PlayerPrefs.GetInt("High Score");       //High Score�� ����� ���� �ְ� ���� ����

        if (score > highScore)      //���� score�� ����Ǿ� �ִ� High Score���� ������ "New Record" ȭ�鿡 ǥ��
        {
            PlayerPrefs.SetInt("High Score", score);
            highScore = score;
            newRecord.SetActive(true);
        }
        scoreText.text = "Score:" + score + "\nHigh Score:" + highScore;        //���� ������ �ְ� ���� ǥ��

        gameOverPanel.SetActive(true);
    }

    public void Exit()
    {
        ButtonAudioPlay();
#if UNITY_EDITOR        //����Ƽ �����Ϳ��� ������ ���
        UnityEditor.EditorApplication.isPlaying = false;

#else       //����� ���ø����̼ǿ��� ������ ���
        Application.Quit();

#endif
    }

    public void HighScoreReset()
    {
        //����Ǿ� �ִ� ���̽��ھ �ʱ�ȭ
        if (PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.DeleteKey("High Score");
            Debug.Log("fltpt");
        }
    }


    public void ButtonAudioPlay()
    {
        //��ư ���� ��� �Ҹ� ���
        audioSource.PlayOneShot(audioClip);
    }
}
