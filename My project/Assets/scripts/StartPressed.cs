using UnityEngine;
using TMPro;

public class StartPressed : MonoBehaviour
{
    private bool buttonPressed;
    public TMP_Dropdown diffy;
    public TMP_Dropdown map_Size;
    public Instantiating instantiating;
    public int mapSize = 0;
    public int difficulty= 0;
    public bool Pressed = false;

    public MainMenuElements mainMenuElements;
    public CameraPlayMode cameraPlayMode;

    public void ButtonPressed(){

        Debug.Log("AOSidhaslkdh");

        difficulty = diffy.value;

        if(map_Size.value == 0){

            mapSize = 11;
        }
        else if(map_Size.value == 1){

            mapSize = 21;
        }
        else if(map_Size.value == 2){

            mapSize = 33;
        }

        mainMenuElements.FadeOutElements();

        instantiating.GenerateMap(mapSize);

        cameraPlayMode.EditVignetteVal(0.3f);

        cameraPlayMode.EditFocus(1f);

        Pressed = true;

    }

}