

using MassTransit;
using System;

namespace AwasthiSM.ServiceBus
{
    public class MassTransitBus : ITransitBus,IDisposable
    {

        private IBusControl _busControl;
        private bool disposedValue = false;
        public MassTransitBus(IBusControl busControl)
        {
            _busControl = busControl;
        }
        IBusControl ITransitBus.GetBus => _busControl;

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _busControl.Stop();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
