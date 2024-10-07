using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class cameraShake : MonoBehaviour
{
    Vignette vignette;
    private void Start()
    {
            vignette = this.gameObject.GetComponent<Vignette>();
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector2 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-0.07f, 0.07f) * magnitude;
            float y = Random.Range(-0.07f, 0.07f) * magnitude;

            transform.localPosition = new Vector2(x, y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }
    public IEnumerator ChangeVignette()
    {
        vignette.color.Override(new Color (255f, 0f, 0f));
        yield return new WaitForSeconds(0.2f);
        vignette.color.Override(Color.grey);
    }
}
