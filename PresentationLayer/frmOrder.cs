using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmOrder : Form
    {
        const decimal PIZZA = 15;
        const int DRINK = 2;
        
        const int BASBOUSA = 20;
        public frmOrder(int userId)
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (PizzaUpDown.Text == "")
            {
                MessageBox.Show("Enter a number of Pizza");
                PizzaUpDown.Text = "1.00";
                return;
            }
            if (DrinkUpDown.Text == "")
            {
                MessageBox.Show("Enter a number of Drink");
                DrinkUpDown.Text = "1.00";
                return;
            }
            if (BasbousaUpDown.Text == "")
            {
                MessageBox.Show("Enter a number of Bassbousa");
                BasbousaUpDown.Text = "1.00";
                return;
            }


            billCalculator(PizzaUpDown.Value, DrinkUpDown.Value,BasbousaUpDown.Value);
         




        }
        public decimal billCalculator(decimal Pizzanum, decimal DrinkUpnum, decimal Basbousanum)
        {
            decimal total_charge;
            decimal pizaaCost = 0;
            decimal drinkCost = 0;
            decimal basbousaCost = 0;
            decimal subtotal = 0;
            decimal taxCharged = 0;
            pizaaCost = Pizzanum * PIZZA;
            drinkCost = DrinkUpnum * DRINK;
            basbousaCost = Basbousanum * BASBOUSA;
            subtotal = pizaaCost + drinkCost + basbousaCost;
            taxCharged = subtotal * (decimal)0.0473;
            decimal tax = Math.Round(taxCharged, 2);
            decimal tip_amount = subtotal * (decimal)0.15;
            decimal tip = Math.Round(tip_amount, 2);
            total_charge = Math.Round(subtotal + tax + tip, 2);
            lblPizaaCost.Text = $"{Pizzanum} Pizaa * ${PIZZA} = ${pizaaCost}";
            lblDrinkCost.Text = $"{DrinkUpnum}  Drink *  ${DRINK}  = ${drinkCost}";
            lblBasbousa.Text = $"{Basbousanum}  Basbousa *  ${BASBOUSA}  = ${basbousaCost}";
            lblsubtotal.Text = $"Subtotal {pizaaCost} + {drinkCost} + {basbousaCost} = ${subtotal}";
            lblTax.Text = $"Tax    %4 =  ${tax}";
            lblTip.Text = $"Tip %1.15 =  ${tip}";

            lbltotal_charge.Text = $"Total Charged: ${total_charge}";
            return total_charge;

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
