using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
 private FMOD.Studio.EventInstance Enemy_Detect;
 private FMOD.Studio.EventInstance Enemy_Foosteps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void detect_sound()
    {
        Enemy_Detect = FMODUnity.RuntimeManager.CreateInstance("event:/Enemy/Enemy_Detect");
        Enemy_Detect.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Enemy_Detect.start();
        Enemy_Detect.release();
    } 

    private void PlayFootstep_enemy()
    {
        Enemy_Foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Enemy/Enemy_Footsteps");
        Enemy_Foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Enemy_Foosteps.start();
        Enemy_Foosteps.release();
    }

}

