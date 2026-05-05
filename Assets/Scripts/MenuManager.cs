using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles de la Interfaz")]
    public GameObject panelInicio;
    public GameObject panelAjustes;
    public GameObject panelPreguntas; // El panel base de las preguntas
    public GameObject panelFin;

    [Header("Referencia al Juego")]
    public QuizManager quizManager; // Para poder decirle que empiece

    void Start()
    {
        // Al darle al Play, nos aseguramos de que SOLO se vea el INICIO
        panelInicio.SetActive(true);
        panelAjustes.SetActive(false);
        panelPreguntas.SetActive(false);
        panelFin.SetActive(false);
    }

    // --- FUNCIONES PARA LOS BOTONES ---

    public void BotonEntrar()
    {
        panelInicio.SetActive(false);
        // Llamamos al QuizManager para que cargue la primera pregunta y muestre el panel
        quizManager.MostrarPreguntaActual(); 
    }

    public void BotonAjustes()
    {
        panelAjustes.SetActive(true);
        panelInicio.SetActive(false); // Ocultamos el inicio para que no se superpongan
    }

    // Esta función es para la 'X' dentro de la pantalla de Ajustes
    public void BotonCerrarAjustes() 
    {
        panelAjustes.SetActive(false);
        panelInicio.SetActive(true); // Volvemos al menú principal
    }

    // Esta función es para el botón 'SALIR' y la 'X' de la pantalla de FIN
    public void BotonSalir()
    {
        Debug.Log("Saliendo del simulador...");
        Application.Quit(); 
        
        // Nota: Application.Quit() no hace nada visualmente dentro del editor de Unity, 
        // solo funciona cuando exportas el juego (la build final). 
        // El Debug.Log te confirmará que el botón funciona en el editor.
    }

    public void BotonVolverAlInicio()
    {
        // Ocultamos todos los paneles del quiz
        panelPreguntas.SetActive(false);
        quizManager.panelAcierto.SetActive(false);
        quizManager.panelFallo.SetActive(false);
        
        // Mostramos el menú principal
        panelInicio.SetActive(true);
    }
}