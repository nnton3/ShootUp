﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Gameplay
{
    public interface IFallTrigger
    {
        event Action OnGunFall;
    }
}
