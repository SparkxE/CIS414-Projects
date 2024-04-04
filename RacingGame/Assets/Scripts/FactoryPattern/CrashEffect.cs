using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffect : MonoBehaviour, IEffect
{
    [SerializeField] private string effectName;
    private AudioSource audioSource;

    public string EffectName{
        get{
            return this.effectName;
        }
        set{
            this.effectName = value;
        }
    }

    public void Initialize(){
        gameObject.name = EffectName;
        audioSource = GetComponent<AudioSource>();
        audioSource?.Play();
        Invoke("SelfDestruct", 2f);
    }

    private void SelfDestruct(){
        Destroy(gameObject);
    }
}
