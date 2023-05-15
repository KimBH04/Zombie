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
        shootAudio.PlayOneShot(shootClip);      //�Ҹ� ���

        hit = Physics2D.Raycast(transform.position, transform.up, 7.0f, lm);        //hit�� ���� ����
        allHit = Physics2D.RaycastAll(transform.position, transform.up, 7.0f, lm);      //allHit�� ���� ����

        Debug.DrawRay(transform.position, transform.up * 7, Color.red, 1.0f);       //�� �信�� ���� ĳ��Ʈ�� ��� Ȯ��

        if (ui.GetComponent<UIController>().penetrate && allHit != null)
        {
            foreach (var item in allHit)        //���� ĳ��Ʈ�� ���� ������Ʈ ���� �ı�
            {
                Destroy(item.collider.gameObject);
                ScoreText();
                CoinText();
            }
        }
        else if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Destroy(hit.collider.gameObject);       //���� ĳ��Ʈ�� ���� ���� ���� ������Ʈ �ı�
            ScoreText();
            CoinText();
        }
    }
    public void ScoreText()
    {
        scoreText.text = "Score:" + ++score;        //���� �ؽ�Ʈ
    }
    public void CoinText()
    {
        coinText.text = ++coin + " Coins";      //���� �ؽ�Ʈ
    }
}