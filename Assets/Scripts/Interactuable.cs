using UnityEngine;

public class Interactuable : MonoBehaviour
{
    private Light miLuz;

    [Header("Intensidades")]
    private const float intensidadMinima = 0f;
    private const float intensidadMaxima = 0.1f;

    [Header("Tiempos")]
    private const float tiempoCambiando = 1f; // Tiempo que tarda en subir o bajar
    private const float tiempoEsperaMinimo = 1f; // Cuánto se queda "apagada"

    private float timer = 0f;
    private bool subiendo = true;
    private bool esperando = false;

    void Start()
    {
        miLuz = GetComponent<Light>();
        miLuz.intensity = intensidadMinima;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (esperando)
        {
            // Solo entra aquí cuando está en el mínimo
            if (timer >= tiempoEsperaMinimo)
            {
                timer = 0;
                esperando = false;
                subiendo = true; // Tras la espera, toca subir
            }
        }
        else
        {
            float progreso = timer / tiempoCambiando;

            if (subiendo)
            {
                miLuz.intensity = Mathf.Lerp(intensidadMinima, intensidadMaxima, progreso);
                
                // Si llegamos al máximo, bajamos de inmediato
                if (progreso >= 1.0f)
                {
                    timer = 0;
                    subiendo = false;
                }
            }
            else
            {
                miLuz.intensity = Mathf.Lerp(intensidadMaxima, intensidadMinima, progreso);

                // Si llegamos al mínimo, activamos la pausa
                if (progreso >= 1.0f)
                {
                    timer = 0;
                    esperando = true;
                }
            }
        }
    }
}
