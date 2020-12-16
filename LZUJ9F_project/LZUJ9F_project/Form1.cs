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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

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

        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
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

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void CreateTable()
        {
            string[] headers = new string[]
            {
                "1 találat",
                "2 találat",
                "3 találat",
                "4 találat",
                "5 találat",
            };
            
            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, i + 1] = headers[i];
            }

            if (OneHit.Count != 0)
            {
                for (int i = 0; i < OneHit.Count; i++)
                {
                    xlSheet.Cells[i + 2, 1] = OneHit[i].Name;
                }
            }

            if (TwoHit.Count != 0)
            {
                for (int i = 0; i < TwoHit.Count; i++)
                {
                    xlSheet.Cells[i + 2, 2] = TwoHit[i].Name;
                }
            }

            if (ThreeHit.Count != 0)
            {
                for (int i = 0; i < ThreeHit.Count; i++)
                {
                    xlSheet.Cells[i + 2, 3] = ThreeHit[i].Name;
                }
            }

            if (FourHit.Count != 0)
            {
                for (int i = 0; i < FourHit.Count; i++)
                {
                    xlSheet.Cells[i + 2, 4] = FourHit[i].Name;
                }
            }

            if (FiveHit.Count != 0)
            {
                for (int i = 0; i < FiveHit.Count; i++)
                {
                    xlSheet.Cells[i + 2, 5] = FiveHit[i].Name;
                }
            }
            

            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
            headerRange.Interior.Color = Color.Orange;

            int lastRowID = xlSheet.UsedRange.Rows.Count;
            Excel.Range fullRange = xlSheet.get_Range(GetCell(1, 1), GetCell(lastRowID, headers.Length));
            fullRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);



        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);

            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }
    }
}
