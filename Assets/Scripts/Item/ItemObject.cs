using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    [Header("Item Data (ScriptableObject)")]
    public ItemData data;

    // 팝업 UI 등에 보여줄 텍스트
    public string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    // 플레이어가 상호작용 버튼(E 등)을 누를 때 호출
    public void OnInteract()
    {
        // 1) 아이템 인벤토리에 추가 (기존 로직)
        var player = CharManager.Instance.Player;
        player.itemData = data;
        player.addItem?.Invoke();

        // 2) 속도 버프 적용
        var buffMgr = player.GetComponent<BuffManager>();
        var speedConsumable = System.Array.Find(
            data.consumables,
            c => c.type == ConsumableType.Speed);
        if (speedConsumable != null)
        {
            buffMgr.AddSpeedBuff(speedConsumable.value, speedConsumable.duration);
        }

        // 3) 게임오브젝트 파괴
        Destroy(gameObject);
    }

}