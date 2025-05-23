using UnityEngine;

public class CharManager : MonoBehaviour
{
    private static CharManager instance;
    public static CharManager Instance { get { if (instance == null) instance = new GameObject("CharManager").AddComponent<CharManager>(); return instance; } }

    public Player player;
    public Player Player{  get { return player; }  set { player = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            if (instance == this)
            {
                Destroy(gameObject);
            }
        }
    }


}
