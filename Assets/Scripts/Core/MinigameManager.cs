using UnityEngine;
using System.Collections;
using System;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    [Header("Referencias UI")]
    public GameObject panelMinijuego; 
    public RectTransform cursor;     
    public float anchoBarra = 200f;   

    void Awake() => Instance = this;

    
    public IEnumerator StartMinigame(Action<float> alTerminar)
    {
        panelMinijuego.SetActive(true); 
        float multiplicador = 0.5f;
        bool pulsado = false;

        while (!pulsado)
        {
            
            float oscilacion = Mathf.Sin(Time.time * 10f); 

            cursor.anchoredPosition = new Vector2(oscilacion * anchoBarra, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                float precision = Mathf.Abs(oscilacion);

                if (precision < 0.15f) multiplicador = 2.0f;      
                else if (precision < 0.5f) multiplicador = 1.2f;  
                else multiplicador = 0.8f;                        

                pulsado = true;
            }
            yield return null;
        }

        panelMinijuego.SetActive(false); 
        alTerminar?.Invoke(multiplicador); 
    }
}