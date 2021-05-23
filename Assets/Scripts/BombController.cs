using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BombController : MonoBehaviour
{
    Rigidbody rb;

    private Material material = null;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Material>();
        rb = GetComponent<Rigidbody>();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt) 
    {
        material.color = gazedAt ? Color.blue : Color.black;
    }
    
    void Update()
    {

    }

    public void RandomBombPosition()
    {
        Vector3 direction = Random.onUnitSphere;
        direction.y = Mathf.Clamp(direction.y, 0.5f, 1.0f);
        float distance = 25.0f * Random.value + 1.3f;
        transform.localPosition = distance * direction;
    }    
}
