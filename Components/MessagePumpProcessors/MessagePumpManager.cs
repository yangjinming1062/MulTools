using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MulTools.Components
{
    interface IMessagePumpProcessor : IDisposable
    {
        void Initialize(Monitor form);

        bool Process(ref Message msg);
    }

    public class MessagePumpManager : IDisposable
    {

        Dictionary<Type, IMessagePumpProcessor> _processors = new Dictionary<Type, IMessagePumpProcessor>();

        public Form Form { get; private set; }

        private void Register(IMessagePumpProcessor processor, Monitor form)
        {
            _processors[processor.GetType()] = processor;
            processor.Initialize(form);
        }

        /// <summary>
        /// Instantiates all message pump processors and registers them on the main form.
        /// </summary>
        /// <param name="form"></param>
        public void Initialize(Monitor form)
        {
            Form = form;

            //Register message pump processors
            Register(new WindowKeeper(), form);
            Register(new GroupSwitchManager(), form);
            Register(new FlashCloner(), form);
        }

        /// <summary>
        /// Run the registered message pump processors.
        /// </summary>
        /// <param name="msg">Message to process.</param>
        /// <returns>True if the message has been handled internally.</returns>
        public bool PumpMessage(ref Message msg)
        {
            foreach (var processor in _processors.Values)
            {
                if (processor.Process(ref msg))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Get the instance of a registered message pump processor.
        /// Throws if instance not found.
        /// </summary>
        public T Get<T>()
        {
            return (T)_processors[typeof(T)];
        }

        #region IDisposable Members

        public void Dispose()
        {
            foreach (var processor in _processors.Values)
            {
                processor.Dispose();
            }
            _processors.Clear();
        }
        #endregion
    }
}
