using System.Windows.Forms;

namespace MulTools.Components
{
    public abstract class BaseMessagePumpProcessor : IMessagePumpProcessor
    {
        protected Monitor Form { get; private set; }

        public virtual void Initialize(Monitor form) => Form = form;

        public abstract bool Process(ref Message msg);

        protected abstract void Shutdown();

        bool _isDisposed = false;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            Shutdown();
            _isDisposed = true;
        }
    }
}
