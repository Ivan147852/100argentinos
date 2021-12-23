 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class Cronometro : MonoBehaviour {
    private float StartTime;
    private bool jugando;
    private float TimerControl;
    public float initialTime;
    private bool setTime = true;
    public GameObject sonidoFinTiempo;
    public GameObject sonidoTiempo;
    void Start () {
        TimerControl = initialTime;
        
    }
    void Update(){
        if (jugando)
        {
            if (setTime)
            {
                StartTime = Time.time;
                setTime = false;
                sonidoFinTiempo.SetActive(false);
                sonidoTiempo.SetActive(true);
            }
            if (TimerControl > 0.0f)
            {
                TimerControl = initialTime - (Time.time - StartTime);
                string mins = ((int)TimerControl/60).ToString("00");
                string segs = (TimerControl % 60).ToString("00");
                string milisegs = ((TimerControl * 100)%100).ToString ("00");
                
                string TimerString = string.Format ("{00}:{01}:{02}", mins, segs, milisegs);
                
                GetComponent<Text>().text = TimerString.ToString ();
            }
            else
            {
                setTime = true;
                sonidoTiempo.SetActive(false);
                sonidoFinTiempo.SetActive(true);
            }
            
        }
    }
    
    public void setJugando(bool jugando)
    {
        this.jugando = jugando;
    }

    public bool estaJugando()
    {
        return jugando;
    }

    public void setStartTime(float time)
    {
        GetComponent<Text>().text = time.ToString();
        initialTime = time;
        TimerControl = time;
    }
 }
