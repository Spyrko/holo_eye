﻿using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;

namespace LocalJoost.HoloToolkitExtensions
{
    public class InitialPlaceByTap : MonoBehaviour, IInputClickHandler
    {
        protected AudioSource Sound;
        protected MoveByGaze GazeMover;

        protected void Start()
        {
            Sound = GetComponent<AudioSource>();
            GazeMover = GetComponent<MoveByGaze>();

            InputManager.Instance.PushFallbackInputHandler(gameObject);
        }

        public virtual void OnInputClicked(InputClickedEventData eventData)
        {
            if (!GazeMover.IsActive)
            {
                return;
            }

            if (Sound != null)
            {
                Sound.Play();
            }

            GazeMover.IsActive = false;
            SpatialMappingManager.Instance.DrawVisualMeshes = false;
        }
    }
}
