using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZUJ9F_project
{
    class WinListBox : ListBox
    {
        public WinListBox()
        {
            //Visible = false;
            ValueMemberChanged += WinListBox_ValueMemberChanged;
            DisplayMember = "Name";
            
        }

        private void WinListBox_ValueMemberChanged(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
