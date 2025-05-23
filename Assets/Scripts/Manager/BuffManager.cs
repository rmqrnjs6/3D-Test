using System.Collections;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [Tooltip("버프 종료 후 되돌아갈 기본 이동 속도")]
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
        // 적용
        player.currentMoveSpeed = defaultSpeed + Amount;
        yield return new WaitForSeconds(duration);
        // 해제
        player.currentMoveSpeed = defaultSpeed;
        buffRoutine = null;
    }
}