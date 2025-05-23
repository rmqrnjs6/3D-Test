using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{    
    public float power = 5.0f;
    void Start()
    {
        Debug.Log("JumpPad ��ũ��Ʈ ���۵�");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"JumpPad Ʈ���� ����: {other.name}");

        if (!other.CompareTag("Player")) return;

        Rigidbody PlayerRb = other.attachedRigidbody;
        if (PlayerRb == null)
        {
            Debug.LogWarning("�÷��̾� Rigidbody�� �� ã��");
            return;
        }


        Debug.Log($"[JumpPad] �� �ֱ� ����: power={power}, mass={PlayerRb.mass}");
        PlayerRb.AddForce(transform.up * power, ForceMode.Impulse);
        Debug.Log("[JumpPad] AddForce ȣ���");
    }
}
