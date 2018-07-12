/*
 *  Copyright 2013-Present Two Big Ears Limited
 *  All rights reserved.
 *  http://twobigears.com
 */

using UnityEngine;
using System.Collections;

namespace TBE
{
    public class AudioObjectEventListener : NativeEventListener
    {
        public delegate void EventDelegate(TBE.Event e, NativeAudioObject obj);
        public EventDelegate newEvent;

        protected override void onNewEvent(TBE.Event e, NativeAudioObject obj)
        {
            if (newEvent != null)
            {
                newEvent(e, obj);
            }
        }
    }

}