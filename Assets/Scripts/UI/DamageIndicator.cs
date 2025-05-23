using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{

    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        CharManager.Instance.Player.condition.OnTakeDamage += Flash;
    }

    public void Flash()
    {
        if (coroutine != null) StopCoroutine(coroutine); 

        image.enabled = true;
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlha = 0.3f;
        float a = startAlha;

        while (a > 0)
        {
            a -= (startAlha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
