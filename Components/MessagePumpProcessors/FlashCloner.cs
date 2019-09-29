using MulTools.Components.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulTools.Components
{
    /// <summary>
    /// Automatically clones windows that are flashing.
    /// </summary>
    class FlashCloner : BaseMessagePumpProcessor
    {
        public override bool Process(ref System.Windows.Forms.Message msg)
        {
            if (false && msg.Msg == HookMethods.WM_SHELLHOOKMESSAGE)
            {
                int hookCode = msg.WParam.ToInt32();
                if (hookCode == HookMethods.HSHELL_FLASH)
                {
                    IntPtr flashHandle = msg.LParam;
                    Form.SetThumbnail(new WindowHandle(flashHandle), null);
                }
            }
            return false;
        }

        protected override void Shutdown()
        {

        }
    }
}
