namespace DvoistvennayaZadacha
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.countOfProduct = new System.Windows.Forms.NumericUpDown();
            this.countOfRaw = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expensesTable = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.PricesPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.funcPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.countOfProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfRaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // countOfProduct
            // 
            this.countOfProduct.Location = new System.Drawing.Point(253, 12);
            this.countOfProduct.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.countOfProduct.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countOfProduct.Name = "countOfProduct";
            this.countOfProduct.Size = new System.Drawing.Size(67, 20);
            this.countOfProduct.TabIndex = 1;
            this.countOfProduct.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countOfProduct.ValueChanged += new System.EventHandler(this.DrawInputInterface);
            // 
            // countOfRaw
            // 
            this.countOfRaw.Location = new System.Drawing.Point(253, 38);
            this.countOfRaw.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.countOfRaw.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countOfRaw.Name = "countOfRaw";
            this.countOfRaw.Size = new System.Drawing.Size(67, 20);
            this.countOfRaw.TabIndex = 2;
            this.countOfRaw.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.countOfRaw.ValueChanged += new System.EventHandler(this.DrawInputInterface);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во конечных продуктов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кол-во сырья, требуемого для производства";
            // 
            // expensesTable
            // 
            this.expensesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expensesTable.Location = new System.Drawing.Point(348, 38);
            this.expensesTable.Name = "expensesTable";
            this.expensesTable.Size = new System.Drawing.Size(638, 353);
            this.expensesTable.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Матрица затрат на условную единицу произведенного товара";
            // 
            // PricesPanel
            // 
            this.PricesPanel.Location = new System.Drawing.Point(17, 89);
            this.PricesPanel.Name = "PricesPanel";
            this.PricesPanel.Size = new System.Drawing.Size(303, 302);
            this.PricesPanel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Цена розничной продажи конечных продуктов";
            // 
            // funcPanel
            // 
            this.funcPanel.Location = new System.Drawing.Point(19, 418);
            this.funcPanel.Name = "funcPanel";
            this.funcPanel.Size = new System.Drawing.Size(966, 58);
            this.funcPanel.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 638);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.funcPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PricesPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expensesTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countOfRaw);
            this.Controls.Add(this.countOfProduct);
            this.Name = "Form1";
            this.Text = "Решение двойственной задачи";
            ((System.ComponentModel.ISupportInitialize)(this.countOfProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfRaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown countOfProduct;
        private System.Windows.Forms.NumericUpDown countOfRaw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView expensesTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PricesPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel funcPanel;
        private System.Windows.Forms.Button button1;
    }
}

