using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NymbusSignalRTest
{
    public class Effect
    {
        public string name { get; set; }
        public Light light { get; set; }
        public int sound { get; set; }
        public PhoneAction action { get; set; }
        public float duration { get; set; }
        public int position { get; set; }

        public Effect(Light l, PhoneAction act, int pos = 0, int s = 0, float d = 1)
        {
            light = l;
            sound = s;
            action = act;
            duration = d;
            position = pos; 
        }
        public Effect() { }

    }

    public class Light
    {
        public Color fromColor { get; set; }
        public Color toColor { get; set; }
        public float duration { get; set; }
    }

    public class Color
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
    }

    public enum PhoneAction { Wave, Pump }
}