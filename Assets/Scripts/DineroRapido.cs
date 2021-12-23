using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DineroRapido : MonoBehaviour
{
    public string[] preguntas = new string[5];
    public string[] respuestas1 = new string[5];
    public string[] respuestas2 = new string[5];
    public bool usable;

    public bool getRespuesta1(int nroRespuesta, string respuesta)
    {
        if (respuesta == respuestas1[nroRespuesta])
        {
            return true;
        }
        return false;
    }
    public bool getRespuesta2(int nroRespuesta, string respuesta)
    {
        if (respuesta == respuestas2[nroRespuesta])
        {
            return true;
        }
        return false;
    }
    public bool esUsable()
    {
        if (usable)
        {
            return true;
        }
        return false;
    }

    public void setUsable(bool usable)
    {
        this.usable = usable;
    }
}
