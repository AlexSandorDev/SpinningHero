using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSFXHandler : MonoBehaviour
{
    [Header("Mixers")]
    [SerializeField] AudioMixer audioMixer;

    [Header("Audio sources")]
    [SerializeField] AudioSource tiresScreeachingAudioSource;
    [SerializeField] AudioSource engineAudioSource;
    [SerializeField] AudioSource carHitAudioSource;
    [SerializeField] AudioSource carJumpAudioSource;
    [SerializeField] AudioSource carJumpLandingAudioSource;

    //Local variables
    [SerializeField] float desiredEnginePitch = 0.2f;
    [SerializeField] float tireScreechPitch = 0.5f;

    [SerializeField] float maxEngineVol = 1f;
    [SerializeField] float minEngineVol = 0.5f;

    [SerializeField] float hitVolume = 0.1f;
    [SerializeField] float hitMinPitch = 0.95f;
    [SerializeField] float hitMaxPitch = 1.05f;

    //Components
    TopDownCarController topDownCarController;

    //Awake is called when the script instance is being loaded.
    void Awake()
    {
        topDownCarController = GetComponentInParent<TopDownCarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Example for recording, move this part to any setting script that your game might use. 
        //audioMixer.SetFloat("SFXVolume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEngineSFX();
        UpdateTiresScreechingSFX();
    }

    void UpdateEngineSFX()
    {
        //Handle engine SFX
        float velocityMagnitude = topDownCarController.GetVelocityMagnitude();

        //Increase the engine volume as the car goes faster
        float desiredEngineVolume = velocityMagnitude * 0.05f;

        //But keep a minimum level so it playes even if the car is idle
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, minEngineVol, maxEngineVol);

        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        //To add more variation to the engine sound we also change the pitch
        var _desiredEnginePitch = velocityMagnitude * desiredEnginePitch;
        _desiredEnginePitch = Mathf.Clamp(_desiredEnginePitch, 0.5f, 2f);
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }

    void UpdateTiresScreechingSFX()
    {
        //Handle tire screeching SFX
        if (topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            //If the car is braking we want the tire screech to be louder and also change the pitch.
            if (isBraking)
            {
                tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScreechPitch = Mathf.Lerp(tireScreechPitch, 0.5f, Time.deltaTime * 10);
            }
            else
            {
                //If we are not braking we still want to play this screech sound if the player is drifting.
                tiresScreeachingAudioSource.volume = Mathf.Abs(lateralVelocity) * 0.05f;
                tireScreechPitch = Mathf.Abs(lateralVelocity) * 0.1f;
            }
        }
        //Fade out the tire screech SFX if we are not screeching. 
        else tiresScreeachingAudioSource.volume = Mathf.Lerp(tiresScreeachingAudioSource.volume, 0, Time.deltaTime * 10);
    }

    public void PlayJumpSfx()
    {
        carJumpAudioSource.Play();
    }

    public void PlayLandingSfx()
    {
        carJumpLandingAudioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Get the relative velocity of the collision
        float relativeVelocity = collision2D.relativeVelocity.magnitude;

        float volume = relativeVelocity * hitVolume;

        carHitAudioSource.pitch = Random.Range(hitMinPitch, hitMaxPitch);
        carHitAudioSource.volume = volume;

        if (!carHitAudioSource.isPlaying)
            carHitAudioSource.Play();
    }


}
