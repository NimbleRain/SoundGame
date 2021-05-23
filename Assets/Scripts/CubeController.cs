using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CubeController : MonoBehaviour
{
    Rigidbody rigid;
    BoxCollider boxCollider;
    CubeController cube;
    
    private Material material = null;
   
    void Start()
    {
        material = GetComponent<Renderer>().material;
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent <BoxCollider>();
        cube = GetComponent<CubeController>();
        SetGazedAt(false);
    }
    public void SetGazedAt(bool gazedAt)
    {
        material.color = gazedAt ? Color.green : Color.red;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();            
            Debug.Log("충돌");
            Score.score += 10;
            cube.RandomCubePosition();            
        }
    }    
    public void RandomCubePosition()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1.0f);
        float distance = 30.0f * Random.value + 1.5f;                                //랜덤 큐브의 위치
        transform.localPosition = distance * direction;
    }
    
}
