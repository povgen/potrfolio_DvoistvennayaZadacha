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
    public partial class Result : Form
    {
        double[] ansewrX;
        double[,] matrix;
        double[] ValOfX;
        public Result(int[] Func, int[,] matr, double[] bi, double[] prices, double[,] xMatrix)
        {
            InitializeComponent();
            ansewrX = new double[Func.Length];
            ValOfX = new double[bi.Length];
            Array.Copy(bi, ValOfX, bi.Length);
            matrix = new double[matr.GetLength(0), matr.GetLength(1)];
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    matrix[i, j] = (double)matr[i, j];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (i < Func.Length)
                    dataGridView1.Columns.Add("X" + (i + 1), "X" + (i + 1) + " (" + Func[i] + ")");
                else
                    dataGridView1.Columns.Add("X" + (i + 1), "X" + (i + 1) + " (0)");
            }
            dataGridView1.Columns.Add("tet", "θi");

            List<int> iUnitMatrix = new List<int>();
            List<int> jUnitMatrix = new List<int>();

            bool IsQurUnit = true; // переменная отвечает за проверку: содержит ли текущий столбец только одну 1
            //для получения единичной подматрицы
            int m = matrix.GetLength(1);
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        for (int ii = 0; ii < matrix.GetLength(0); ii++)
                            if (matrix[ii, j] != 0 && ii != i)
                                IsQurUnit = false;

                        if (IsQurUnit)
                        {
                            iUnitMatrix.Add(i);
                            jUnitMatrix.Add(j);
                            continue;
                        } else
                            IsQurUnit = true;

                    }
                }
            }

            List<int> arrayCoefOfX = Func.ToList<int>(); // массив коэфицентов x фунцкии
            for (int i = 0; i < matrix.GetLength(1) - Func.Length; i++)
                arrayCoefOfX.Add(0);


            int tableNum = 0;
            int qurrentRow = 0;
            int[] basis = new int[matrix.GetLength(0)];
            for (int i = 0; i < basis.Length; i ++) 
                basis[i] = jUnitMatrix[i]; // задаем базисы, взятые по единичной матрице

            while (true)
            {
                int shiftI = qurrentRow; // задает ввертикальный сдвиг для корректной подстановки данных в dataGridView1
                int shiftJ = 4;         // задает горизонталный сдвиг для корректной подстановки данных в dataGridView1

                for (int i = 0; i < matrix.GetLength(0); i++) 
                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i + shiftI].Cells[0].Value = tableNum;
                    dataGridView1.Rows[i + shiftI].Cells[1].Value = arrayCoefOfX[basis[i]];
                    dataGridView1.Rows[i + shiftI].Cells[2].Value = "X" + (basis[i] + 1);
                    dataGridView1.Rows[i + shiftI].Cells[3].Value = bi[i];

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i + shiftI].Cells[j + shiftJ].Value = matrix[i, j];
                    }

                    qurrentRow++;
                }
                dataGridView1.Rows.Add();


                double bSum = 0;

                    for (int i = 0; i < matrix.GetLength(0); i++) // подсчет Bi
                    {
                        bSum += arrayCoefOfX[basis[i]] * // Ci/Cj текущей строки
                            bi[i];      // Bi текущей строки

                    }
               

                dataGridView1.Rows[qurrentRow].Cells[3].Value = bSum;

                int deltaJMaxJ = 0;
                double deltaJMax = 0;

                double[] deltaJ = new double[matrix.GetLength(1)];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    double summ = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++) //подсчет суммы (Ci/j*Xij) 
                    {
                        summ += matrix[i, j] * arrayCoefOfX[basis[i]];
                        //= 
                    }
                    dataGridView1.Rows[qurrentRow].Cells[4 + j].Value = (double)arrayCoefOfX[j] - summ; //подсчет дельта j
                    deltaJ[j] = (double)arrayCoefOfX[j] - summ;
                    if (deltaJMax < arrayCoefOfX[j] - summ)
                    {
                        deltaJMax = arrayCoefOfX[j] - summ;
                        deltaJMaxJ = j;
                    }
                }
                qurrentRow++;

                bool end = true;

                foreach (double delt in deltaJ) // проверка все ли дельта j <= 0
                    if (delt > 0)
                        end = false;

                if (end) // заканчиваем алгоритм
                {
                    for (int i = 0; i < basis.Length; i++)
                        for (int j = 0; j < Func.Length; j++)
                            if (basis[i] == j)
                                ansewrX[basis[i]] = bi[i];
                    break;
                }



                double minTet = Int32.MaxValue;
                int minTetI = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    if (bi[i] / matrix[i, deltaJMaxJ] > 0)
                    {
                        double tet = bi[i] / matrix[i, deltaJMaxJ];
                        dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i-1].Cells[matrix.GetLength(1) + 4].Value = tet;
                        // х = кол-во х + кол-во столбцов перед Х ами т.е. 4
                        if (tet < minTet)
                        {
                            minTet = tet;
                            minTetI = i;
                        }
                    }
                    else
                        dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i-1].Cells[matrix.GetLength(1) + 4].Value = "---";

                basis[minTetI] = deltaJMaxJ;
                bi[minTetI] = bi[minTetI] / matrix[minTetI, deltaJMaxJ];


                for (int i = 0; i < matrix.GetLength(0); i++) // подсчет Bi
                    if (i != minTetI)
                        bi[i] = bi[i] - bi[minTetI] * matrix[i, deltaJMaxJ];



                double mainEl = matrix[minTetI, deltaJMaxJ];
                for (int j = 0; j < matrix.GetLength(1); j++) //делем главную строку на X главной строки и главного столбца
                {
                    matrix[minTetI, j] = matrix[minTetI, j] / mainEl;
                }

                for (int i = 0; i < basis.Length; i++) // считаем оставшиеся строки матрицы
                {
                    if (i != minTetI)
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            double asd = double.Parse(dataGridView1.Rows[qurrentRow - matrix.GetLength(0) + i - 1].Cells[4 + deltaJMaxJ].Value.ToString());
                            matrix[i, j] = matrix[i, j] - matrix[minTetI, j] * asd;
                        }
                }

                tableNum++;

            }

            // расчет задачи

            //ansewrX

            double[,] yMatr = new double[xMatrix.GetLength(1), xMatrix.GetLength(0)];

            for (int i = 0; i < xMatrix.GetLength(0); i++)
                for (int j = 0; j < xMatrix.GetLength(1); j++)
                    yMatr[j, i] = xMatrix[i, j];

            List<int> indexOfYLessValOfX = new List<int>(); // список индексов У'ов равных нулю
            for (int i = 0; i < xMatrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < xMatrix.GetLength(1); j++)
                {
                    sum += xMatrix[i, j] * ansewrX[j];
                }
                if (sum < ValOfX[i])
                {
                    indexOfYLessValOfX.Add(i);
                }
            }

            Matrix<double> matrixForSolv = new Matrix<double>(yMatr);
            foreach (var index in indexOfYLessValOfX)
                matrixForSolv.RemoveColumn(index);


            GausMethod solution = new GausMethod((byte)matrixForSolv.RowsCount, (byte)matrixForSolv.ColumnCount);

            for (int i = 0; i < matrixForSolv.RowsCount; i++)
                for (int j = 0; j < matrixForSolv.ColumnCount; j++)
                    solution.Matrix[i][j] = matrixForSolv[i, j];

            for (int i = 0; i < prices.Length; i++)
                solution.RightPart[i] = prices[i];

            solution.SolveMatrix();


            int shift = 0;
            double summRs = 0;

            for(int i = 0; i < solution.Answer.Length + indexOfYLessValOfX.Count; i++)
            {
                bool cont = false;
                foreach (int ind in indexOfYLessValOfX)
                    if (ind == i)
                    {
                        panel1.Controls.Add(new Label()
                        {
                            Text = "Сырье № " + (i + 1) + " = 0" + " у.е.",
                            Height = 15,
                            Width = 250,
                            Location = new Point(15, 15 + 25 * i)
                        });
                        shift++;
                        cont = true;
                    }

                if (cont)
                    continue;

                panel1.Controls.Add(new Label()
                {
                    Text = "Сырье № " + (i + 1) + " = " + solution.Answer[i - shift] + " у.е.",
                    Height = 15,
                    Width = 250,
                    Location = new Point(15, 15 + 25 * i)
                });
                summRs += solution.Answer[i - shift] * ValOfX[i - shift];

            }
            panel1.Controls.Add(new Label()
            {
                Text = "максимальные затраты на производство составт " + summRs + " у.е.",
                Height = 15,
                Width = 500,
                Location = new Point(15, 15 + 25 * (solution.Answer.Length + indexOfYLessValOfX.Count))
            });
        }   

        //private double[] SolvingSystemOfEquations(Matrix<double> matrix, double[] koficent)
        //{
        //    int str = matrix.RowsCount;                 
        //    int stl = matrix.ColumnCount;

        //    double[] korni = new double[str];

        //    /*сами вычисления по гауссу*/
        //    double s;

        //    for (int k = 0; k < str - 1; k++)
        //    {
        //        for (int i = k + 1; i < str; i++)
        //        {
        //            for (int j = k + 1; j < stl; j++)
        //            {
        //                matrix[i, j] = matrix[i, j] - matrix[k, j] * (matrix[i, k] / matrix[k, k]);
        //            }
        //            koficent[i] = koficent[i] - koficent[k] * matrix[i, k] / matrix[k, k];
        //        }
        //    }
        //    for (int k = str - 1; k >= 0; k--)
        //    {
        //        s = 0;
        //        for (int j = k + 1; j < str; j++)
        //            s = s + matrix[k, j] * korni[j];
        //        korni[k] = (koficent[k] - s) / matrix[k, k];
        //    }

        //    return korni;


        //}
    }
}
