using System;
using System.Collections.Generic;
using System.Drawing;
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

            DisplayMember = "Name";
            BackColor = Color.Honeydew;
            Font = new Font("Rockwell", 10);
            HorizontalScrollbar = true;

        }


    }
}
