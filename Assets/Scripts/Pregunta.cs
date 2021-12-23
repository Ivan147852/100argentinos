using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta : MonoBehaviour
{
    public string descripcion;
    public int cantidadRespuestas;
    private Dictionary<string,int> respuestasYPuntos;
    public string[] respuestas;
    public int[] puntos;
    public string tipoPregunta;
    public bool usable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCantidadOpciones()
    {
        return cantidadRespuestas;
    }

    public bool esUsable(){
        return usable;
    }

    public void setUsable(bool usable)
    {
        this.usable = usable;
    }

    public string getTipoPregunta()
    {
        return tipoPregunta;
    }

    public string getRespuesta(int nroRespuesta)
    {
        return respuestas[nroRespuesta];
    }

    public int getPuntos(int nroRespuesta)
    {
        return puntos[nroRespuesta];
    }
}
