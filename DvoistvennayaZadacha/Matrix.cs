using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvoistvennayaZadacha
{
    public class Matrix<T> where T : new()
    {
        private readonly List<List<T>> matrix;

        ///*<summary>
        ///*Cоздание*матрицы.
        ///*</summary>
        ///*<param*name="rowsCount">Количество*строк.</param>
        ///*<param*name="columnCount">Количество*столбцов.</param>
        public Matrix(int rowsCount = 2, int columnCount = 2)
        {
            ColumnCount = columnCount;
            RowsCount = rowsCount;
            matrix = new List<List<T>>(rowsCount);
            for (int i = 0; i < rowsCount; i++)
            {
                var list = new List<T>(columnCount);
                for (int j = 0; j < columnCount; j++)
                {
                    list.Add(default(T));
                }
                matrix.Add(list);
            }
        }

        ///*<summary>
        ///*Cоздание*матрицы.
        ///*</summary>
        ///*<param*name="data">Исходный*двумерный*массив.</param>
        public Matrix(T[,] data)
        {
            RowsCount = data.GetLength(0);
            ColumnCount = data.GetLength(1);
            matrix = new List<List<T>>(RowsCount);
            for (int i = 0; i < RowsCount; i++)
            {
                var list = new List<T>(ColumnCount);
                for (int j = 0; j < ColumnCount; j++)
                {
                    list.Add(data[i, j]);
                }
                matrix.Add(list);
            }
        }

        ///*<summary>
        ///*Элемент*матрицы.
        ///*</summary>
        ///*<param*name="i">Индекс*строки.</param>
        ///*<param*name="j">Индекс*столбца.</param>
        ///*<returns></returns>
        public T this[int i, int j]
        {
            get { return matrix[i][j]; }
            set { matrix[i][j] = value; }
        }

        ///*<summary>
        ///*Количество*строк.
        ///*</summary>
        public int RowsCount { get; private set; }

        ///*<summary>
        ///*Количество*столбцов.
        ///*</summary>
        public int ColumnCount { get; private set; }

        ///*<summary>
        ///*Добавить*строку.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*строки.</param>
        public void AddRow(int index)
        {
            RowsCount++;
            var list = new List<T>(ColumnCount);
            for (int j = 0; j < ColumnCount; j++)
            {
                list.Add(default(T));
            }
            matrix.Insert(index, list);
        }

        ///*<summary>
        ///*Добавить*столбец.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*столбца.</param>
        public void AddColumn(int index)
        {
            ColumnCount++;
            foreach (var list in matrix)
            {
                list.Insert(index, default(T));
            }
        }

        ///*<summary>
        ///*Удалить*строку.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*строки.</param>
        public void RemoveRow(int index)
        {
            RowsCount--;
            matrix.RemoveAt(index);
        }

        ///*<summary>
        /// Удалить столбец.
        ///*</summary>
        ///*<param*name="index">Индекс*вставки*столбца.</param>
        public void RemoveColumn(int index)
        {
            ColumnCount--;
            foreach (var list in matrix)
            {
                list.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    stringBuilder.Append(matrix[i][j]);
                    stringBuilder.Append("*");
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
