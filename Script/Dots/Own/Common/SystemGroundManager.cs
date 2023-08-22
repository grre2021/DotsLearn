using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract partial class AuthoringSceneSystemGroup :ComponentSystemGroup
{
    public bool initialized;
    
    protected abstract string AuthoringSceneName { get; }
    protected override void OnCreate()
    {
        base.OnCreate();
        initialized = false;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (!initialized)
        {
            if (SceneManager.GetActiveScene().isLoaded)
            {
                SubScene subScene = Object.FindObjectOfType<SubScene>();
                if (subScene != null)
                {
                    Enabled = AuthoringSceneName == subScene.gameObject.scene.name;
                }
                else
                {
                    Enabled = false;
                }
            }
        }
    }
}
