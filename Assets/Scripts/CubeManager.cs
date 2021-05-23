using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public Camera mainCamera;
    public CubeController cube;
    
    void Update()
    {
        Ray ray = mainCamera.ViewportPointToRay(0.5f * Vector2.one);
        RaycastHit hit;
        bool cubeHit = Physics.Raycast(ray, out hit) && hit.transform == cube.transform;
        cube.SetGazedAt(cubeHit);

        //if (Physics.Raycast(ray, out hit, 30))
        //{
        //    //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 30, Color.green);
        //}
        //else
        //{
        //    //Debug.DrawLine(ray.origin, hit.point, Color.red);
        //}

        
        
        

        
        
    }
}
