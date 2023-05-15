using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [Range(.0f, 50.0f)]
    public float peeds;

    private bool isTruck;
    private float distance;
    private float time;
    private GameObject truck;
    private Vector2 target;

    private void Start()
    {
        if (GameObject.Find("Truck"))
        {
            target = GameObject.Find("Truck").transform.position;       //Ʈ���� ��ġ�� ����

            distance = Vector2.Distance(target, transform.position);        //������ ��ġ���� �Ÿ� ����
        }
    }
    void Update()
    {
        if (!GameObject.Find("Truck"))      //Ʈ�� ������Ʈ�� ���� ��� ����
            return;

        truck = GameObject.Find("Truck");
        target = truck.transform.position;

        if (Time.timeScale != 0)
        {
            time += Time.deltaTime;
            if (!isTruck)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, distance * Time.deltaTime / peeds);
                //ó�� ���� Ʈ������ �Ÿ��� ���� �ٸ� �ӵ� ����
            }
            else if (time > 1.0f)       //1�� ���� �����
            {
                time = 0.0f;
                truck.GetComponent<Truck>().TruckHP();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.Find("Truck"))
        {
            isTruck = true;
        }
    }
}
