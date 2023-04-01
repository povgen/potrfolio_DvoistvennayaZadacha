using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DvoistvennayaZadacha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<TextBox> PricesTextBoxes = new List<TextBox>();
        TextBox[] boxesFuncX;     // Поля для ввода коэфицентов x в функции
        int CountOfX, CountOfY;

        public void DrawInputInterface(object sender, EventArgs e)
        {
            PricesTextBoxes.Clear();
            PricesPanel.Controls.Clear();
            expensesTable.Columns.Clear();
            funcPanel.Controls.Clear();
            boxesFuncX = new TextBox[(int)countOfProduct.Value];

            CountOfX = (int)countOfProduct.Value;
            CountOfY = (int)countOfRaw.Value;


            Label[] labelsX = new Label[(int)countOfProduct.Value];

            for (int i = 0; i <= countOfProduct.Value; i++)
            {
               
                if (i == 0)
                    expensesTable.Columns.Add("c" + i, "Продукт");
                else
                    expensesTable.Columns.Add("c" + i, "Продукт № " + i);

                if (i != countOfProduct.Value)
                {
                    Label label = new Label()
                    {
                        Width = 50,
                        Height = 15,
                        Text = "Товар " + (i + 1),
                        Location = new Point(5, 5 + 25 * i)
                    };
                    TextBox text = new TextBox()
                    {
                        Width = 50,
                        Height = 15,
                        Location = new Point(60, 5 + 25 * i)
                    };

                    PricesPanel.Controls.Add(text);
                    PricesPanel.Controls.Add(label);
                    PricesTextBoxes.Add(text);

                        
                    labelsX[i] = new Label()
                    {
                        Text = "X" + (i + 1),
                        Location = new Point(100 + i * 70, 10),
                        Height = 15,
                        Width = 20
                    };

                    boxesFuncX[i] = new TextBox()
                    {
                        Location = new Point(70 + i * 70, 8),
                        Height = 30,
                        Width = 30
                    };
                
                    funcPanel.Controls.Add(labelsX[i]);
                    funcPanel.Controls.Add(boxesFuncX[i]);
                }


            }
            Label funcLabel = new Label()
            {
                Location = new Point(15, 10),
                Width = 55,
                Height = 15

            };
            funcLabel.Text = "max f(x) =";
            funcPanel.Controls.Add(funcLabel);

            expensesTable.Columns.Add("f", "Запас в условных единицах");
            for (int i = 0; i < countOfRaw.Value; i++)
            {
                expensesTable.Rows.Add("Сырье " + (i + 1));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] matrix = new int[CountOfY, CountOfX + CountOfY];
            double[] bi = new double[CountOfY];
            int[] func = new int[CountOfX];
            double[] prices = new double[CountOfX];
            for (int i = 0; i < CountOfX; i++)
            {
                try
                {
                    func[i] = Int32.Parse(boxesFuncX[i].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка ввода", ex.Message);
                }
                try
                {
                    prices[i] = double.Parse(PricesTextBoxes[i].Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка ввода", ex.Message);
                }

            }
            double[,] xMatrix = new double[CountOfY, CountOfX];
            for (int i = 0; i < CountOfY; i++)
            {

                bi[i] = double.Parse(expensesTable.Rows[i].Cells[CountOfX + 1].Value.ToString());

                for (int j = 0; j < CountOfX + CountOfY; j++)
                {
                    if (CountOfX <= j)
                        if (j - CountOfX == i)
                            matrix[i, j] = 1;
                        else
                            matrix[i, j] = 0;
                    else
                        try
                        {
                            matrix[i, j] = Int32.Parse(expensesTable.Rows[i].Cells[j + 1].Value.ToString());
                            xMatrix[i, j] = Int32.Parse(expensesTable.Rows[i].Cells[j + 1].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка ввода", ex.Message);
                        }
                }
            }
            Result f = new Result(func, matrix, bi, prices, xMatrix);
            f.Show();
        }
    }
}
