using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEventBus
{
    public class EventBus
    {
        public static Action endGame;
        public static Action<int> addPoints;
    }
}
