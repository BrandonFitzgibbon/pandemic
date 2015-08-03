﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Contracts
{
    public interface IEpidemicCard : ICard
    {
        event EventHandler Increase;
        event EventHandler Infect;
        event EventHandler Intensify;
    }
}
