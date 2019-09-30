using MulTools.Components.Function;
using System;
using System.Windows.Forms;

namespace MulTools.Components
{
    /// <summary>
    /// Listens for shell events and closes the thumbnail if a cloned window is destroyed.
    /// </summary>
    class WindowKeeper : BaseMessagePumpProcessor
    {
        public override bool Process(ref Message msg)
        {
            if (Form.CurrentThumbnailWindowHandle != null && msg.Msg == HookMethods.WM_SHELLHOOKMESSAGE)
            {
                int hookCode = msg.WParam.ToInt32();

                if (hookCode == HookMethods.HSHELL_WINDOWDESTROYED)
                {
                    //Check whether the destroyed window is the one we were cloning
                    IntPtr destroyedHandle = msg.LParam;
                    if (destroyedHandle == Form.CurrentThumbnailWindowHandle.Handle)
                    {
                        Form.UnsetThumbnail();//Disable cloning
                    }
                }
            }
            return false;
        }

        protected override void Shutdown()
        {
        }
    }
}
