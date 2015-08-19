﻿using Engine.Contracts;
using Engine.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.CustomEventArgs
{
    public class OutbreakEventArgs
    {
        public List<NodeDiseaseCounter> OriginList { get; private set; }
        public NodeDiseaseCounter OriginCounter { get; private set; }
        public List<NodeDiseaseCounter> AffectedCities { get; private set; }

        public OutbreakEventArgs(NodeDiseaseCounter originCounter, OutbreakEventArgs outbreakEventArgs = null)
        {
            OriginCounter = originCounter;
            OriginList = new List<NodeDiseaseCounter>(){originCounter};
            AffectedCities = new List<NodeDiseaseCounter>();

            if(outbreakEventArgs != null)
            {
                foreach (NodeDiseaseCounter ndc in outbreakEventArgs.OriginList)
                {
                    OriginList.Add(ndc);
                }
            }
        }
    }
}
