﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paletkowo.Models
{
    public class Score
    {
        public Score()
        {
            this.score_player = 0;
            this.score_bot = 0;
        }

        public double score_player { get;set;}
        public double score_bot { get; set; }
    }
}
