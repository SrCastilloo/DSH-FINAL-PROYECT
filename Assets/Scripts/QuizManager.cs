using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json; // Necesario para leer el JSON

// 1. Clases para almacenar los datos del JSON
[System.Serializable]
public class PreguntaData
{
    public string pregunta;
    public string respuesta_correcta;
    public string falsa1;
    public string falsa2;
    public string falsa3;
    public string explicación_bien;
    public string explicación_mal1;
    public string explicación_mal2;
    public string explicación_mal3;
}

public class QuizManager : MonoBehaviour
{
    [Header("Archivo JSON")]
    public TextAsset jsonFile; // Arrastra aquí tu preguntas.json

    [Header("Paneles de UI")]
    public GameObject panelPregunta;
    public GameObject panelAcierto;
    public GameObject panelFallo;

    [Header("Textos de Pregunta y Explicación")]
    public TextMeshProUGUI textoPregunta;
    public TextMeshProUGUI textoExplicacionAcierto;
    public TextMeshProUGUI textoExplicacionFallo;

    [Header("Botones de Respuesta")]
    public Button[] botonesRespuestas; // Array con los 4 botones
    private TextMeshProUGUI[] textosBotones;

    // Diccionario para guardar todas las preguntas
    private Dictionary<string, PreguntaData> todasLasPreguntas;
    private List<string> listaClavesPreguntas;
    private int indicePreguntaActual = 0;

    // Estructura auxiliar para mezclar las respuestas sin perder su justificación
    private class OpcionRespuesta
    {
        public string texto;
        public string justificacion;
        public bool esCorrecta;
    }

    void Start()
    {
        // Obtener los TextMeshPro de los botones
        textosBotones = new TextMeshProUGUI[botonesRespuestas.Length];
        for (int i = 0; i < botonesRespuestas.Length; i++)
        {
            textosBotones[i] = botonesRespuestas[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        CargarJSON();
        MostrarPreguntaActual();
    }

    void CargarJSON()
    {
        // Deserializar el JSON usando Newtonsoft
        todasLasPreguntas = JsonConvert.DeserializeObject<Dictionary<string, PreguntaData>>(jsonFile.text);
        listaClavesPreguntas = new List<string>(todasLasPreguntas.Keys);
    }

    public void MostrarPreguntaActual()
    {
        // Ocultar feedback y mostrar panel de pregunta
        panelAcierto.SetActive(false);
        panelFallo.SetActive(false);
        panelPregunta.SetActive(true);

        // Obtener la pregunta actual
        string clave = listaClavesPreguntas[indicePreguntaActual];
        PreguntaData preguntaActual = todasLasPreguntas[clave];

        // Establecer el texto de la pregunta principal
        textoPregunta.text = preguntaActual.pregunta;

        // Crear una lista con las 4 opciones y sus justificaciones
        List<OpcionRespuesta> opciones = new List<OpcionRespuesta>
        {
            new OpcionRespuesta { texto = preguntaActual.respuesta_correcta, justificacion = preguntaActual.explicación_bien, esCorrecta = true },
            new OpcionRespuesta { texto = preguntaActual.falsa1, justificacion = preguntaActual.explicación_mal1, esCorrecta = false },
            new OpcionRespuesta { texto = preguntaActual.falsa2, justificacion = preguntaActual.explicación_mal2, esCorrecta = false },
            new OpcionRespuesta { texto = preguntaActual.falsa3, justificacion = preguntaActual.explicación_mal3, esCorrecta = false }
        };

        // Mezclar las opciones aleatoriamente
        MezclarLista(opciones);

        // Asignar los datos a los botones
        for (int i = 0; i < botonesRespuestas.Length; i++)
        {
            textosBotones[i].text = opciones[i].texto;
            
            // Limpiar listeners anteriores para evitar duplicados
            botonesRespuestas[i].onClick.RemoveAllListeners();
            
            // Capturamos la variable para el listener (closure)
            OpcionRespuesta opcionSeleccionada = opciones[i];
            botonesRespuestas[i].onClick.AddListener(() => Responder(opcionSeleccionada));
        }
    }

    void Responder(OpcionRespuesta opcion)
    {
        panelPregunta.SetActive(false);

        if (opcion.esCorrecta)
        {
            panelAcierto.SetActive(true);
            textoExplicacionAcierto.text = opcion.justificacion;
        }
        else
        {
            panelFallo.SetActive(true);
            textoExplicacionFallo.text = opcion.justificacion;
        }
    }

    // Método para pasar a la siguiente pregunta (puedes llamarlo desde un botón "Siguiente" o la "X")
    public void SiguientePregunta()
    {
        indicePreguntaActual++;
        if (indicePreguntaActual < listaClavesPreguntas.Count)
        {
            MostrarPreguntaActual();
        }
        else
        {
            Debug.Log("¡Fin del simulador!");
            // Aquí puedes activar tu panel de FIN
        }
    }

    // Algoritmo de Fisher-Yates para mezclar la lista
    void MezclarLista(List<OpcionRespuesta> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            OpcionRespuesta temp = lista[i];
            int randomIndex = Random.Range(i, lista.Count);
            lista[i] = lista[randomIndex];
            lista[randomIndex] = temp;
        }
    }
}