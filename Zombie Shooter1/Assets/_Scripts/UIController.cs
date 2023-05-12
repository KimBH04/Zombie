using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public int sobiCoin;
    public GameObject machineGun;
    public GameObject min;
    public GameObject pb;

    public bool penetrate;
    public void SkillPenetrate()
    {
        if (machineGun.GetComponent<Shoot>().coin >= sobiCoin && !penetrate)
        {
            penetrate = true;

            min.GetComponent<ZombieSpawn>().min -= .1f;

            machineGun.GetComponent<Shoot>().coin -= sobiCoin + 1;
            machineGun.GetComponent<Shoot>().CoinText();

            pb.SetActive(false);
        }
    }
}
