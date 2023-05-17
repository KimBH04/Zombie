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
        //애플리케이션에서 탈출할 경우 pause
        if (pause)
        {
            fPause = true;
            OnPause();
            Debug.LogWarning("게임 이탈");
        }
        else
        {
            if (fPause)
            {
                fPause = false;
                Debug.LogWarning("게임 복귀");
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
        //게임 오버된 경우
        Time.timeScale = 0;

        int score = machineGun.GetComponent<Shoot>().score;     //Shoot 스크립트에서 score 변수 참조

        int highScore = PlayerPrefs.GetInt("High Score");       //High Score에 저장된 이전 최고 점수 참조

        if (score > highScore)      //현재 score가 저장되어 있던 High Score보다 높으면 "New Record" 화면에 표시
        {
            PlayerPrefs.SetInt("High Score", score);
            highScore = score;
            newRecord.SetActive(true);
        }
        scoreText.text = "Score:" + score + "\nHigh Score:" + highScore;        //현재 점수와 최고 점수 표시

        gameOverPanel.SetActive(true);
    }

    public void Exit()
    {
        ButtonAudioPlay();
#if UNITY_EDITOR        //유니티 에디터에서 실행할 경우
        UnityEditor.EditorApplication.isPlaying = false;

#else       //빌드된 애플리케이션에서 실행할 경우
        Application.Quit();

#endif
    }

    public void HighScoreReset()
    {
        //저장되어 있는 하이스코어를 초기화
        if (PlayerPrefs.HasKey("High Score"))
        {
            PlayerPrefs.DeleteKey("High Score");
            Debug.Log("fltpt");
        }
    }


    public void ButtonAudioPlay()
    {
        //버튼 누를 경우 소리 출력
        audioSource.PlayOneShot(audioClip);
    }
}
