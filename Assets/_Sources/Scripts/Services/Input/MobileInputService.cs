﻿using UnityEngine;

namespace _Sources.Scripts.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}