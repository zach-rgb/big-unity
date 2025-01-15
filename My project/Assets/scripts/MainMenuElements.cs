using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;
public class MainMenuElements : MonoBehaviour{
    public CanvasGroup canvasGroup;
    Stopwatch stopwatch = new Stopwatch();
    private bool fadeIn = false;
    private bool fadeOut = false;
    public Instantiating instantiating;
    public StartPressed startPressed;
    int previousTime = 0;
    int counter = 0;

    public GameObject IntroMenuParent,IntroLogoParent;
    
    public void FadeInElements(){
        
        stopwatch.Start();

        fadeIn = true;
    }

    public void FadeOutElements(){
        
        stopwatch.Start();

        fadeOut = true;
    }

    void Update(){

        if(fadeIn == true){

            if (stopwatch.ElapsedMilliseconds >= previousTime + 48){
                float timeInSeconds = (stopwatch.ElapsedMilliseconds)/ 1000f;

                float alpha = 0.5f * (float)(Math.Sin(0.5f * Math.PI * (timeInSeconds - 1f))) + 0.5f;

                canvasGroup.alpha = alpha;

                counter += 1;
                previousTime = (int)stopwatch.ElapsedMilliseconds;

                if(alpha >= 0.98){

                    fadeIn = false;
                    canvasGroup.alpha = 1;
                    stopwatch.Stop();

                }

        }
    }
    else if(fadeOut == true){

            if (stopwatch.ElapsedMilliseconds >= previousTime + 48){
                float timeInSeconds = (stopwatch.ElapsedMilliseconds)/ 1000f;

                float alpha = 0.5f * (float)(Math.Cos(0.5f * Math.PI * (timeInSeconds))) + 0.5f;

                canvasGroup.alpha = alpha;

                counter += 1;
                previousTime = (int)stopwatch.ElapsedMilliseconds;

                if(alpha <= 0.02){

                    fadeOut = false;
                    canvasGroup.alpha = 0;
                    stopwatch.Stop();

                }

        }
    }
    else if((fadeOut == false && instantiating.Finished == true) || startPressed.Pressed == true){
        canvasGroup.alpha = 0;
        Destroy(IntroMenuParent);
        Destroy(IntroLogoParent);
    }

}

}
