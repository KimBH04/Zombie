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
            target = GameObject.Find("Truck").transform.position;       //트럭의 위치를 저장

            distance = Vector2.Distance(target, transform.position);        //저장한 위치와의 거리 측정
        }
    }
    void Update()
    {
        if (!GameObject.Find("Truck"))      //트럭 오브젝트가 없을 경우 리턴
            return;

        truck = GameObject.Find("Truck");
        target = truck.transform.position;

        if (Time.timeScale != 0)
        {
            time += Time.deltaTime;
            if (!isTruck)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, distance * Time.deltaTime / peeds);
                //처음 얻은 트럭과의 거리에 따라 다른 속도 적용
            }
            else if (time > 1.0f)       //1초 마다 대미지
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
