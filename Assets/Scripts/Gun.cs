using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //[SerializeField]
    //private GameObject bulletPrefab;
    public Transform muzzle;
    public Bullet bullet;
    public float msInterval = 120;      //발사 간격
    public float muzzleVelocity = 3;    //발사 속도
    public Camera mainCamera;

    public Transform fireTransform;   //총알의 발사 위치
    public float damage = 25;         //공격력
    private float fireDistance = 40f; //사정 거리

    public AudioSource gunAudioPlayer;  //총소리 재생기
    public AudioClip shotClip;          //발사 소리

    float nextBulletTime;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
        
    }
    
    public void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextBulletTime)                                                   //rotation 부분을 변경 시 음표 방향 바꿀 수 있음.
            {
                nextBulletTime = Time.time + msInterval / 1000;
                Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);    //muzzle.eulerAngles.y
                gunAudioPlayer.PlayOneShot(shotClip);                                                                             //muzzle.rotation = Quaternion.Euler(0, 180, 0);
            }                                                                                   //muzzle.eulerAngles = new Vector3(0, 180, 0); //객체의 방향은 Y회전했으나 음표(총알 객체) 이동 방향도 바뀜
                                                                                            //newBullet.SetSpeed(muzzleVelocity);

            

        }
        
        
    }

    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;
        if (Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
           IDamageable target = hit.collider.GetComponent<IDamageable>();
            
            if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
                hitPosition = hit.point;                
            }
            else
            {
                hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
            }
            //StartCoroutine(ShotEffect(hitPosition));
        }

        //private IEnumerator ShotEffect(Vector3 hitPosition)
        //{
        //    gunAudioPlayer.PlayOneShot(shotClip);
        //}
        //yield return new WaitForSeconds(0.03f);
    }

    void Update()
    {
       
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo, 20))
        //    {
        //        var direction = new Vector3(hitInfo.point.x, transform.position.y, hitInfo.point.z) - transform.position;
        //        var bullet = Instantiate(bulletPrefab, transform.position + direction.normalized, Quaternion.identity).GetComponent<Bullet>();
        //        bullet.Shoot(direction.normalized);
        //        Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        //    }
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Look input
        //    Ray ray = new Ray(transform.position, transform.forward);

        //}
        //else if (Input.GetKeyDown(KeyCode.Escape)) //esc 키
        //{

        //}


    }
}
