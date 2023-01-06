using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SprayBottle : MonoBehaviour
{
    [SerializeField] private Transform _holder;
    [SerializeField] private StudioEventEmitter _eventEmitter;
    private Coroutine inst;
    public void OnSpray(ActivateEventArgs args)
    {
        inst = null;
        int layerMask = 1 << 8;
        _eventEmitter.enabled = true;
        _eventEmitter.EventInstance.setParameterByName("sprayEnd", 0);


        RaycastHit hit;
        if (Physics.Raycast( _holder.position, _holder.TransformDirection(Vector3.forward), out hit, 2, layerMask))
        {
            var rawImage = GetMirrorImage(hit.transform);
            inst = StartCoroutine(RevealImage(rawImage));
            Debug.DrawRay( _holder.position, _holder.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay( _holder.position, _holder.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    public void OnStopSpray(DeactivateEventArgs args)
    {
        if(inst != null)
            StopCoroutine(inst);
        _eventEmitter.EventInstance.setParameterByName("sprayEnd", 1);
        _eventEmitter.enabled = false;
    }

    public Image GetMirrorImage(Transform obj)
    {
        var rawImage = obj.GetComponent<Image>();
        if (rawImage)
        {
            return rawImage;
        }
        foreach (Transform child in obj)
        {
            var childRawImage = GetMirrorImage(child);
            if (childRawImage)
            {
                return childRawImage;
            }
        }

        return null;
    }

    private IEnumerator RevealImage(Image image)
    {
        var currColor = image.color;
        while (image.color.a < 1)
        {
            currColor = image.color;
            image.color = new Color(currColor.r, currColor.g, currColor.b, currColor.a + 0.01f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
