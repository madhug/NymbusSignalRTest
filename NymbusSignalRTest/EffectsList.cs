using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace NymbusSignalRTest
{
    public class EffectsList
    {
    // Singleton instance
        private readonly static Lazy<EffectsList> _instance = new Lazy<EffectsList>(() => new EffectsList(GlobalHost.ConnectionManager.GetHubContext<EffectsHub>().Clients));
        private readonly ConcurrentDictionary<string, Effect> _effects = new ConcurrentDictionary<string, Effect>();

        private EffectsList(IHubConnectionContext clients)
        {
            Clients = clients;

            _effects.Clear();
            var effects = new List<Effect>
            {
                new Effect {name = "Effect 1", light = new Light(), action = PhoneAction.Pump, position = 1},
                new Effect {name = "Effect 2", light = new Light(), action = PhoneAction.Pump, position = 2},
                new Effect {name = "Effect 3", light = new Light(), action = PhoneAction.Pump, position = 3}
            };
            effects.ForEach(effect => _effects.TryAdd(effect.name, effect));
        }

        public static EffectsList Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext Clients
        {
            get;
            set;
        }

        public IEnumerable<Effect> GetAllEffects()
        {
            return _effects.Values;
        }

        private void BroadcastStockPrice(Effect effect)
        {
            Clients.All.update(effect);
        }

    }
}