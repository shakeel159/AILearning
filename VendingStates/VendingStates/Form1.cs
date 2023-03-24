using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VendingStates
{

    public partial class Form1 : Form
    {
        public enum VendingState { WaitingforPayment, WaitingForSelection, Vending }

        protected VendingState state;

        private VendingState State { get { return state; } }

        Products product;

        List<string> ToDispense = new List<string>();

        string gumName = "Gum";
        string GronolaName = "Gronola";
        float gumCost = 0.50f;
        float gronolaCost = 0.75f;

        float bank;
        float quarter;
        float change;
        float moneyInWallet;

        bool giveChange = false;
        public Form1()
        {
            product = new Products();
            InitializeComponent();
            SelectionBx.Text = "Vending Mechine Selection + ";
            FSMTxt.Text += state.ToString();
            gunPrice.Text = gumCost.ToString(); 
            gronolaProce.Text = gronolaCost.ToString();
            resetpayment();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void resetpayment()
        {
            bank = 00.00f;
            quarter = 00.25f;
            moneyInWallet = 5.00f;
            state = VendingState.WaitingforPayment; // initial state
            BankTxt.Text = "$" + bank.ToString();
            wallet.Text = "$" + moneyInWallet.ToString();
            WalletTxt.Text = "Your Money: ";
            VendsMoneyTxt.Text = "Money put in: ";
            OutPuttxt.Text = "OutPut: ";

        }
        private void UpdateVedningState()
        {
            switch (state)
            {
                case VendingState.WaitingforPayment:
                    Payment();
                    FSMTxt.AppendText("WPP + ");
                    break;
                case VendingState.WaitingForSelection:
                    FSMTxt.AppendText("WFS + ");
                    break;
                case VendingState.Vending:
                    FSMTxt.AppendText("vending + ");
                    break;
            }
        }
        private void Payment()
        {
            if (moneyInWallet <= .25f)
            {
                BankTxt.Text = "$" + bank.ToString();
                wallet.Text = "$" + moneyInWallet.ToString();
            }      
            else
            {
                moneyInWallet -= quarter;
                bank += quarter;
                BankTxt.Text = "$" + bank.ToString();
                wallet.Text = "$" + moneyInWallet.ToString();
            }
            
        }
        private void button1_Click(object sender, EventArgs e) // add money to bank button
        {
            UpdateVedningState();
        }
        private void Selection()
        {
            wallet.Text = "$" + moneyInWallet.ToString();
            BankTxt.Text = "$" + bank.ToString();
            state = VendingState.WaitingForSelection;
        }
        private void GumPurchaseBtn_Click(object sender, EventArgs e)
        {
            product = Products.GetInstance;
            product.name = gumName;
            bank -= gumCost;
            ToDispense.Add(product.name.ToString());
            Selection();
            UpdateVedningState(); 
        }

        private void GronolaPurchaseBtn_Click(object sender, EventArgs e)
        {
            product = Products.GetInstance;
            product.name = GronolaName;
            bank -= gronolaCost;
            ToDispense.Add(product.name.ToString());
            Selection();
            UpdateVedningState();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void ClearBanktext()
        {
            VendsMoneyTxt.Text = "Money put in: ";
            bank = 00.00f;
            BankTxt.Text = "$" + bank.ToString();
        }
        private void Transaction()
        {
            ClearBanktext();
            foreach (var item in ToDispense)
            {
                string[] Dispensed = ToDispense.ToArray();
                DisTxt.Text += "\n" + item.ToString();
            }

        }

        private void button1_Click_1(object sender, EventArgs e) //SELECT BUTTON
        {
            CheckState();
            Transaction();
        }
        private void CheckState()
        {
            if (state == VendingState.WaitingforPayment)
            {
                state = VendingState.WaitingForSelection;
                UpdateVedningState();
                return;
            }
            if (state == VendingState.WaitingForSelection)
            {
                state = VendingState.WaitingforPayment;
                UpdateVedningState();
                return;
            }
            if (state == VendingState.Vending)
            {
                state = VendingState.WaitingforPayment;
                UpdateVedningState();
                return;
            }
        }
        private void CLBtn_Click(object sender, EventArgs e)
        {
            if (ToDispense.Count == 0)
            {
                resetpayment();
            }
            else
            {
                foreach (var item in ToDispense)
                {
                    if (item.ToString() == gumName)
                    {
                        bank += gumCost;
                    }
                    if (item.ToString() == GronolaName)
                    {
                        bank += gronolaCost;
                    }
                    ToDispense.Remove(item);
                    resetpayment();
                    return;
                }

            }
        }

        private void FSMTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
