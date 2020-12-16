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

        BindingList<Lottery> OneHit = new BindingList<Lottery>();
        BindingList<Lottery> TwoHit = new BindingList<Lottery>();
        BindingList<Lottery> ThreeHit = new BindingList<Lottery>();
        BindingList<Lottery> FourHit = new BindingList<Lottery>();
        BindingList<Lottery> FiveHit = new BindingList<Lottery>();
        public Form1()
        {
            InitializeComponent();
            context.Lotteries.Load();
            


        }

        public void RollNew()
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            RollNew();
        }
    }
}
