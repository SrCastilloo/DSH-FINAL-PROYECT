using UnityEngine;
using UnityEngine.InputSystem;

public class ProbadorInteraccion : MonoBehaviour
{
    public ControladorEvaporador evaporador;

    void Update()
    {
        // Toggle de Encendido/Apagado
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            evaporador.PulsarBotonToggle();
        }

        // Probar pasos específicos (solo funcionan si la máquina está encendida)
        if (Keyboard.current.digit1Key.wasPressedThisFrame) evaporador.EjecutarComando("Arrancar");
        if (Keyboard.current.digit2Key.wasPressedThisFrame) evaporador.EjecutarComando("Bomba");
        if (Keyboard.current.digit3Key.wasPressedThisFrame) evaporador.EjecutarComando("Ebullicion");
        if (Keyboard.current.digit4Key.wasPressedThisFrame) evaporador.EjecutarComando("Extraccion");
        if (Keyboard.current.digit5Key.wasPressedThisFrame) evaporador.EjecutarComando("Apagar");
    }
}