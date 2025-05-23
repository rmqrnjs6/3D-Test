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

    // �˾� UI � ������ �ؽ�Ʈ
    public string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    // �÷��̾ ��ȣ�ۿ� ��ư(E ��)�� ���� �� ȣ��
    public void OnInteract()
    {
        // 1) ������ �κ��丮�� �߰� (���� ����)
        var player = CharManager.Instance.Player;
        player.itemData = data;
        player.addItem?.Invoke();

        // 2) �ӵ� ���� ����
        var buffMgr = player.GetComponent<BuffManager>();
        var speedConsumable = System.Array.Find(
            data.consumables,
            c => c.type == ConsumableType.Speed);
        if (speedConsumable != null)
        {
            buffMgr.AddSpeedBuff(speedConsumable.value, speedConsumable.duration);
        }

        // 3) ���ӿ�����Ʈ �ı�
        Destroy(gameObject);
    }

}