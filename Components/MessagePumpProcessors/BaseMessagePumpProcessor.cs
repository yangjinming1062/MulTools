using System.Windows.Forms;

namespace MulTools.Components
{
    public abstract class BaseMessagePumpProcessor : IMessagePumpProcessor
    {
        protected Monitor Form { get; private set; }

        #region IMessagePumpProcessor Members

        public virtual void Initialize(Monitor form)
        {
            Form = form;
        }

        public abstract bool Process(ref Message msg);

        #endregion

        protected abstract void Shutdown();

        bool _isDisposed = false;

        #region IDisposable Members
        public void Dispose()
        {
            if (_isDisposed)
                return;

            Shutdown();
            _isDisposed = true;
        }
        #endregion
    }
}
