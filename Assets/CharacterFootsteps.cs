using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFootsteps : MonoBehaviour 
{

    private enum CURRENT_TERRAIN { GRASS, PUDDLE, WOOD };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance Character_Foosteps;
    private FMOD.Studio.EventInstance Object_take;
    private FMOD.Studio.EventInstance Object_use;

    private void Update()
    {
        DetermineTerrain();
    }

    private void FixedUpdate()
    {
        DetermineTerrain();
        Debug.DrawRay(transform.position, Vector3.down * 10.0f, Color.blue);
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        // Originally set at 10.0f, but needs to be set to 0.25 for Robot scenario due to how the level is built.
        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
            {
                if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
                {
                    currentTerrain = CURRENT_TERRAIN.GRASS;
                    break;
                }
                else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Puddle"))
                {
                    currentTerrain = CURRENT_TERRAIN.PUDDLE;
                    break;
                }
                else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
                {
                    currentTerrain = CURRENT_TERRAIN.WOOD;
                }
            }
    }

    public void SelectAndPlayFootstep()
    {     
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.GRASS:
                PlayFootstep("Grass");
                break;

            case CURRENT_TERRAIN.PUDDLE:
                PlayFootstep("Puddle");
                break;

            case CURRENT_TERRAIN.WOOD:
                PlayFootstep("Wood");
                break;

            default:
                PlayFootstep("Puddle");
                break;
        }
    }

    private void PlayFootstep(string terrain)
    {
        Character_Foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Main_Character/Character_Footsteps");
        Character_Foosteps.setParameterByNameWithLabel("Terrain", terrain);
        Character_Foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Character_Foosteps.start();
        Character_Foosteps.release();
    }

    private void PlayUse()
    {
        Object_use = FMODUnity.RuntimeManager.CreateInstance("event:/UI_And_Menu/Object_use");
        Object_use.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Object_use.start();
        Object_use.release();
    }

    private void ItemTakeSound()
    {
        Object_take = FMODUnity.RuntimeManager.CreateInstance("event:/UI_And_Menu/Object_take");
        Object_take.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Object_take.start();
        Object_take.release();
    }
}