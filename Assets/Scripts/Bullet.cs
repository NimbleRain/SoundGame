using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    CubeController cube;
    Rigidbody rig;
    float mDeathTimer;

    void Start()
    {
        cube = GetComponent<CubeController>();
        rig = GetComponent<Rigidbody>();

        mDeathTimer = 0.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 15.0f);
        mDeathTimer += Time.deltaTime;
        if(mDeathTimer >= 3.0f)
        {            
            Destroy(this.gameObject);
        }
    }
    public static void Initialized()                                        //새로운 게임을 실행할 때 초기화를 해야함
    {
        Score.score = 0;
        Time.timeScale = 1;
    }
}
