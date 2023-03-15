namespace VendingStates
{
    partial class Form1
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
            this.FSMTxt = new System.Windows.Forms.TextBox();
            this.PayBtn = new System.Windows.Forms.Button();
            this.CLBtn = new System.Windows.Forms.Button();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.GumPurchaseBtn = new System.Windows.Forms.Button();
            this.GronolaPurchaseBtn = new System.Windows.Forms.Button();
            this.wallet = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BankTxt = new System.Windows.Forms.TextBox();
            this.DisTxt = new System.Windows.Forms.RichTextBox();
            this.WalletTxt = new System.Windows.Forms.TextBox();
            this.VendsMoneyTxt = new System.Windows.Forms.TextBox();
            this.OutPuttxt = new System.Windows.Forms.TextBox();
            this.SelectionBx = new System.Windows.Forms.TextBox();
            this.gronolaProce = new System.Windows.Forms.TextBox();
            this.gunPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FSMTxt
            // 
            this.FSMTxt.Location = new System.Drawing.Point(86, 404);
            this.FSMTxt.Name = "FSMTxt";
            this.FSMTxt.Size = new System.Drawing.Size(635, 20);
            this.FSMTxt.TabIndex = 0;
            // 
            // PayBtn
            // 
            this.PayBtn.Location = new System.Drawing.Point(646, 360);
            this.PayBtn.Name = "PayBtn";
            this.PayBtn.Size = new System.Drawing.Size(75, 23);
            this.PayBtn.TabIndex = 1;
            this.PayBtn.Text = "+$00.25";
            this.PayBtn.UseVisualStyleBackColor = true;
            this.PayBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // CLBtn
            // 
            this.CLBtn.Location = new System.Drawing.Point(645, 327);
            this.CLBtn.Name = "CLBtn";
            this.CLBtn.Size = new System.Drawing.Size(75, 23);
            this.CLBtn.TabIndex = 2;
            this.CLBtn.Text = "Cancel";
            this.CLBtn.UseVisualStyleBackColor = true;
            this.CLBtn.Click += new System.EventHandler(this.CLBtn_Click);
            // 
            // SelectBtn
            // 
            this.SelectBtn.Location = new System.Drawing.Point(646, 298);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.Text = "Select";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GumPurchaseBtn
            // 
            this.GumPurchaseBtn.Location = new System.Drawing.Point(215, 151);
            this.GumPurchaseBtn.Name = "GumPurchaseBtn";
            this.GumPurchaseBtn.Size = new System.Drawing.Size(103, 108);
            this.GumPurchaseBtn.TabIndex = 5;
            this.GumPurchaseBtn.Text = "Gum";
            this.GumPurchaseBtn.UseVisualStyleBackColor = true;
            this.GumPurchaseBtn.Click += new System.EventHandler(this.GumPurchaseBtn_Click);
            // 
            // GronolaPurchaseBtn
            // 
            this.GronolaPurchaseBtn.Location = new System.Drawing.Point(371, 151);
            this.GronolaPurchaseBtn.Name = "GronolaPurchaseBtn";
            this.GronolaPurchaseBtn.Size = new System.Drawing.Size(111, 108);
            this.GronolaPurchaseBtn.TabIndex = 6;
            this.GronolaPurchaseBtn.Text = "Gronola";
            this.GronolaPurchaseBtn.UseVisualStyleBackColor = true;
            this.GronolaPurchaseBtn.Click += new System.EventHandler(this.GronolaPurchaseBtn_Click);
            // 
            // wallet
            // 
            this.wallet.Location = new System.Drawing.Point(645, 42);
            this.wallet.Name = "wallet";
            this.wallet.Size = new System.Drawing.Size(73, 20);
            this.wallet.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // BankTxt
            // 
            this.BankTxt.Location = new System.Drawing.Point(617, 80);
            this.BankTxt.Name = "BankTxt";
            this.BankTxt.Size = new System.Drawing.Size(100, 20);
            this.BankTxt.TabIndex = 8;
            // 
            // DisTxt
            // 
            this.DisTxt.Location = new System.Drawing.Point(27, 298);
            this.DisTxt.Name = "DisTxt";
            this.DisTxt.Size = new System.Drawing.Size(100, 96);
            this.DisTxt.TabIndex = 9;
            this.DisTxt.Text = "";
            // 
            // WalletTxt
            // 
            this.WalletTxt.Location = new System.Drawing.Point(533, 42);
            this.WalletTxt.Name = "WalletTxt";
            this.WalletTxt.Size = new System.Drawing.Size(106, 20);
            this.WalletTxt.TabIndex = 10;
            // 
            // VendsMoneyTxt
            // 
            this.VendsMoneyTxt.Location = new System.Drawing.Point(533, 80);
            this.VendsMoneyTxt.Name = "VendsMoneyTxt";
            this.VendsMoneyTxt.Size = new System.Drawing.Size(87, 20);
            this.VendsMoneyTxt.TabIndex = 11;
            // 
            // OutPuttxt
            // 
            this.OutPuttxt.Location = new System.Drawing.Point(27, 272);
            this.OutPuttxt.Name = "OutPuttxt";
            this.OutPuttxt.Size = new System.Drawing.Size(100, 20);
            this.OutPuttxt.TabIndex = 12;
            // 
            // SelectionBx
            // 
            this.SelectionBx.Location = new System.Drawing.Point(215, 125);
            this.SelectionBx.Name = "SelectionBx";
            this.SelectionBx.Size = new System.Drawing.Size(267, 20);
            this.SelectionBx.TabIndex = 13;
            // 
            // gronolaProce
            // 
            this.gronolaProce.Location = new System.Drawing.Point(371, 265);
            this.gronolaProce.Name = "gronolaProce";
            this.gronolaProce.Size = new System.Drawing.Size(100, 20);
            this.gronolaProce.TabIndex = 14;
            // 
            // gunPrice
            // 
            this.gunPrice.Location = new System.Drawing.Point(215, 265);
            this.gunPrice.Name = "gunPrice";
            this.gunPrice.Size = new System.Drawing.Size(100, 20);
            this.gunPrice.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunPrice);
            this.Controls.Add(this.gronolaProce);
            this.Controls.Add(this.SelectionBx);
            this.Controls.Add(this.OutPuttxt);
            this.Controls.Add(this.VendsMoneyTxt);
            this.Controls.Add(this.WalletTxt);
            this.Controls.Add(this.DisTxt);
            this.Controls.Add(this.BankTxt);
            this.Controls.Add(this.wallet);
            this.Controls.Add(this.GronolaPurchaseBtn);
            this.Controls.Add(this.GumPurchaseBtn);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.CLBtn);
            this.Controls.Add(this.PayBtn);
            this.Controls.Add(this.FSMTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FSMTxt;
        private System.Windows.Forms.Button PayBtn;
        private System.Windows.Forms.Button CLBtn;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button GumPurchaseBtn;
        private System.Windows.Forms.Button GronolaPurchaseBtn;
        private System.Windows.Forms.TextBox wallet;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox BankTxt;
        private System.Windows.Forms.RichTextBox DisTxt;
        private System.Windows.Forms.TextBox WalletTxt;
        private System.Windows.Forms.TextBox VendsMoneyTxt;
        private System.Windows.Forms.TextBox OutPuttxt;
        private System.Windows.Forms.TextBox SelectionBx;
        private System.Windows.Forms.TextBox gronolaProce;
        private System.Windows.Forms.TextBox gunPrice;
    }
}

