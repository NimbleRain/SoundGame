using UnityEngine;

public interface IDamageable 
{
     void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);    
}

//해당 클래스를 상속받는 모든 클래스에게 인터페이스 클래스의 내부 함수 및 변수를 필수적으로 선언 및 포함 
