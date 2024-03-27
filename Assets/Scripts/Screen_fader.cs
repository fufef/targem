using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Screen_fader : MonoBehaviour
{
    public float fade_spead = 1f;

    IEnumerator Start()
    {
        Image fade_image = GetComponent<Image>();
        Color color = fade_image.color;

        while(color.a < 1f)
        {
            color.a += fade_spead * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }


    }
}
