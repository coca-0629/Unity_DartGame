using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;
    public int bamCount = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && bamCount < 5) {
            GameObject bamsongi = Instantiate(bamsongi_prefab) as GameObject;
            Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 shooting_ray = screen_ray.direction;
            bamsongi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray*1000);
            // bamsongi.GetComponent<BamsongiCtrl>().Shoot(new Vector3(0, 500, 500));

            bamCount += 1;
        }
    }
}
