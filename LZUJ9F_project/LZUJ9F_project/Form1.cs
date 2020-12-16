using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZUJ9F_project
{
    public partial class Form1 : Form
    {
        LottoEntities context = new LottoEntities();
        public Form1()
        {
            InitializeComponent();
            context.Lotteries.Load();
            Random rnd = new Random();
            int[] winnum = new int[5];
            for (int i = 0; i < 5; i++)
            {
                winnum[i] = rnd.Next(1, 91);
            }
            numButton1.Text = winnum[0].ToString();
            numButton2.Text = winnum[1].ToString();
            numButton3.Text = winnum[2].ToString();
            numButton4.Text = winnum[3].ToString();
            numButton5.Text = winnum[4].ToString();
        }
    }
}
