using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class RisingScoreText : MonoBehaviour
{
    private float alpha = 1f;
    private float fadeSpeed = 0.5f;

    private Vector3 riseDirection = new Vector3(0f, 1f, 0f);
    
    public Color color = Color.white;   // Text color
    
    public void StartRising(int points, float duration, float riseSpeed)
    {
        GetComponent<TextMesh>().text = "+" + points.ToString();
        fadeSpeed = 1f / duration;
        riseDirection *= riseSpeed;
    }

    void Update()
    {
        /* Rise text */
        transform.Translate(riseDirection * Time.deltaTime, Space.World);
        
        /* Fade */
        alpha -= Time.deltaTime * fadeSpeed;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, alpha);

        /* Kill when gone. */
        if (alpha <= 0f)
        {
            Destroy(gameObject);
        }
    }
}