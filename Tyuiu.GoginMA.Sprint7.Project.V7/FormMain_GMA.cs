using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.GoginMA.Sprint7.Project.V7.Lib;
using System.IO;

namespace Tyuiu.GoginMA.Sprint7.Project.V7
{
    public partial class FormMain_GMA : Form
    {
        public FormMain_GMA()
        {
            InitializeComponent();
            dataGridViewInfo_GMA.RowCount = 100;
            dataGridViewInfo_GMA.ColumnCount = 100;
            for (int i = 0; i < 100; i++)
            {
                dataGridViewInfo_GMA.Columns[i].Width = 130;
            }
            dataGridViewInfo_GMA.Columns[2].Width = 180;
        }
        DataService ds = new DataService();
        public static string path = $@"{Directory.GetCurrentDirectory()}\Project\Домоуправление.csv";

        private void buttonSaveFile_GMA_Click(object sender, EventArgs e)
        {
            if ((textBoxFIO_GMA.Text == "") || (textBoxAddEntrance_GMA.Text == "") || (textBoxFlatArea_GMA.Text == "") || (textBoxAddFlat_GMA.Text == "") || (textBoxSumPeople_GMA.Text == "") || (textBoxSumRoom_GMA.Text == "") || ((radioButtonBuy_GMA.Checked == false) && (radioButtonRent_GMA.Checked == false)))
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string str = "";

                bool FlatBusy = ds.FlatExist(path, Convert.ToInt32(textBoxAddEntrance_GMA.Text), Convert.ToInt32(textBoxAddFlat_GMA.Text));

                if (FlatBusy)
                    MessageBox.Show("Данная квартира занята", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (radioButtonBuy_GMA.Checked == true)
                            str = $"{textBoxAddEntrance_GMA.Text};{textBoxAddFlat_GMA.Text};{textBoxFIO_GMA.Text};{textBoxSumPeople_GMA.Text};{textBoxFlatArea_GMA.Text};{textBoxSumRoom_GMA.Text};покупка";
                        else
                            str = $"{textBoxAddEntrance_GMA.Text};{textBoxAddFlat_GMA.Text};{textBoxFIO_GMA.Text};{textBoxSumPeople_GMA.Text};{textBoxFlatArea_GMA.Text};{textBoxSumRoom_GMA.Text};аренда";
                    }
                    File.AppendAllText(path, str + "\n");
                    textBoxFIO_GMA.Text = "";
                    textBoxAddEntrance_GMA.Text = "";
                    textBoxFlatArea_GMA.Text = "";
                    textBoxAddFlat_GMA.Text = "";
                    textBoxSumPeople_GMA.Text = "";
                    textBoxSumRoom_GMA.Text = "";
                    radioButtonBuy_GMA.Checked = false;
                    radioButtonRent_GMA.Checked = false;
                    string[,] DataMatrix = ds.GetMatrix(path);
                    int rows = DataMatrix.GetLength(0);
                    int columns = DataMatrix.GetLength(1);
                    for (int r = 0; r <= rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_GMA.Rows[r].Cells[c].Value = "";
                        }
                    }

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_GMA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                        }
                    }
                    MessageBox.Show("Новый житель зарегистрирован!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonDeletePeople_GMA_Click(object sender, EventArgs e)
        {
            if ((textBoxDeleteEntrance_GMA.Text == "") || (textBoxDeleteFlat_GMA.Text == ""))
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool FlatBusy = ds.FlatExist(path, Convert.ToInt32(textBoxDeleteEntrance_GMA.Text), Convert.ToInt32(textBoxDeleteFlat_GMA.Text));

                if (FlatBusy == false)
                    MessageBox.Show("Такой квартиры нет в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string[] strRows = File.ReadAllLines(path);

                    for (int i = 0; i < strRows.Length; i++)
                    {
                        string[] strIndex = strRows[i].Split(';');
                        if ((strIndex[0] == textBoxDeleteEntrance_GMA.Text) && (strIndex[1] == textBoxDeleteFlat_GMA.Text))
                            strRows[i] = "";
                    }
                    strRows = strRows.Where(i => i != "").ToArray();

                    File.Delete("Домоуправление.csv");

                    saveFileDialogInfo_GMA.FileName = "Домоуправление.csv";
                    saveFileDialogInfo_GMA.ShowDialog();

                    path = saveFileDialogInfo_GMA.FileName;

                    File.WriteAllLines(path, strRows, Encoding.UTF8);

                    string[,] DataMatrix = ds.GetMatrix(path);

                    int rows = DataMatrix.GetLength(0);
                    int columns = DataMatrix.GetLength(1);

                    for (int r = 0; r <= rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_GMA.Rows[r].Cells[c].Value = "";
                        }
                    }

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            dataGridViewInfo_GMA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                        }
                    }
                    MessageBox.Show("Квартирант выселен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            textBoxDeleteEntrance_GMA.Text = "";
            textBoxDeleteFlat_GMA.Text = "";
        }

        private void buttonOpenFile_GMA_Click(object sender, EventArgs e)
        {
            openFileDialogInfo_GMA.ShowDialog();
            string FileName = openFileDialogInfo_GMA.FileName;

            string[,] DataMatrix = ds.GetMatrix(FileName);

            int rows = DataMatrix.GetLength(0);
            int columns = DataMatrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                }
            }
            buttonMaxCountPeople_GMA.Enabled = true;
            buttonMaxEntrance_GMA.Enabled = true;
            buttonMaxFlatArea_GMA.Enabled = true;
            buttonMinCountPeople_GMA.Enabled = true;
            buttonMinEntrance_GMA.Enabled = true;
            buttonMinFlatArea_GMA.Enabled = true;
            buttonBeginRent_GMA.Enabled = true;
            buttonBeginBuy_GMA.Enabled = true;
        }

        private void buttonMinEntrance_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 0);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonMaxEntrance_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 0);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonMinCountPeople_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 3);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonMaxCountPeople_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 3);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonMinFlatArea_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMin(DataMatrix, 4);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonMaxFlatArea_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortMax(DataMatrix, 4);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonBeginRent_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMaxDataMatrix = ds.SortBeginRent(DataMatrix, 6);

            for (int r = 0; r < SortMaxDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMaxDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMaxDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonBeginBuy_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);
            string[,] SortMinDataMatrix = ds.SortBeginBuy(DataMatrix, 6);

            for (int r = 0; r < SortMinDataMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < SortMinDataMatrix.GetLength(1); c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = SortMinDataMatrix[r, c];
                }
            }
            buttonBack_GMA.Enabled = true;
        }

        private void buttonBack_GMA_Click(object sender, EventArgs e)
        {
            string[,] DataMatrix = ds.GetMatrix(path);

            int rows = DataMatrix.GetLength(0);
            int columns = DataMatrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    dataGridViewInfo_GMA.Rows[r].Cells[c].Value = DataMatrix[r, c];
                }
            }
        }

        private void buttonAbout_GMA_Click(object sender, EventArgs e)
        {
            FormAbout_GMA formAbout = new FormAbout_GMA();
            formAbout.ShowDialog();
        }

        private void buttonHelp_GMA_Click(object sender, EventArgs e)
        {
            FormHelp_GMA formHelp = new FormHelp_GMA();
            formHelp.ShowDialog();
        }
    }
}
