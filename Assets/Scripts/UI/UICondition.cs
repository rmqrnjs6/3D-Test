using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition hunger;
    public Condition stemina;



    // Start is called before the first frame update
    void Start()
    {
        CharManager.Instance.Player.condition.uiCondition = this;
    }

}
