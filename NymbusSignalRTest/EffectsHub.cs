using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace NymbusSignalRTest
{
    [HubName("effectsHub")]
    public class EffectsHub : Hub
    {
        private readonly EffectsList _effect;
        public EffectsHub() : this(EffectsList.Instance) { }
        public EffectsHub(EffectsList effect)
        {
            _effect = effect;
        }
        public IEnumerable<Effect> GetAllEffects()
        {
            return _effect.GetAllEffects();
        }
    }
}