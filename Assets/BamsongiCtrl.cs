using static System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    float timer = 0.0f;
    bool is_shot = false;

    WindInfo script1;
    ScoreUI script2;

    // Update is called once per frame
    void Update()
    {
        /* Shoot test        
        timer += Time.deltaTime;
        if(timer > 0.05 && !is_shot)
        {
            Shoot(new Vector3(0, 500, 600));
            is_shot = true;
        }
        */
    }

    void FixedUpdate() {        // Fixed Timestep에 설정된 값에 따라 일정한 간격(Default : 0.02sec)으로 호출
        script1 = GameObject.Find("Terrain").GetComponent<WindInfo>();
        GetComponent<Rigidbody>().AddForce(script1.wind_speed_x*0.2f, script1.wind_speed_y*0.2f, 0);
    }

    public void Shoot(Vector3 dir)
    {
        this.transform.position = new Vector3(0, 5, -9);
        GetComponent<Rigidbody>().AddForce(dir);
        
        // Kills the game object in 3 seconds after loading the object
        Destroy(this.gameObject, 3);
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();

        Vector3 collided_position = transform.position;
        float distance = collided_position.x * collided_position.x
            + (collided_position.y - 6.5f) * (collided_position.y - 6.5f);
        distance = Mathf.Sqrt(distance);
        Debug.Log(collided_position);
        Debug.Log(distance);

        script2 = GameObject.Find("target").GetComponent<ScoreUI>();
        script2.distance = distance;
        script2.is_Trig = true;

        script1 = GameObject.Find("Terrain").GetComponent<WindInfo>();
        script1.is_Trig = true;
    }

}
