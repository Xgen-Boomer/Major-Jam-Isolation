using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;



/**
 * How to use
 * 1. Load and parse data.
 *    factory.LoadDragonBonesData("DragonBonesDataPath");
 *    factory.LoadTextureAtlasData("TextureAtlasDataPath");
 *    
 * 2. Build armature.
 *    armatureComponent = factory.BuildArmatureComponent("armatureName");
 * 
 * 3. Play animation.
 *    armatureComponent.animation.Play("animationName");
 */


public class RobotAnimation : MonoBehaviour
{

    public UnityDragonBonesData dragonBoneData;
    // Start is called before the first frame update
    void Start()
    {
        UnityFactory.factory.autoSearch = true;
        UnityFactory.factory.LoadData(dragonBoneData);

        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Robot");
        armatureComponent.animation.FadeIn ("idle", 0.25f, -1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
