using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preguntas : MonoBehaviour
{

    public Pregunta[] preguntas;

    public Pregunta getPregunta(string tipoPregunta)
    {
        return getPreguntaXTipo(tipoPregunta);
    }

    private Pregunta getPreguntaXTipo(string tipoPregunta)
    {
        for (int i=0; i<preguntas.Length; i++)
        {
            if (preguntas[i].getTipoPregunta() == tipoPregunta && preguntas[i].esUsable())
            {
                preguntas[i].setUsable(false);
                return preguntas[i];
            }
        }
        return null;
    }

    public int getCantPreguntas()
    {
        return preguntas.Length;
    }

    public Pregunta getPregunta(int nroPregunta)
    {
        return preguntas[nroPregunta];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
