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
            OneHit.Clear();
            TwoHit.Clear();
            ThreeHit.Clear();
            FourHit.Clear();
            FiveHit.Clear();

            Random rnd = new Random();
            int[] winnum = new int[5];
            for (int i = 0; i < 5; i++)
            {
                winnum[i] = rnd.Next(1, 91);
            }

            if (!CheckWinningNumbers(winnum))
            {
                MessageBox.Show("Kettő vagy több szám megegyezik, a sorsolás érvénytelen!");
                return;
            }

            numButton1.Text = winnum[0].ToString();
            numButton2.Text = winnum[1].ToString();
            numButton3.Text = winnum[2].ToString();
            numButton4.Text = winnum[3].ToString();
            numButton5.Text = winnum[4].ToString();

            foreach (var Lottery in context.Lotteries)
            {
                int hit = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (Lottery.Number1 == winnum[i])
                    {
                        hit++;
                    }
                    if (Lottery.Number2 == winnum[i])
                    {
                        hit++;
                    }
                    if (Lottery.Number3 == winnum[i])
                    {
                        hit++;
                    }
                    if (Lottery.Number4 == winnum[i])
                    {
                        hit++;
                    }
                    if (Lottery.Number5 == winnum[i])
                    {
                        hit++;
                    }
                }
                switch (hit)
                {
                    case 1:
                        OneHit.Add(Lottery);
                        break;
                    case 2:
                        TwoHit.Add(Lottery);
                        break;
                    case 3:
                        ThreeHit.Add(Lottery);
                        break;
                    case 4:
                        FourHit.Add(Lottery);
                        break;
                    case 5:
                        FiveHit.Add(Lottery);
                        break;
                    default:
                        break;
                }
            }

            winListBox1.DataSource = OneHit;
            winListBox2.DataSource = TwoHit;
            winListBox3.DataSource = ThreeHit;
            winListBox4.DataSource = FourHit;
            winListBox5.DataSource = FiveHit;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RollNew();
        }
        public bool CheckWinningNumbers(int[] winnum)
        {
            int match = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = i; j < 4; j++)
                {
                    if (winnum[i] == winnum[j + 1])
                    {

                        match++;
                    }

                }
            }
            if (match == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
