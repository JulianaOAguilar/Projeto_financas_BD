namespace PRojeto_funancas_BD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            data = new DateTimePicker();
            debitBtn = new Button();
            creditBtn = new Button();
            descriptionInput = new TextBox();
            label3 = new Label();
            label2 = new Label();
            valor = new Label();
            inputValue = new TextBox();
            label1 = new Label();
            inputName = new TextBox();
            groupBox2 = new GroupBox();
            balanceLabel = new Label();
            label4 = new Label();
            consultBtn = new Button();
            filterBtn = new Button();
            filterInput = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(data);
            groupBox1.Controls.Add(debitBtn);
            groupBox1.Controls.Add(creditBtn);
            groupBox1.Controls.Add(descriptionInput);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(valor);
            groupBox1.Controls.Add(inputValue);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(inputName);
            groupBox1.Location = new Point(69, 44);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(247, 280);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "formulário";
            // 
            // data
            // 
            data.Location = new Point(95, 114);
            data.MinDate = new DateTime(2025, 11, 5, 0, 0, 0, 0);
            data.Name = "data";
            data.Size = new Size(114, 23);
            data.TabIndex = 2;
            data.Value = new DateTime(2025, 11, 28, 0, 0, 0, 0);
            // 
            // debitBtn
            // 
            debitBtn.Location = new Point(152, 247);
            debitBtn.Name = "debitBtn";
            debitBtn.Size = new Size(75, 23);
            debitBtn.TabIndex = 9;
            debitBtn.Text = "débito (-)";
            debitBtn.UseVisualStyleBackColor = true;
            debitBtn.Click += debitBtn_Click;
            // 
            // creditBtn
            // 
            creditBtn.Location = new Point(77, 247);
            creditBtn.Name = "creditBtn";
            creditBtn.Size = new Size(75, 23);
            creditBtn.TabIndex = 8;
            creditBtn.Text = "crédito (+)";
            creditBtn.UseVisualStyleBackColor = true;
            creditBtn.Click += creditBtn_Click;
            // 
            // descriptionInput
            // 
            descriptionInput.Location = new Point(77, 153);
            descriptionInput.Multiline = true;
            descriptionInput.Name = "descriptionInput";
            descriptionInput.Size = new Size(150, 84);
            descriptionInput.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 153);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Descrição";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 114);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "Data";
            // 
            // valor
            // 
            valor.AutoSize = true;
            valor.Location = new Point(38, 74);
            valor.Name = "valor";
            valor.Size = new Size(33, 15);
            valor.TabIndex = 3;
            valor.Text = "Valor";
            // 
            // inputValue
            // 
            inputValue.Location = new Point(77, 66);
            inputValue.Name = "inputValue";
            inputValue.Size = new Size(150, 23);
            inputValue.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 27);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // inputName
            // 
            inputName.Location = new Point(77, 22);
            inputName.Name = "inputName";
            inputName.Size = new Size(150, 23);
            inputName.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(balanceLabel);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(consultBtn);
            groupBox2.Controls.Add(filterBtn);
            groupBox2.Controls.Add(filterInput);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(348, 44);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(353, 280);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "consulta";
            // 
            // balanceLabel
            // 
            balanceLabel.AutoSize = true;
            balanceLabel.Location = new Point(98, 251);
            balanceLabel.Name = "balanceLabel";
            balanceLabel.Size = new Size(0, 15);
            balanceLabel.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 251);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 10;
            label4.Text = "Saldo Atual:";
            // 
            // consultBtn
            // 
            consultBtn.Location = new Point(22, 36);
            consultBtn.Name = "consultBtn";
            consultBtn.Size = new Size(141, 23);
            consultBtn.TabIndex = 13;
            consultBtn.Text = "Consultar transações";
            consultBtn.UseVisualStyleBackColor = true;
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(169, 36);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(51, 23);
            filterBtn.TabIndex = 10;
            filterBtn.Text = "filtrar";
            filterBtn.UseVisualStyleBackColor = true;
            // 
            // filterInput
            // 
            filterInput.Location = new Point(226, 37);
            filterInput.Name = "filterInput";
            filterInput.Size = new Size(100, 23);
            filterInput.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(304, 171);
            dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 635);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabela;
        private GroupBox groupBox1;
        private Label label2;
        private Label valor;
        private TextBox inputValue;
        private Label label1;
        private TextBox inputName;
        private Button debitBtn;
        private Button creditBtn;
        private TextBox descriptionInput;
        private Label label3;
        private GroupBox groupBox2;
        private Button filterBtn;
        private TextBox filterInput;
        private DataGridView dataGridView1;
        private Button consultBtn;
        private Label balanceLabel;
        private Label label4;
        private DateTimePicker data;
    }
}
