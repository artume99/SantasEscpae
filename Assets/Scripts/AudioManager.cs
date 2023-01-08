using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
   public FMODUnity.EventReference[] eventReferences;
   private List<FMOD.Studio.EventInstance> _eventInstances;

   public enum Sounds
   {
      WallMove,
      Button,
      DrawerOpen,
      DoorOpen,
      PushBook,
      ClockTicking,
      MainLoop,
      Tasty,
      ToastReady,
      Win,
      Fail,
      HoverButton,
      ClickButton,

   }

   protected override void Awake()
   {
      base.Awake();
      _eventInstances = new List<EventInstance>();
      foreach (var fmodEvent in eventReferences)
      {
         EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent.Guid);
         instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
         _eventInstances.Add(instance);
      }
   }

   public EventInstance PlaySound(Sounds sound)
   {
      
      _eventInstances[(int)sound].start();
      _eventInstances[(int)sound].set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
      return _eventInstances[(int)sound];
   }
   

   public void StopSound(Sounds sound)
   {
      _eventInstances[(int)sound].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
      // _eventInstances[(int)sound].release();
   }

   public void PlayOneShot(Sounds sound)
   {
      FMODUnity.RuntimeManager.PlayOneShot(eventReferences[(int)sound]);
   }

   public void PlayOneShotAttach(Sounds sound, GameObject attach)
   {
      FMODUnity.RuntimeManager.PlayOneShotAttached(eventReferences[(int)sound], attach);
   }
   
   public bool IsPlaying(FMOD.Studio.EventInstance instance) {
      FMOD.Studio.PLAYBACK_STATE state;   
      instance.getPlaybackState(out state);
      return state != FMOD.Studio.PLAYBACK_STATE.STOPPED;
   }
   
   public IEnumerator WaitForSoundToFinish(EventInstance instance)
   {
      while (AudioManager.Instance.IsPlaying(instance))
      {
         yield return null;
      }
        
   }

   public EventInstance GetSoundEventInstance(Sounds sound)
   {
      return _eventInstances[(int)sound];
   }

   public void PlayFmodEventEmitter(GameObject obj)
   {
      StudioEventEmitter eventEmitter = obj.GetComponent<StudioEventEmitter>();
      if(!eventEmitter)
         Debug.Log("Event Emitter is not found");
      eventEmitter.Play();
   }
}
