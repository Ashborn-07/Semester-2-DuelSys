﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class TournamentTime
    {
        private DateTime start;
        private DateTime end;

        public TournamentTime(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
