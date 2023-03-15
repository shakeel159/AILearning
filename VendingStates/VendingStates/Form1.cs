using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VendingStates
{
    //BUGS:
    //Vending mechine can go negative in currancy storage

    public partial class Form1 : Form
    {
        public enum VendingState { WaitingforPayment, WaitingForSelection, Vending }

        protected VendingState state;

        private VendingState State { get { return state; } }

        Products product;

        List<string> ToDispense = new List<string>();
        string[] Dispended;

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
            InitializeComponent();
            state = VendingState.WaitingforPayment; // initial state
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
                    FSMTxt.Text += "WPP + ";
                    break;
                case VendingState.WaitingForSelection:
                    FSMTxt.Text += "WFS + ";
                    break;
                case VendingState.Vending:  
                    FSMTxt.Text += "vending + ";
                    break;
            }
        }
        private void Payment()
        {
            moneyInWallet -= quarter;
            bank += quarter;
            BankTxt.Text = "$" + bank.ToString();
            wallet.Text = "$" + moneyInWallet.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
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
            //state = VendingState.WaitingForSelection;
            Selection();
            UpdateVedningState(); 
        }

        private void GronolaPurchaseBtn_Click(object sender, EventArgs e)
        {
            product = Products.GetInstance;
            product.name = GronolaName;
            bank -= gronolaCost;
            ToDispense.Add(product.name.ToString());
            //state = VendingState.WaitingForSelection;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            //SELECT BUTTON
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
            if(ToDispense.Count == 0)
            {
                resetpayment();
            }
            foreach (var item in ToDispense)
            {
                if(item.ToString() == gumName)
                {
                    bank += gumCost;
                }
                if (item.ToString() == GronolaName)
                {
                    bank += gronolaCost;
                }
                change = bank;
                moneyInWallet += change;
                ToDispense.Remove(item);
                wallet.Text = "$" + moneyInWallet.ToString();
                ClearBanktext();
                FSMTxt.Text.Clone();    
                Form1 form = new Form1();
                return;
            }
        }

        //Singleton Class
        public class Products
        {
            public string name;
            private static Products instance = new Products();
            private Products() { }

            public static Products GetInstance
            {
                get { return instance; }
            }
        }


    }
}
