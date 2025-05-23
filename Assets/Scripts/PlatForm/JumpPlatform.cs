using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{    
    public float power = 5.0f;
    void Start()
    {
        Debug.Log("JumpPad 스크립트 시작됨");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"JumpPad 트리거 감지: {other.name}");

        if (!other.CompareTag("Player")) return;

        Rigidbody PlayerRb = other.attachedRigidbody;
        if (PlayerRb == null)
        {
            Debug.LogWarning("플레이어 Rigidbody를 못 찾음");
            return;
        }


        Debug.Log($"[JumpPad] 힘 주기 직전: power={power}, mass={PlayerRb.mass}");
        PlayerRb.AddForce(transform.up * power, ForceMode.Impulse);
        Debug.Log("[JumpPad] AddForce 호출됨");
    }
}
