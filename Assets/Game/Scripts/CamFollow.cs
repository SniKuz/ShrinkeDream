using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // 추적할 대상

    void Update()
    {
        // 대상이 없으면 실행하지 않음
        if (target == null)
            return;

        // 카메라 위치를 대상 위치로 업데이트
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
