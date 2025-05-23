using System.Collections;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [Tooltip("���� ���� �� �ǵ��ư� �⺻ �̵� �ӵ�")]
    public float defaultSpeed;

    private PlayerController player;
    private Coroutine buffRoutine;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        defaultSpeed = player.MoveSpeed;
    }

    public void AddSpeedBuff(float Amount, float duration)
    {
        if (buffRoutine != null)
            StopCoroutine(buffRoutine);

        buffRoutine = StartCoroutine(SpeedBuffCoroutine(Amount, duration));
    }

    private IEnumerator SpeedBuffCoroutine(float Amount, float duration)
    {
        // ����
        player.currentMoveSpeed = defaultSpeed + Amount;
        yield return new WaitForSeconds(duration);
        // ����
        player.currentMoveSpeed = defaultSpeed;
        buffRoutine = null;
    }
}