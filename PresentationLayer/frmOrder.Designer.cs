namespace PresentationLayer
{
    partial class frmOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PizzaUpDown = new System.Windows.Forms.NumericUpDown();
            this.DrinkUpDown = new System.Windows.Forms.NumericUpDown();
            this.BasbousaUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lbltotal_charge = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lblBasbousa = new System.Windows.Forms.Label();
            this.lblDrinkCost = new System.Windows.Forms.Label();
            this.lblPizaaCost = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PizzaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrinkUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasbousaUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Imprint MT Shadow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Large Pizza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Imprint MT Shadow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Drink ";
            // 
            // PizzaUpDown
            // 
            this.PizzaUpDown.Location = new System.Drawing.Point(12, 86);
            this.PizzaUpDown.Name = "PizzaUpDown";
            this.PizzaUpDown.Size = new System.Drawing.Size(100, 26);
            this.PizzaUpDown.TabIndex = 2;
            // 
            // DrinkUpDown
            // 
            this.DrinkUpDown.Location = new System.Drawing.Point(142, 86);
            this.DrinkUpDown.Name = "DrinkUpDown";
            this.DrinkUpDown.Size = new System.Drawing.Size(99, 26);
            this.DrinkUpDown.TabIndex = 3;
            // 
            // BasbousaUpDown
            // 
            this.BasbousaUpDown.Location = new System.Drawing.Point(273, 86);
            this.BasbousaUpDown.Name = "BasbousaUpDown";
            this.BasbousaUpDown.Size = new System.Drawing.Size(120, 26);
            this.BasbousaUpDown.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Imprint MT Shadow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Basbousa ";
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Imprint MT Shadow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(423, 58);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(113, 54);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // lbltotal_charge
            // 
            this.lbltotal_charge.AutoSize = true;
            this.lbltotal_charge.Location = new System.Drawing.Point(289, 279);
            this.lbltotal_charge.Name = "lbltotal_charge";
            this.lbltotal_charge.Size = new System.Drawing.Size(0, 20);
            this.lbltotal_charge.TabIndex = 12;
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(21, 279);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(51, 20);
            this.lblsubtotal.TabIndex = 13;
            this.lblsubtotal.Text = "label4";
            // 
            // lblBasbousa
            // 
            this.lblBasbousa.AutoSize = true;
            this.lblBasbousa.Location = new System.Drawing.Point(21, 220);
            this.lblBasbousa.Name = "lblBasbousa";
            this.lblBasbousa.Size = new System.Drawing.Size(51, 20);
            this.lblBasbousa.TabIndex = 14;
            this.lblBasbousa.Text = "label5";
            // 
            // lblDrinkCost
            // 
            this.lblDrinkCost.AutoSize = true;
            this.lblDrinkCost.Location = new System.Drawing.Point(21, 178);
            this.lblDrinkCost.Name = "lblDrinkCost";
            this.lblDrinkCost.Size = new System.Drawing.Size(51, 20);
            this.lblDrinkCost.TabIndex = 15;
            this.lblDrinkCost.Text = "label6";
            // 
            // lblPizaaCost
            // 
            this.lblPizaaCost.AutoSize = true;
            this.lblPizaaCost.Location = new System.Drawing.Point(21, 135);
            this.lblPizaaCost.Name = "lblPizaaCost";
            this.lblPizaaCost.Size = new System.Drawing.Size(51, 20);
            this.lblPizaaCost.TabIndex = 16;
            this.lblPizaaCost.Text = "label7";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Location = new System.Drawing.Point(244, 150);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(51, 20);
            this.lblTax.TabIndex = 17;
            this.lblTax.Text = "label8";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(244, 197);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(51, 20);
            this.lblTip.TabIndex = 18;
            this.lblTip.Text = "label9";
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 327);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblPizaaCost);
            this.Controls.Add(this.lblDrinkCost);
            this.Controls.Add(this.lblBasbousa);
            this.Controls.Add(this.lblsubtotal);
            this.Controls.Add(this.lbltotal_charge);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BasbousaUpDown);
            this.Controls.Add(this.DrinkUpDown);
            this.Controls.Add(this.PizzaUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PizzaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrinkUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasbousaUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PizzaUpDown;
        private System.Windows.Forms.NumericUpDown DrinkUpDown;
        private System.Windows.Forms.NumericUpDown BasbousaUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label lbltotal_charge;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label lblBasbousa;
        private System.Windows.Forms.Label lblDrinkCost;
        private System.Windows.Forms.Label lblPizaaCost;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTip;
    }
}