using UnityEngine;

public class ControladorEvaporador : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipArranque, clipBomba, clipEbullicion, clipExtraccion, clipApagado;
    
    // Flag de estado
    private bool estaEncendido = false;

    // Este es el método que asignarás al Botón Único de ON/OFF
    public void PulsarBotonToggle()
    {
        if (!estaEncendido)
        {
            EjecutarComando("Arrancar");
        }
        else
        {
            EjecutarComando("Apagar");
        }
    }

    // Sistema de comandos centralizado
    public void EjecutarComando(string comando)
    {
        switch (comando)
        {
            case "Arrancar":
                estaEncendido = true;
                audioSource.Stop();
                audioSource.PlayOneShot(clipArranque);
                Debug.Log("Máquina Iniciada");
                break;

            case "Apagar":
                estaEncendido = false;
                audioSource.Stop();
                audioSource.PlayOneShot(clipApagado);
                Debug.Log("Máquina Apagada");
                break;

            case "Bomba":
                if (estaEncendido) ReproducirSonidoLoop(clipBomba);
                break;

            case "Ebullicion":
                if (estaEncendido) ReproducirSonidoLoop(clipEbullicion);
                break;
                
            case "Extraccion":
                if (estaEncendido) ReproducirSonidoLoop(clipExtraccion);
                break;
        }
    }

    private void ReproducirSonidoLoop(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}