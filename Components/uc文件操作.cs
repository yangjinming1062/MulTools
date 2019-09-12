using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Components
{
    public partial class uc文件操作 : UserControl
    {
        public uc文件操作()
        {
            InitializeComponent();
        }
        public List<Models.fileInfo> lsFile = new List<Models.fileInfo>();
    }
}
