using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public AudioSource shootAudio;
    public AudioClip shootClip;
    public Text scoreText;
    public Text coinText;
    public GameObject ui;
    public LayerMask lm;

    public int score;
    public int coin;
    private RaycastHit2D hit;
    private RaycastHit2D[] allHit;

    public void Shooter()
    {
        shootAudio.PlayOneShot(shootClip);      //소리 재생

        hit = Physics2D.Raycast(transform.position, transform.up, 7.0f, lm);        //hit에 대한 정보
        allHit = Physics2D.RaycastAll(transform.position, transform.up, 7.0f, lm);      //allHit에 대한 정보

        Debug.DrawRay(transform.position, transform.up * 7, Color.red, 1.0f);       //씬 뷰에서 레이 캐스트의 경로 확인

        if (ui.GetComponent<UIController>().penetrate && allHit != null)
        {
            foreach (var item in allHit)        //레이 캐스트와 닿은 오브젝트 전부 파괴
            {
                Destroy(item.collider.gameObject);
                ScoreText();
                CoinText();
            }
        }
        else if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Destroy(hit.collider.gameObject);       //레이 캐스트에 가장 먼저 닿은 오브젝트 파괴
            ScoreText();
            CoinText();
        }
    }
    public void ScoreText()
    {
        scoreText.text = "Score:" + ++score;        //점수 텍스트
    }
    public void CoinText()
    {
        coinText.text = ++coin + " Coins";      //코인 텍스트
    }
}