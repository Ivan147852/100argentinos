using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{

    public GameObject PanelInicial;
    public GameObject PanelDeJuego;
    public GameObject PanelEntrePreguntas;
    public GameObject PanelDineroRapido;
    public Preguntas preguntasGenerales;
    public Text nombreFamilia1;
    public Text nombreFamilia2;
    public Text nombreFamilia1Juego;
    public Text nombreFamilia2Juego;
    public Dropdown pregunta1;
    public Dropdown pregunta2;
    public Dropdown pregunta3;
    public Dropdown pregunta4;
    public Dropdown pregunta5;
    private Pregunta[] preguntasJuego;
    public static Controlador controlador;
    private int nroPregunta;
    private bool jugando;
    private bool dineroRapido;
    public GameObject respuestaOculta1;
    public GameObject respuestaOculta2;
    public GameObject respuestaOculta3;
    public GameObject respuestaOculta4;
    public GameObject respuestaOculta5;
    public GameObject respuestaOculta6;
    public GameObject respuesta1;
    public GameObject respuesta2;
    public GameObject respuesta3;
    public GameObject respuesta4;
    public GameObject respuesta5;
    public GameObject respuesta6;
    public GameObject nombreRespuesta1;
    public GameObject nombreRespuesta2;
    public GameObject nombreRespuesta3;
    public GameObject nombreRespuesta4;
    public GameObject nombreRespuesta5;
    public GameObject nombreRespuesta6;
    public GameObject puntosRespuesta1;
    public GameObject puntosRespuesta2;
    public GameObject puntosRespuesta3;
    public GameObject puntosRespuesta4;
    public GameObject puntosRespuesta5;
    public GameObject puntosRespuesta6;
    public GameObject error1Equipo1;
    public GameObject error2Equipo1;
    public GameObject error3Equipo1;
    public GameObject error1Equipo2;
    public GameObject error2Equipo2;
    public GameObject error3Equipo2;
    public GameObject sonidoError;
    public GameObject musicaTension;
    public GameObject musicaFondo;
    public Text puntosEquipo1;
    public Text puntosEquipo2;
    private int equipoJugando;
    public GameObject nombreDRRespuesta11;
    public GameObject puntosDRRespuesta11;
    public GameObject nombreDRRespuesta21;
    public GameObject puntosDRRespuesta21;
    public GameObject nombreDRRespuesta31;
    public GameObject puntosDRRespuesta31;
    public GameObject nombreDRRespuesta41;
    public GameObject puntosDRRespuesta41;
    public GameObject nombreDRRespuesta51;
    public GameObject puntosDRRespuesta51;
    public GameObject nombreDRRespuesta12;
    public GameObject puntosDRRespuesta12;
    public GameObject nombreDRRespuesta22;
    public GameObject puntosDRRespuesta22;
    public GameObject nombreDRRespuesta32;
    public GameObject puntosDRRespuesta32;
    public GameObject nombreDRRespuesta42;
    public GameObject puntosDRRespuesta42;
    public GameObject nombreDRRespuesta52;
    public GameObject puntosDRRespuesta52;
    public DinerosRapidos dinerosRapidos;
    private DineroRapido juegoDineroRapido;
    public GameObject puntosTotal;
    public GameObject sonidoCorrectoDR;
    public GameObject sonidoErrorDR;
    public Cronometro cronometro;

    void Start()
    {
        controlador = new Controlador();
        preguntasJuego = new Pregunta[5];
        jugando = false;
        dineroRapido = false;
        equipoJugando = 0;
        List<string> preguntas6 = new List<string>();
        List<string> preguntas5 = new List<string>();
        List<string> preguntas4 = new List<string>();
        HashSet<string> tipos4 = new HashSet<string>();
        HashSet<string> tipos5 = new HashSet<string>();
        HashSet<string> tipos6 = new HashSet<string>();
        for (int i=0; i<preguntasGenerales.getCantPreguntas(); i++)
        {
            Pregunta p = preguntasGenerales.getPregunta(i);
            if (p.getCantidadOpciones() == 6)
            {
                tipos6.Add(p.getTipoPregunta());
            }
            else
            {
                if (p.getCantidadOpciones() == 5)
                {
                    tipos5.Add(p.getTipoPregunta());
                }
                else{
                    tipos4.Add(p.getTipoPregunta());
                }
            }
        }
        foreach(string tipo in tipos6)
        {
            preguntas6.Add(tipo);
        }
        pregunta1.AddOptions(preguntas6);
        pregunta2.AddOptions(preguntas6);
        pregunta3.AddOptions(preguntas6);
        foreach(string tipo in tipos5)
        {
            preguntas5.Add(tipo);
        }
        pregunta4.AddOptions(preguntas5);
        foreach(string tipo in tipos4)
        {
            preguntas4.Add(tipo);
        }
        pregunta5.AddOptions(preguntas4);
    }

    // Update is called once per frame
    void Update()
    {
        if (jugando)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                PanelEntrePreguntas.SetActive(false);
                PanelDeJuego.SetActive(false);
                PanelDineroRapido.SetActive(false);
                PanelInicial.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                PanelInicial.SetActive(false);
                PanelDineroRapido.SetActive(false);
                PanelEntrePreguntas.SetActive(false);
                nroPregunta = 0;
                jugando = true;
                PanelDeJuego.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                PanelDeJuego.SetActive(false);
                PanelInicial.SetActive(false);
                PanelDineroRapido.SetActive(false);
                PanelEntrePreguntas.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                PanelEntrePreguntas.SetActive(false);
                PanelDineroRapido.SetActive(false);
                PanelInicial.SetActive(false);
                PanelDeJuego.SetActive(true);
                if (preguntasJuego[nroPregunta].getCantidadOpciones() < 6)
                {
                    respuesta6.SetActive(false);
                    if (preguntasJuego[nroPregunta].getCantidadOpciones() < 5)
                    {
                        respuesta5.SetActive(false);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                nombreRespuesta1.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(0);
                puntosRespuesta1.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(0).ToString();
                respuesta1.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                nombreRespuesta2.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(1);
                puntosRespuesta2.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(1).ToString();
                respuesta2.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                nombreRespuesta3.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(2);
                puntosRespuesta3.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(2).ToString();
                respuesta3.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                nombreRespuesta4.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(3);
                puntosRespuesta4.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(3).ToString();
                respuesta4.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                nombreRespuesta5.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(4);
                puntosRespuesta5.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(4).ToString();
                respuesta5.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                nombreRespuesta6.GetComponent<Text>().text = preguntasJuego[nroPregunta].getRespuesta(5);
                puntosRespuesta6.GetComponent<Text>().text = preguntasJuego[nroPregunta].getPuntos(5).ToString();
                respuesta6.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (equipoJugando == 0)
                {
                    if (sonidoError.activeSelf)
                    {
                        sonidoError.SetActive(false);
                    }
                    else
                    {
                        sonidoError.SetActive(true);
                    }
                }
                else
                {
                    if(equipoJugando==1)
                    {
                        if (!error1Equipo1.activeSelf){
                            error1Equipo1.SetActive(true);
                        }
                        else{
                            if (!error2Equipo1.activeSelf){
                                error2Equipo1.SetActive(true);
                            }
                            else{
                                error3Equipo1.SetActive(true);
                            }
                        }
                    }
                    else
                    {
                        if (!error1Equipo2.activeSelf){
                            error1Equipo2.SetActive(true);
                        }
                        else{
                            if (!error2Equipo2.activeSelf){
                                error2Equipo2.SetActive(true);
                            }
                            else{
                                error3Equipo2.SetActive(true);
                            }
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F9))
            {
                sumarPuntos();
            }
            if (Input.GetKeyDown(KeyCode.F10))
            {
                resetearTablero();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (nroPregunta >= 5)
                {
                    pasarDineroRapido();
                }
            }
        }
        if (dineroRapido)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (equipoJugando == 1)
                {
                    string respuesta = nombreDRRespuesta11.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(0,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(0,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta11.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
                else{
                    string respuesta = nombreDRRespuesta12.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(0,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(0,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta12.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (equipoJugando == 1)
                {
                    string respuesta = nombreDRRespuesta21.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(1,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(1,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta21.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
                else{
                    string respuesta = nombreDRRespuesta22.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(1,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(1,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta22.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (equipoJugando == 1)
                {
                    string respuesta = nombreDRRespuesta31.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(2,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(2,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }

                    }
                    puntosDRRespuesta31.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
                else{
                    string respuesta = nombreDRRespuesta32.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(2,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(2,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta32.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (equipoJugando == 1)
                {
                    string respuesta = nombreDRRespuesta41.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(3,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(3,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta41.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
                else{
                    string respuesta = nombreDRRespuesta42.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(3,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(3,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta42.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (equipoJugando == 1)
                {
                    string respuesta = nombreDRRespuesta51.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(4,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(4,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta51.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
                else{
                    string respuesta = nombreDRRespuesta52.GetComponent<Text>().text;
                    int puntos = 0; 
                    if (juegoDineroRapido.getRespuesta1(4,respuesta))
                    {
                        sonidoCorrectoDR.SetActive(false);
                        sonidoCorrectoDR.SetActive(true);
                        puntos = 2;
                    }
                    else
                    {
                        if (juegoDineroRapido.getRespuesta2(4,respuesta))
                        {
                            sonidoCorrectoDR.SetActive(false);
                            sonidoCorrectoDR.SetActive(true);
                            puntos = 1;
                        }
                        else{
                            sonidoErrorDR.SetActive(false);
                            sonidoErrorDR.SetActive(true);
                        }
                    }
                    puntosDRRespuesta52.GetComponent<Text>().text = puntos.ToString();
                    int total = int.Parse(puntosTotal.GetComponent<Text>().text) + puntos;
                    puntosTotal.GetComponent<Text>().text = total.ToString();
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (cronometro.estaJugando())
                {
                    cronometro.setStartTime(25);
                    cronometro.setJugando(false);
                }
                else
                {
                    cronometro.setJugando(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F11))
        {
            equipoJugando = 1;
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            equipoJugando = 2;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (musicaTension.activeSelf)
            {
                musicaTension.SetActive(false);
            }
            else{
                musicaTension.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (musicaFondo.activeSelf)
            {
                musicaFondo.SetActive(false);
            }
            else{
                musicaFondo.SetActive(true);
            }
        }
        
    }

    private void pasarDineroRapido()
    {
        resetearTablero();
        nroPregunta = 1;
        puntosEquipo1.text = int.Parse("0").ToString();
        puntosEquipo2.text = int.Parse("0").ToString();
        jugando = false;
        dineroRapido = true;
        PanelDeJuego.SetActive(false);
        PanelEntrePreguntas.SetActive(false);
        PanelInicial.SetActive(false);
        PanelDineroRapido.SetActive(true);
        juegoDineroRapido = dinerosRapidos.getDineroRapidoRandom();
    }

    private void sumarPuntos()
    {
        int suma = 0;
        if (puntosRespuesta1.activeSelf){
            suma += int.Parse(puntosRespuesta1.GetComponent<Text>().text);
        }
        if (puntosRespuesta2.activeSelf){
            suma += int.Parse(puntosRespuesta2.GetComponent<Text>().text);
        }
        if (puntosRespuesta3.activeSelf){
            suma += int.Parse(puntosRespuesta3.GetComponent<Text>().text);
        }
        if (puntosRespuesta4.activeSelf){
            suma += int.Parse(puntosRespuesta4.GetComponent<Text>().text);
        }
        if (puntosRespuesta5.activeSelf){
            suma += int.Parse(puntosRespuesta5.GetComponent<Text>().text);
        }
        if (puntosRespuesta6.activeSelf){
            suma += int.Parse(puntosRespuesta6.GetComponent<Text>().text);
        }
        if (nroPregunta == 4)
        {
            suma = suma * 2;
        }
        if (nroPregunta == 5)
        {
            suma = suma * 3;
        }
        if (equipoJugando == 1)
        {
            puntosEquipo1.text = (int.Parse(puntosEquipo1.text)+suma).ToString();
        }
        else
        {
            puntosEquipo2.text = (int.Parse(puntosEquipo2.text)+suma).ToString();
        }
    }

    private void resetearTablero()
    {
        respuesta1.SetActive(false);
        respuesta2.SetActive(false);
        respuesta3.SetActive(false);
        respuesta4.SetActive(false);
        respuesta5.SetActive(false);
        respuesta6.SetActive(false);
        respuestaOculta1.SetActive(true);
        respuestaOculta2.SetActive(true);
        respuestaOculta3.SetActive(true);
        respuestaOculta4.SetActive(true);
        respuestaOculta6.SetActive(true);
        respuestaOculta5.SetActive(true);
        error1Equipo1.SetActive(false);
        error2Equipo1.SetActive(false);
        error3Equipo1.SetActive(false);
        error1Equipo2.SetActive(false);
        error2Equipo2.SetActive(false);
        error3Equipo2.SetActive(false);
        equipoJugando = 0;
        nroPregunta += 1;
        if (nroPregunta >= 3){
            respuestaOculta6.SetActive(false);
        }
        if (nroPregunta >= 4){
            respuestaOculta5.SetActive(false);
        }
    }

    public void cargarDatos()
    {
        cargarNombresFamilias();
        cargarPreguntas();
        jugando = true;
    }

    private void cargarNombresFamilias()
    {
        nombreFamilia1Juego.text = nombreFamilia1.text;
        nombreFamilia2Juego.text = nombreFamilia2.text;
    }

    private void cargarPreguntas(){
        preguntasJuego[0] = preguntasGenerales.getPregunta(pregunta1.captionText.text);
        preguntasJuego[1] = preguntasGenerales.getPregunta(pregunta2.captionText.text);
        preguntasJuego[2] = preguntasGenerales.getPregunta(pregunta3.captionText.text);
        preguntasJuego[3] = preguntasGenerales.getPregunta(pregunta4.captionText.text);
        preguntasJuego[4] = preguntasGenerales.getPregunta(pregunta5.captionText.text);
    }
}
