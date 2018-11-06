using Arkanoid.States;
using System;

namespace Arkanoid
{
    public class Globals
    {
        //Score score;
        public int ScreenWidth { get; set; }
        public int ScreenHeight  { get; set;}
        public bool Paused { get; set; }
        public State currentState { get; set; }
        public State nextState { get; set; }
        public Random Random { get; set; }
        public Globals()
        {
            ScreenWidth = 500;
            ScreenHeight = 600;
            Paused = false;
            Random = new Random();
            //    score = new Score();
        }
    }
}