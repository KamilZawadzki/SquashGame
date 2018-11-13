using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Models
{
    public class Score
    {
        public Score()
        {
            this.score_player = 0;
        }

        public double score_player { get;set;}
    }
}
