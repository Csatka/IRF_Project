using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZUJ9F_project
{
    class NumButton : Button
    {
        public NumButton()
        {
            Height = 50;
            Width = Height;
            Enabled = false;
            BackColor = Color.Gold;
            Font = new Font("Rockwell", 16);

            
        }
    }
}
