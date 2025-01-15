using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;
public class MainMenuLogo : MonoBehaviour{

    public RawImage rawImage;
    Stopwatch stopwatch = new Stopwatch();
    int counter = 0;
    int previousTime = 0;
    private bool PlayLogo = true;
    private bool stopWatch = false;

    public MainMenuElements mainMenuElements;

    void Start(){

        Color color = rawImage.color;
        color.a = Mathf.Clamp01(0);
        rawImage.color = color;
    }

    void startstopwatch(float time, bool running){

        if(Time.time >= 1f && running == false)
        stopwatch.Start();
    }

    void LogoFinished(){

        mainMenuElements.FadeInElements();
    }

    void Update()
    {

        if(PlayLogo && Time.time > 1f){

            startstopwatch(Time.time,stopWatch);

            if (stopwatch.ElapsedMilliseconds >= previousTime + 48){
                float timeInSeconds = (stopwatch.ElapsedMilliseconds)/ 1000f;

                float alpha = 0.5f * (float)(Math.Sin(0.5f * Math.PI * (timeInSeconds - 1f))) + 0.5f;

                Color color = rawImage.color;
                color.a = Mathf.Clamp01(alpha);
                rawImage.color = color;

                UnityEngine.Debug.Log(alpha);
                counter += 1;
                previousTime = (int)stopwatch.ElapsedMilliseconds;

                if(alpha <= 0.05 && timeInSeconds >= 3f){

                    PlayLogo = false;
                    color.a = Mathf.Clamp01(0);
                    rawImage.color = color;

                    LogoFinished();

                }
            }
        }
    }
}