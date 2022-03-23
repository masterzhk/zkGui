using org.apache.zookeeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkGui
{
    public class StateWatcher : Watcher
    {
        public event Action<WatchedEvent> OnEvent;

        public override Task process(WatchedEvent @event)
        {
            return Task.Run(() => OnEvent?.Invoke(@event));
        }
    }
}
