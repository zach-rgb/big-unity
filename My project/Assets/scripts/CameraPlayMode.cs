using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraPlayMode : MonoBehaviour
{
    public Volume globalVolume;

    public void EditVignetteVal(float X)
    {

        var profile = globalVolume.profile;

        if (!profile.TryGet<Vignette>(out var vignette)){

            vignette = profile.Add<Vignette>();
        }

        vignette.intensity.overrideState = true;
        vignette.intensity.value = X;
        
    }
    public void EditFocus(float X)
    {

        var profile = globalVolume.profile;

        if (!profile.TryGet<DepthOfField>(out var depthOfField)){

            depthOfField = profile.Add<DepthOfField>();
        }

        depthOfField.focalLength.overrideState = true;
        depthOfField.focalLength.value = X;
        
    }
    public void EditColors(float X, float Y, float Z)
    {



        var profile = globalVolume.profile;

        if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments)){

            colorAdjustments = profile.Add<ColorAdjustments>();
        }

        colorAdjustments.colorFilter.overrideState = true;
        colorAdjustments.colorFilter.value = new Color(X/255, Y/255, Z/255);
        
    }
    
}
