using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba_4._1
{
    public partial class Form2 : Form
    {
        DataBase db = new DataBase();
        string Password;
        int currentElement;

        public Form2()
        {
            InitializeComponent();
            currentElement = 0;
        }

        public Form2(string password)
        {
            InitializeComponent();
            currentElement = 0;
            Password = password;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("База данных инвесторов (c) 2018");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            txtNameView.BackColor = Color.White;
            txtSecondNameView.BackColor = Color.White;
            txtSurnameView.BackColor = Color.White;
            txtContractNumberView.BackColor = Color.White;
            txtAddressView.BackColor = Color.White;
            txtsumView.BackColor = Color.White;
            txtTermView.BackColor = Color.White;

            if (txtNameView.Text == "" || txtSecondNameView.Text == "" || txtSurnameView.Text == "" ||
                txtContractNumberView.Text == "" || txtAddressView.Text == "" || txtsumView.Text == "" ||
                txtTermView.Text == "")

            {
                MessageBox.Show("Заполните все поля!");
                if (txtNameView.Text == "")
                    txtNameView.BackColor = Color.Red;

                if (txtSecondNameView.Text == "")
                    txtSecondNameView.BackColor = Color.Red;

                if (txtSurnameView.Text == "")
                    txtSurnameView.BackColor = Color.Red;

                if (txtContractNumberView.Text == "")
                    txtContractNumberView.BackColor = Color.Red;

                if (txtAddressView.Text == "")
                    txtAddressView.BackColor = Color.Red;

                if (txtsumView.Text == "")
                    txtsumView.BackColor = Color.Red;

                if (txtTermView.Text == "")
                    txtTermView.BackColor = Color.Red;

            }

            else if (CorrectName(txtNameView.Text) || CorrectName(txtSecondNameView.Text) ||
                CorrectName(txtSurnameView.Text) || CorrectNumber(txtContractNumberView.Text) ||
                CorrectAddress(txtAddressView.Text) || CorrectDeposit(txtsumView.Text) ||
                CorrectDeposit(txtTermView.Text))
            {
                MessageBox.Show("Недопустимые форматы полей!");
                if (CorrectName(txtNameView.Text))
                    txtNameView.BackColor = Color.Red;

                if (CorrectName(txtSecondNameView.Text))
                    txtSecondNameView.BackColor = Color.Red;

                if (CorrectName(txtSurnameView.Text))
                    txtSurnameView.BackColor = Color.Red;

                if (CorrectNumber(txtContractNumberView.Text))
                    txtContractNumberView.BackColor = Color.Red;

                if (CorrectAddress(txtAddressView.Text))
                    txtAddressView.BackColor = Color.Red;

                if (CorrectDeposit(txtsumView.Text))
                    txtsumView.BackColor = Color.Red;

                if (CorrectDeposit(txtTermView.Text))
                    txtTermView.BackColor = Color.Red;
            }

            else
            {
                currentElement++;

                investors.Rows.Add(currentElement, txtSurnameView.Text, txtNameView.Text, txtSecondNameView.Text,
                    txtContractNumberView.Text, txtAddressView.Text, txtsumView.Text, txtTermView.Text);

                investorsEdit.Rows.Add(currentElement, txtSurnameView.Text, txtNameView.Text, txtSecondNameView.Text,
                    txtContractNumberView.Text, txtAddressView.Text, txtsumView.Text, txtTermView.Text);

                db.Db.Add(new Investor(txtNameView.Text, txtSecondNameView.Text, txtSurnameView.Text,
                     Convert.ToDouble(txtContractNumberView.Text), txtAddressView.Text, Convert.ToDouble(txtsumView.Text),
                     Convert.ToInt32(txtTermView.Text)));

                ActiveForm.Text = "База данных инвесторов (" + db.Db.Count + ")";
            }
        }

        bool CorrectName(string input)
        {
            bool result = false;
            foreach (char item in input)
            {
                if (Char.IsNumber(item))
                    result = true;
                else if (Char.IsPunctuation(item))
                    result = true;
                else if (Char.IsSymbol(item))
                    result = true;
            }
            return result;
        }

        bool CorrectDeposit(string input)
        {
            bool result = false;
            foreach (char item in input)
            {
                if (Char.IsPunctuation(item))
                    result = true;
                else if (Char.IsSymbol(item))
                    result = true;
                else if (Char.IsLetter(item))
                    result = true;
            }
            return result;
        }

        bool CorrectNumber(string input)
        {
            bool result = false;
            foreach (char item in input)
            {
                if (Char.IsPunctuation(item))
                    result = true;
                else if (Char.IsSymbol(item))
                    result = true;
                else if (Char.IsLetter(item))
                    result = true;
            }
            return result;
        }

        bool CorrectAddress(string input)
        {
            bool result = false;
            foreach (char item in input)
            {
                if (item != ',' && item != '/')
                {
                    if (Char.IsPunctuation(item))
                        result = true;
                }
            }
            return result;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == Password)
            {
                txtPassword.BackColor = Color.White;
                txtPassword.Text = "";
                for (int i = 0; i < currentElement; i++)
                {
                    bool result = true;
                    String[] ss1 = new string[9];
                    for (int j = 1; j < investors.ColumnCount; j++)
                    {
                        investorsEdit.Rows[i].Cells[j].Style.BackColor = Color.White;

                        if ((j == 1 || j == 2 || j == 3) && CorrectName(investorsEdit.Rows[i].Cells[j].Value.ToString()))
                        {
                            investorsEdit.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            result = false;
                        }

                        if (j == 4 && CorrectNumber(investorsEdit.Rows[i].Cells[j].Value.ToString()))
                        {
                            investorsEdit.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            result = false;
                        }

                        if (j == 5 && CorrectAddress(investorsEdit.Rows[i].Cells[j].Value.ToString()))
                        {
                            investorsEdit.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            result = false;
                        }

                        if ((j == 6 || j == 7) && CorrectDeposit(investorsEdit.Rows[i].Cells[j].Value.ToString()))
                        {
                            investorsEdit.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            result = false;
                        }

                        ss1[j] = investorsEdit.Rows[i].Cells[j].Value.ToString();
                    }

                    if (result)
                    {
                        for (int k = 1; k < 8; k++)
                        {
                            investors.Rows[i].Cells[k].Value = ss1[k];
                        }
                        db.Db.ElementAt(i).Surname = investorsEdit.Rows[i].Cells[1].Value.ToString();
                        db.Db.ElementAt(i).Name = investorsEdit.Rows[i].Cells[2].Value.ToString();
                        db.Db.ElementAt(i).SecondName = investorsEdit.Rows[i].Cells[3].Value.ToString();
                        db.Db.ElementAt(i).ContractNumber = Convert.ToDouble(investorsEdit.Rows[i].Cells[4].Value.ToString());
                        db.Db.ElementAt(i).Address = investorsEdit.Rows[i].Cells[5].Value.ToString();
                        db.Db.ElementAt(i).Deposit = Convert.ToDouble(investorsEdit.Rows[i].Cells[6].Value.ToString());
                        db.Db.ElementAt(i).Term = Convert.ToInt32(investorsEdit.Rows[i].Cells[7].Value.ToString());

                    }
                }
            }

            else
            {
                MessageBox.Show("Неверный пароль!");
                txtPassword.BackColor = Color.Red;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchView.Rows.Clear();
            if (txtSurnameSearch.Text != "")
            {
                int kolSur = 0;
                for (int i = 0; i < currentElement; i++)
                {
                    if (txtSurnameSearch.Text == db.Db.ElementAt(i).Surname)
                    {
                        kolSur++;
                        SearchView.Rows.Add(kolSur, db.Db.ElementAt(i).Surname, db.Db.ElementAt(i).Name, db.Db.ElementAt(i).SecondName,
                            db.Db.ElementAt(i).ContractNumber, db.Db.ElementAt(i).Address, db.Db.ElementAt(i).Deposit,
                            db.Db.ElementAt(i).Term);
                    }
                }
                txtSurnameSearch.Text = "";
            }

            else if (txtSumSearch.Text != "")
            {
                int kolSum = 0;
                for (int i = 0; i < currentElement; i++)
                {
                    if (db.Db.ElementAt(i).Deposit > Convert.ToDouble(txtSumSearch.Text))
                    {
                        kolSum++;
                        SearchView.Rows.Add(kolSum, db.Db.ElementAt(i).Surname, db.Db.ElementAt(i).Name, db.Db.ElementAt(i).SecondName,
                            db.Db.ElementAt(i).ContractNumber, db.Db.ElementAt(i).Address, db.Db.ElementAt(i).Deposit,
                            db.Db.ElementAt(i).Term);
                    }
                }
                txtSumSearch.Text = "";
            }

            else if (txtTermSearch.Text != "")
            {
                int kolTerm = 0;
                for (int i = 0; i < currentElement; i++)
                {
                    if (db.Db.ElementAt(i).Term > Convert.ToInt32(txtTermSearch.Text))
                    {
                        kolTerm++;
                        SearchView.Rows.Add(kolTerm, db.Db.ElementAt(i).Surname, db.Db.ElementAt(i).Name, db.Db.ElementAt(i).SecondName,
                            db.Db.ElementAt(i).ContractNumber, db.Db.ElementAt(i).Address, db.Db.ElementAt(i).Deposit,
                            db.Db.ElementAt(i).Term);
                    }
                }
                txtTermSearch.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < currentElement; i++)
            {
                if (db.Db.ElementAt(i).Surname == txtSurnameSearch.Text)
                {
                    db.Db.RemoveAt(i);
                    currentElement--;
                }
            }

            investors.Rows.Clear();
            investorsEdit.Rows.Clear();
            SearchView.Rows.Clear();

            for (int j = 0; j < currentElement; j++)
            {
                investors.Rows.Add(j + 1, db.Db.ElementAt(j).Surname, db.Db.ElementAt(j).Name, db.Db.ElementAt(j).SecondName,
                            db.Db.ElementAt(j).ContractNumber, db.Db.ElementAt(j).Address, db.Db.ElementAt(j).Deposit,
                            db.Db.ElementAt(j).Term);

                investorsEdit.Rows.Add(j + 1, db.Db.ElementAt(j).Surname, db.Db.ElementAt(j).Name, db.Db.ElementAt(j).SecondName,
                            db.Db.ElementAt(j).ContractNumber, db.Db.ElementAt(j).Address, db.Db.ElementAt(j).Deposit,
                            db.Db.ElementAt(j).Term);
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream("Result.txt", FileMode.Create);
            StreamWriter write = new StreamWriter(file);

            for (int i = 0; i < currentElement; i++)
            {
                write.WriteLine(i + 1 + ") " + db.Db.ElementAt(i).Surname + "  " + db.Db.ElementAt(i).Name + "  " + db.Db.ElementAt(i).SecondName + "  " +
                            db.Db.ElementAt(i).ContractNumber + "   " + db.Db.ElementAt(i).Address + "   " + db.Db.ElementAt(i).Deposit
                            + "   " + db.Db.ElementAt(i).Term + "\n");
            }

            write.Close();
        }
    }
}

