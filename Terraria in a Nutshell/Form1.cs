using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Terraria_in_a_Nutshell
{
    public partial class Form1 : Form
    {
        double rocketBootNumb = 0f;
        double tinkerTableNumb = 0f;
        double spikeBallNumb = 0f;
        double rocketBootPrice = 5f;
        double tinkerTablePrice = 10f;
        double spikeBallPrice = 80f;
        double platnum = 0;
        double gold = 0f;
        double silver = 0f;
        double copper = 0f;
        double happinessTax = 0.10f;

        double totalCopperCoins = 0f;
        double totalCopperCoinsTaxedAmount = 0f;

        double coinSorterInputPlatnum = 0f;
        double coinSorterInputGold = 0f;
        double coinSorterInputSilver = 0f;
        double coinSorterInputCopper = 0f;

        double totalCoperCoinsAfterTax = 0f;
        double totalCopperCoinsTendered = 0f;
        double change = 0f;

        bool preTaxCalculate = false;
        bool taxCalculate = false;
        bool afterTax = false;

        double rocketBootTotalPreTaxPriceCopper = 0f;
        double rocketBootTotalPreTaxPriceSilver = 0f;
        double rocketBootTotalPreTaxPriceGold = 0f;
        double rocketBootTotalPreTaxPricePlatinum = 0f;

        double tinkerTablePreTaxPriceCopper = 0f;
        double tinkerTableTotalPreTaxPriceSilver = 0f;
        double tinkerTableTotalPreTaxPriceGold = 0f;
        double tinkerTableTotalPreTaxPricePlatinum = 0f;

        double spikeBallPreTaxPriceCopper = 0f;
        double spikeBalleTotalPreTaxPriceSilver = 0f;
        double spikeBallTotalPreTaxPriceGold = 0f;
        double spikeBallTotalPreTaxPricePlatinum = 0f;

        bool notEnoughCoins = false;

        bool calculateLocked = false;
        bool buyLocked = true;

        bool calculateTrue = false;
        public Form1()
        {
            InitializeComponent();

            platniumCoinTotal.Parent = platCoin1;
            platniumCoinTotal.Location = new Point(5, 30);
            goldCoinTotal.Parent = goldCoin3;
            goldCoinTotal.Location = new Point(5, 30);
            silverCoinTotal.Parent = silverCoin1;
            silverCoinTotal.Location = new Point(5, 30);
            copperCoinTotal.Parent = copperCoin2;
            copperCoinTotal.Location = new Point(5, 30);
            platnumCoinTaxTotal.Parent = platnumCoin2;
            platnumCoinTaxTotal.Location = new Point(5, 30);
            goldCoinTaxTotal.Parent = goldCoin4;
            goldCoinTaxTotal.Location = new Point(5, 30);
            silverCoinTaxTotal.Parent = silverCoin2;
            silverCoinTaxTotal.Location = new Point(5, 30);
            copperCoinTaxTotal.Parent = copperCoin3;
            copperCoinTaxTotal.Location = new Point(5, 30);
            afterTaxPlatinumCoinTotal.Parent = platinumCoin3;
            afterTaxPlatinumCoinTotal.Location = new Point(5, 30);
            afterTaxGoldCoinTotal.Parent = goldCoin5;
            afterTaxGoldCoinTotal.Location = new Point(5, 30);
            afterTaxSilverCoinTotal.Parent = silverCoin3;
            afterTaxSilverCoinTotal.Location = new Point(5, 30);
            afterTaxCopperCoinTotal.Parent = copperCoin4;
            afterTaxCopperCoinTotal.Location = new Point(5, 30);
            receiptLetterOutput.Visible = false;
            receiptPriceOutput.Visible = false;


        }

 

 

        private void buyButton_Click(object sender, EventArgs e)
        {
            SoundPlayer printer = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844);
            if (buyLocked == true)
            {
                buyButton.BackColor = Color.Gray;
            }
            if (buyLocked == false)
            { 
                notEnoughCoins = false;
            
                totalCopperCoinsTendered = Convert.ToDouble(copperTendered.Value + (silverTendered.Value * 100) + (goldTendered.Value * 10000) + (platinumTendered.Value * 1000000));
                if ((copper + (silver * 100) + (gold * 10000) + (platnum * 1000000)) > totalCopperCoinsTendered)
                {
                    buyButton.Text = "Not Enough Coins";
                    Refresh();
                    Thread.Sleep(100);
                    buyButton.Text = "Buy";
                    Refresh();
                    notEnoughCoins = true;
                }

                if (notEnoughCoins == false)
                {

                    buyButton.BackColor = Color.Gray;
                    buyLocked = true;
                    change = totalCopperCoinsTendered - totalCoperCoinsAfterTax;

                    coinSorterInputCopper = change;

                    coinSorter();

                    receiptLetterOutput.Visible = true;
                    receiptPriceOutput.Visible = true;

                    platinumTendered.ReadOnly = true;
                    goldTendered.ReadOnly = true;
                    silverTendered.ReadOnly = true;
                    copperTendered.ReadOnly = true;

                    string rocketBootReceiptTotal = rocketBootTotalPreTaxPricePlatinum + " Platinum, "
                    + rocketBootTotalPreTaxPriceGold + " Gold, "
                    + rocketBootTotalPreTaxPriceSilver + " Silver, "
                    + rocketBootTotalPreTaxPriceCopper + " Copper";
                    string tinkerTableReceiptTotal = tinkerTableTotalPreTaxPricePlatinum + " Platinum, "
                    + tinkerTableTotalPreTaxPriceGold + " Gold, "
                    + tinkerTableTotalPreTaxPriceSilver + " Silver, "
                    + tinkerTablePreTaxPriceCopper + " Copper";
                    string spikeBallReceiptTotal = spikeBallTotalPreTaxPricePlatinum + " Platinum, "
                    + spikeBallTotalPreTaxPriceGold + " Gold, "
                    + spikeBalleTotalPreTaxPriceSilver + " Silver, "
                    + spikeBallPreTaxPriceCopper + " Copper";
                    string receiptCoinTotal = platniumCoinTotal.Text + " Platinum, "
                    + goldCoinTotal.Text + " Gold, "
                    + silverCoinTotal.Text + " Silver, "
                    + copperCoinTotal.Text + " Copper";
                    string receiptCoinTax = platnumCoinTaxTotal.Text + " Platinum, "
                    + goldCoinTaxTotal.Text + " Gold, "
                    + silverCoinTaxTotal.Text + " Silver, "
                    + copperCoinTaxTotal.Text + " Copper";
                    string receiptCoinAfterTax = afterTaxPlatinumCoinTotal.Text + " Platinum, "
                    + afterTaxGoldCoinTotal.Text + " Gold, "
                    + afterTaxSilverCoinTotal.Text + " Silver, "
                    + afterTaxCopperCoinTotal.Text + " Copper";
                    string receiptCoinTendered = platinumTendered.Text + " Platinum, "
                    + goldTendered.Text + " Gold, "
                    + silverTendered.Text + " Silver, "
                    + copperTendered.Text + " Copper";
                    string receiptChange = platnum + " Platinum, "
                    + gold + " Gold, "
                    + silver + " Silver, "
                    + copper + " Copper";

                    receiptPriceOutput.Text = "Goblin Tinkers Shop                                              " + "\n" + "\n" + "\n"
                    + rocketBootReceiptTotal + "\n" + "\n"
                    + tinkerTableReceiptTotal + "\n" + "\n"
                    + spikeBallReceiptTotal + "\n" + "\n" + "\n"
                    + receiptCoinTotal + "\n" + "\n"
                    + receiptCoinTax + "\n" + "\n"
                    + receiptCoinAfterTax + "\n" + "\n" + "\n"
                    + receiptCoinTendered + "\n" + "\n"
                    + receiptChange + "\n" + "\n" + "\n"
                    + "Thanks For Shopping                                            ";
                    receiptLetterOutput.Text = "\n" + "\n" + "\n" 
                    + rocketBootNumb + " Rocket Boots" + "\n" + "\n"
                    + tinkerTableNumb + " Tinker Table" + "\n" + "\n"
                    + spikeBallNumb + " Spike Ball" + "\n" + "\n" + "\n"
                    + "Pretax" + "\n" + "\n"
                    + "Tax" + "\n" + "\n"
                    + "After Tax" + "\n" + "\n" + "\n"
                    + "Tendered" + "\n" + "\n"
                    + "Change"
                    ;
                    for (int i = 0; i < 40; i++)
                    {
                        int prevIntNumb = 0;
                        int change = 0;
                        int prevIntWord = 0;
                        prevIntWord = receiptPriceOutput.Height;
                        change = 10;
                        prevIntNumb = receiptLetterOutput.Height;
                        receiptPriceOutput.Height = prevIntNumb + change;
                        receiptLetterOutput.Height = prevIntWord + change;

                        printer.Play();


                        Thread.Sleep(200);

                        Refresh();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void closeUnfilledCoinSlots()
        {

            if (preTaxCalculate == false)
            {
                platCoin1.Visible = true;
                platniumCoinTotal.Visible = true;
                goldCoin3.Visible = true;
                goldCoinTotal.Visible = true;
                silverCoin1.Visible = true;
                silverCoinTotal.Visible = true;
                copperCoin2.Visible = true;
                copperCoinTotal.Visible = true;

                if (copper == 0)
                {

                    copperCoin2.Visible = false;
                    copperCoinTotal.Visible = false;
                }
                if (silver == 0)
                {
                    silverCoin1.Visible = false;
                    silverCoinTotal.Visible = false;
                }
                if (gold == 0)
                {
                    goldCoin3.Visible = false;
                    goldCoinTotal.Visible = false;
                }
                if (platnum == 0)
                {
                    platCoin1.Visible = false;
                    platniumCoinTotal.Visible = false;
                }
            }
            if (taxCalculate == false)
            {
                platnumCoin2.Visible = true;
                platnumCoinTaxTotal.Visible = true;
                goldCoin4.Visible = true;
                goldCoinTaxTotal.Visible = true;
                silverCoin2.Visible = true;
                silverCoinTaxTotal.Visible = true;
                copperCoin3.Visible = true;
                copperCoinTaxTotal.Visible = true;

                if (copper == 0)
                {

                    copperCoin3.Visible = false;
                    copperCoinTaxTotal.Visible = false;
                }
                if (silver == 0)
                {
                    silverCoin2.Visible = false;
                    silverCoinTaxTotal.Visible = false;
                }
                if (gold == 0)
                {
                    goldCoin4.Visible = false;
                    goldCoinTaxTotal.Visible = false;
                }
                if (platnum == 0)
                {
                    platnumCoin2.Visible = false;
                    platnumCoinTaxTotal.Visible = false;
                }
            }
            if (afterTax == false)
            {
                platinumCoin3.Visible = true;
                afterTaxPlatinumCoinTotal.Visible = true;
                goldCoin5.Visible = true;
                afterTaxGoldCoinTotal.Visible = true;
                silverCoin3.Visible = true;
                afterTaxSilverCoinTotal.Visible = true;
                copperCoin4.Visible = true;
                afterTaxCopperCoinTotal.Visible = true;

                if (copper == 0)
                {

                    copperCoin4.Visible = false;
                    afterTaxCopperCoinTotal.Visible = false;
                }
                if (silver == 0)
                {
                    silverCoin3.Visible = false;
                    afterTaxSilverCoinTotal.Visible = false;
                }
                if (gold == 0)
                {
                    goldCoin5.Visible = false;
                    afterTaxGoldCoinTotal.Visible = false;
                }
                if (platnum == 0)
                {
                    platinumCoin3.Visible = false;
                    afterTaxPlatinumCoinTotal.Visible = false;
                }
            }
        }

        void coinSorter()
        {
            totalCopperCoins = (coinSorterInputPlatnum * 1000000) + (coinSorterInputGold * 10000) + coinSorterInputCopper;

            coinSorterInputPlatnum = 0;
            coinSorterInputGold = 0;
            coinSorterInputSilver = 0;
            coinSorterInputCopper = 0;

            copper = 0;
            silver = 0;
            gold = 0;
            platnum = 0;

            copper = Math.Round(totalCopperCoins,0);
            if (copper >= 100)
            {
                decimal quotent = 0;
                double remainder = 0;

                quotent = Convert.ToDecimal(copper / 100);
                remainder = (copper % 100);
                copper = Math.Round(remainder, 0);
                silver = Convert.ToDouble(Decimal.Truncate(quotent));
            }

            if (silver >= 100)
            {
                decimal quotent = 0;
                double remainder = 0;

                quotent = Convert.ToDecimal(silver / 100);
                remainder = (silver % 100);
                silver = Math.Round(remainder, 0);
                gold = Convert.ToDouble(Decimal.Truncate(quotent));
            }

            if (gold >= 100)
            {
                decimal quotent = 0;
                double remainder = 0;

                quotent = Convert.ToDecimal(gold / 100);
                remainder = (gold % 100);
                gold = Math.Round(remainder, 0);
                platnum = Convert.ToDouble(Decimal.Truncate(quotent));
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
             SoundPlayer printer = new SoundPlayer(Properties.Resources.Dot_Matrix_Printer_SoundBible_com_790333844);
            if (calculateLocked == true)
            {

            }
            if (calculateLocked == false)
            {
                if (rocketBootNumber.Value == 0 && tinkerTableNumber.Value == 0 && spikeballNumber.Value == 0)
                {
                    calculateButton.Text = "No Items In Cart";
                    Refresh();
                    Thread.Sleep(100);
                    calculateButton.Text = "Calculate";
                    Refresh();
                    calculateTrue = false;
                }
                if (rocketBootNumber.Value < 0 || tinkerTableNumber.Value < 0 || spikeballNumber.Value < 0)
                {
                    calculateButton.Text = "No Items In Cart";
                    Refresh();
                    Thread.Sleep(100);
                    calculateButton.Text = "Calculate";
                    Refresh();
                    calculateTrue = false;
                }
                if (rocketBootNumber.Value != 0 || tinkerTableNumber.Value != 0 || spikeballNumber.Value != 0)
                {
                    calculateTrue = true;
                }
                if (calculateTrue == true)
                {
                    rocketBootNumb = Convert.ToDouble(rocketBootNumber.Value);
                    tinkerTableNumb = Convert.ToDouble(tinkerTableNumber.Value);
                    spikeBallNumb = Convert.ToDouble(spikeballNumber.Value);

                    copper = 0;
                    silver = 0;
                    gold = 0;
                    platnum = 0;

                    preTaxCalculate = false;
                    taxCalculate = false;
                    afterTax = false;

                    coinSorterInputGold = (rocketBootNumb * rocketBootPrice) + (tinkerTableNumb * tinkerTablePrice);
                    coinSorterInputCopper = (spikeBallNumb * spikeBallPrice);

                    coinSorter();
                    closeUnfilledCoinSlots();
                    Refresh();

                    platniumCoinTotal.Text = Convert.ToString(platnum);
                    goldCoinTotal.Text = Convert.ToString(gold);
                    silverCoinTotal.Text = Convert.ToString(silver);
                    copperCoinTotal.Text = Convert.ToString(copper);

                    double preTaxCopperCoinTotal = totalCopperCoins;

                    preTaxCalculate = true;

                    totalCopperCoinsTaxedAmount = totalCopperCoins * happinessTax;
                    coinSorterInputCopper = totalCopperCoinsTaxedAmount;

                    coinSorter();
                    closeUnfilledCoinSlots();
                    Refresh();

                    platnumCoinTaxTotal.Text = Convert.ToString(Math.Round(platnum, 0));
                    goldCoinTaxTotal.Text = Convert.ToString(Math.Round(gold, 0));
                    silverCoinTaxTotal.Text = Convert.ToString(Math.Round(silver, 0));
                    copperCoinTaxTotal.Text = Convert.ToString(Math.Round(copper, 0));
                    Refresh();

                    taxCalculate = true;

                    totalCoperCoinsAfterTax = preTaxCopperCoinTotal + totalCopperCoinsTaxedAmount;
                    coinSorterInputCopper = totalCoperCoinsAfterTax;

                    coinSorter();
                    closeUnfilledCoinSlots();
                    Refresh();

                    afterTaxPlatinumCoinTotal.Text = Convert.ToString(Math.Round(platnum, 0));
                    afterTaxGoldCoinTotal.Text = Convert.ToString(Math.Round(gold, 0));
                    afterTaxSilverCoinTotal.Text = Convert.ToString(Math.Round(silver, 0));
                    afterTaxCopperCoinTotal.Text = Convert.ToString(Math.Round(copper, 0));

                    afterTax = true;

                    coinSorterInputGold = rocketBootNumb * rocketBootPrice;

                    coinSorter();

                    rocketBootTotalPreTaxPriceCopper = copper;
                    rocketBootTotalPreTaxPriceSilver = silver;
                    rocketBootTotalPreTaxPriceGold = gold;
                    rocketBootTotalPreTaxPricePlatinum = platnum;

                    coinSorterInputGold = tinkerTableNumb * tinkerTablePrice;

                    coinSorter();

                    tinkerTablePreTaxPriceCopper = copper;
                    tinkerTableTotalPreTaxPriceSilver = silver;
                    tinkerTableTotalPreTaxPriceGold = gold;
                    tinkerTableTotalPreTaxPricePlatinum = platnum;

                    coinSorterInputCopper = spikeBallNumb * spikeBallPrice;

                    coinSorter();

                    spikeBallPreTaxPriceCopper = copper;
                    spikeBalleTotalPreTaxPriceSilver = silver;
                    spikeBallTotalPreTaxPriceGold = gold;
                    spikeBallTotalPreTaxPricePlatinum = platnum;

                    calculateLocked = true;
                    calculateButton.BackColor = Color.Gray;
                    buyButton.BackColor = Color.White;
                    buyLocked = false;
                    rocketBootNumber.ReadOnly = true;
                    tinkerTableNumber.ReadOnly = true;
                    spikeballNumber.ReadOnly = true;
                }
            }
        }

        private void resetOrderButton_Click(object sender, EventArgs e)
        {
             rocketBootNumb = 0f;
             tinkerTableNumb = 0f;
             spikeBallNumb = 0f;
             rocketBootPrice = 5f;
             tinkerTablePrice = 10f;
             spikeBallPrice = 80f;
             platnum = 0;
             gold = 0f;
             silver = 0f;
             copper = 0f;
             happinessTax = 0.10f;

             totalCopperCoins = 0f;
             totalCopperCoinsTaxedAmount = 0f;

             coinSorterInputPlatnum = 0f;
             coinSorterInputGold = 0f;
             coinSorterInputSilver = 0f;
             coinSorterInputCopper = 0f;

             totalCoperCoinsAfterTax = 0f;
             totalCopperCoinsTendered = 0f;
             change = 0f;

             preTaxCalculate = false;
             taxCalculate = false;
             afterTax = false;

             rocketBootTotalPreTaxPriceCopper = 0f;
             rocketBootTotalPreTaxPriceSilver = 0f;
             rocketBootTotalPreTaxPriceGold = 0f;
             rocketBootTotalPreTaxPricePlatinum = 0f;

             tinkerTablePreTaxPriceCopper = 0f;
             tinkerTableTotalPreTaxPriceSilver = 0f;
             tinkerTableTotalPreTaxPriceGold = 0f;
             tinkerTableTotalPreTaxPricePlatinum = 0f;

             spikeBallPreTaxPriceCopper = 0f;
             spikeBalleTotalPreTaxPriceSilver = 0f;
             spikeBallTotalPreTaxPriceGold = 0f;
             spikeBallTotalPreTaxPricePlatinum = 0f;

             notEnoughCoins = false;

             calculateLocked = false;
             buyLocked = true;

            calculateButton.BackColor = Color.White;

            rocketBootNumber.Value = 0;
            rocketBootNumber.ReadOnly = false;
            tinkerTableNumber.Value = 0;
            tinkerTableNumber.ReadOnly = false;
            spikeballNumber.Value = 0;
            spikeballNumber.ReadOnly = false;

            platinumTendered.Value = 0;
            platinumTendered.ReadOnly = false;
            goldTendered.Value = 0;
            goldTendered.ReadOnly = false;
            silverTendered.Value = 0;
            silverTendered.ReadOnly = false;
            copperTendered.Value = 0;
            copperTendered.ReadOnly = false;

            receiptLetterOutput.Height = 10;
            receiptLetterOutput.Visible = false;
            receiptPriceOutput.Height = 10;
            receiptPriceOutput.Visible = false;

            platniumCoinTotal.Text = "";
            goldCoinTotal.Text = "";
            silverCoinTotal.Text = "";
            copperCoinTotal.Text = "";

            platnumCoinTaxTotal.Text = "";
            goldCoinTaxTotal.Text = "";
            silverCoinTaxTotal.Text = "";
            copperCoinTaxTotal.Text = "";

            afterTaxPlatinumCoinTotal.Text = "";
            afterTaxGoldCoinTotal.Text = "";
            afterTaxSilverCoinTotal.Text = "";
            afterTaxCopperCoinTotal.Text = "";



            platCoin1.Visible = true;
            goldCoin3.Visible = true;
            silverCoin1.Visible = true;
            platinumCoin3.Visible = true;
            afterTaxPlatinumCoinTotal.Visible = true;
            goldCoin5.Visible = true;
            afterTaxGoldCoinTotal.Visible = true;
            silverCoin3.Visible = true;
            afterTaxSilverCoinTotal.Visible = true;
            copperCoin4.Visible = true;
            afterTaxCopperCoinTotal.Visible = true;

            platnumCoin2.Visible = true;
            platnumCoinTaxTotal.Visible = true;
            goldCoin4.Visible = true;
            goldCoinTaxTotal.Visible = true;
            silverCoin2.Visible = true;
            silverCoinTaxTotal.Visible = true;
            copperCoin3.Visible = true;
            copperCoinTaxTotal.Visible = true;

            platinumCoin3.Visible = true;
            afterTaxPlatinumCoinTotal.Visible = true;
            goldCoin5.Visible = true;
            afterTaxGoldCoinTotal.Visible = true;
            silverCoin3.Visible = true;
            afterTaxSilverCoinTotal.Visible = true;
            copperCoin4.Visible = true;
            afterTaxCopperCoinTotal.Visible = true;

        }
    }
}
