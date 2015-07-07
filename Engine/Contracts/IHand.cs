﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Contracts
{
    public interface IHand
    {
        IEnumerable<ICard> Cards { get; }
        void Draw(IDeck deck);
    }
}
