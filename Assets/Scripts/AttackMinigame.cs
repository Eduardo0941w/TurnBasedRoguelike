using UnityEngine;
using System.Collections;
using System;

public class AttackMinigame : MonoBehaviour
{
    public RectTransform cursor;
    public float speed = 500f;
    public float barWidth = 200f; 

    public IEnumerator Run(Action<float> resultCallback)
    {
        float multiplier = 0.5f; 
        bool pressed = false;

        while (!pressed)
        {
           
            float position = Mathf.Sin(Time.time * (speed / 100f));

           
            cursor.anchoredPosition = new Vector2(position * barWidth, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                float accuracy = Mathf.Abs(position); 

                if (accuracy < 0.1f) multiplier = 2.0f;      
                else if (accuracy < 0.4f) multiplier = 1.2f; 
                else multiplier = 0.7f;                    

                pressed = true;
            }
            yield return null;
        }

        resultCallback?.Invoke(multiplier);
    }
}