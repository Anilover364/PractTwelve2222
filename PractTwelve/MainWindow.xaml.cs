using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Пример_таблицы_WPF;

namespace PractTwelve
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PosRan = true;
            //int count=10;
            //int[] mas = new int[count];
            //dataGrid.ItemsSource= VisualArray.ToDataTable(mas).DefaultView;
        }
        public static int x = 0;
        static bool PosRan;
        public static int[,] mas;
        private void Click(object sender, RoutedEventArgs e)
        {
            //trulala.Text = " ";
            string ss;
var send = sender as Button ;
            var sen=sender as MenuItem;
            if (send != null)
            {
              ss = send.Name;
            }
            else {  ss = sen.Name; }
            if (ss.Substring(0, 1) == "M") 
            {
            ss=ss.Substring(1);
            }
            switch (ss)
            {
                case "Gener":
                    //MessageBox.Show(MDel.Name.Substring(1));

                        int.TryParse(Row.Text, out int row);
                        int.TryParse(Col.Text, out int col);
                        int.TryParse(Ran.Text, out int ran);
                        if (row <= 0)
                        {
                            Row.Clear();
                            //Row.Focus();
                            if (trulala.Text == "")
                            {
                                trulala.Text = "Rows is not foung";
                                Delay();
                            }
                        }

                        else if (col <= 0)
                        {
                            Col.Clear();
                            //Col.Focus();
                            if (trulala.Text == "")
                            {
                                trulala.Text = "Columns is not foung";
                                Delay();
                            }

                        }
                        else if (ran <= 0)
                        {
                            Ran.Clear();
                            //Ran.Focus();
                            if (trulala.Text == "")
                            {
                                trulala.Text = "Range is not foung";
                                Delay();
                            }
                        }
                        else if (col != 0 & row != 0)
                        {
                            //int[,] mas = new int[row,col];
                            mas = new int[row, col];

                            Random r = new Random();

                            for (int i = 0; i < mas.GetLength(0); i++)
                            {
                                for (int j = 0; j < mas.GetLength(1); j++)
                                {
                                    mas[i, j] = r.Next(1, ran + 1);



                                    if (PosRan == true)
                                    {
                                        mas[i, j] = r.Next(1, ran + 1);
                                    }
                                    else
                                    {
                                        mas[i, j] = r.Next(-ran, 0);
                                    }
                                }
                            }
                        if (gaga.IsChecked == false)
                        {
                            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                        }
                        else
                        { 
                            dataGrid1.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                            bool[,] sas = new bool [row,1];
                            int t = 0;
                            for (int i = 0; i < mas.GetLength(0); i++) 
                            {
                                for (int j = 0; j < mas.GetLength(1); j++) 
                                {
                                    if (mas[i,j]==1)
                                    t++;
                                
                                }
                                if (t == mas.GetLength(1)) { MessageBox.Show("lala"); sas[i,0] = true; }
                                t = 0;
                            }
                            dataGrid2.ItemsSource = VisualArray.ToDataTable(sas).DefaultView;

                        }
                    }
                    break;
                case "Count":
                    if (gaga.IsChecked == false)
                    {
                        int t = 0;

                        if (mas != null)
                        {
                            for (int i = 0; i < mas.GetLength(0); i++)
                            {
                                for (int j = 0; j < mas.GetLength(1); j++)
                                {
                                    //if (PosRan == false)
                                    //{
                                    //    mas[i, j] = -mas[i, j];
                                    //}
                                    //else 
                                    //{
                                    //    mas[i, j] =Math.Abs( mas[i, j]) ;
                                    //}
                                    t += mas[i, j];
                                }
                            }
                            //if (PosRan == false)
                            //{
                            //    t = -t;
                            //}
                            //else { t = Math.Abs(t); }
                            lala.Text = t.ToString();
                        }
                        else
                        {
                            if (trulala.Text == "")
                            {
                                trulala.Text = "DataGrid is not foung";
                                Delay();
                            }
                        }
                    }
                    else 
                    {
                        if (trulala.Text == "")
                        {
                            trulala.Text = "Net smisla bro";
                            Delay();
                        }
                    }
                    break;
                case "Del":
                    if (gaga.IsChecked == false)
                    {
                        dataGrid.ItemsSource = null;
                        mas = null;
                        lala.Clear();
                        Ran.Clear();
                        Col.Clear();
                        Row.Clear();
                    }
                    else
                    {
                        if (trulala.Text == "")
                        {
                            trulala.Text = "Net smisla bro";
                            Delay();
                        }
                    }
                    break;
                    
                case "Save":
                    if (gaga.IsChecked == false)
                    {
                        if (mas != null)
                        {
                            SaveFileDialog saveD = new SaveFileDialog();
                            saveD.DefaultExt = ".txt";
                            saveD.Filter = "All files (*.*) | *.* | Texty | *.txt";
                            saveD.FilterIndex = 2;
                            saveD.Title = "Saved DataGrid";
                            if (saveD.ShowDialog() == true)
                            {
                                StreamWriter file = new StreamWriter(saveD.FileName);
                                file.WriteLine(mas.GetLength(0));
                                file.WriteLine(mas.GetLength(1));
                                file.WriteLine();
                                for (int i = 0; i < mas.GetLength(0); i++)
                                {
                                    for (int j = 0; j < mas.GetLength(1); j++)
                                    {
                                        if (PosRan == false) { mas[i, j] = -mas[i, j]; }
                                        file.Write(mas[i, j]);
                                    }
                                }
                                if (PosRan == false)
                                {
                                    file.WriteLine();
                                    file.WriteLine("Neg");
                                }
                                file.Close();
                            }
                        }
                    }
                    //MessageBox.Show("asd");
                    break;
                case "Load":
                    if (gaga.IsChecked == false)
                    {
                        OpenFileDialog openD = new OpenFileDialog();
                        openD.DefaultExt = ".txt";
                        openD.Filter = "All files (*.*) | *.* | Texty | *.txt";
                        openD.FilterIndex = 2;
                        openD.Title = "Load DataGrid";
                        if (openD.ShowDialog() == true)
                        {
                            StreamReader file = new StreamReader(openD.FileName);
                            string line;
                            string y = "";
                            string tt = "";
                            string qwerty = "";
                            int c = 0;
                            bool neg = false;

                            while ((line = file.ReadLine()) != null)
                            {
                                c++;
                                switch (c)
                                {
                                    case 1:
                                        y = line;
                                        //MessageBox.Show(y);
                                        break;
                                    case 2:
                                        tt = line;
                                        //MessageBox.Show(tt);
                                        break;
                                    case 4:
                                        qwerty = line;
                                        //MessageBox.Show(qwerty);
                                        break;
                                    case 5:
                                        if (line == "Neg")
                                        {
                                            neg = true;
                                        }
                                        break;
                                }
                            }
                            file.Close();
                            mas = new int[Convert.ToInt32(y), Convert.ToInt32(tt)];
                            //if (qwerty.Substring(1) == "-") 
                            //{
                            //neg = true;
                            //    MessageBox.Show("pidorasi");
                            //}
                            int[] pas = new int[Convert.ToInt32(y) * Convert.ToInt32(tt)];

                            int q = 0;
                            foreach (char ch in qwerty)
                            {
                                pas[q] = Convert.ToInt32(ch.ToString());
                                q++;
                            }
                            q = 0;
                            for (int i = 0; i < mas.GetLength(0); i++)
                            {
                                for (int j = 0; j < mas.GetLength(1); j++)
                                {
                                    if (neg == false)
                                    {
                                        mas[i, j] = pas[q];

                                    }
                                    else
                                    {
                                        mas[i, j] = -pas[q];
                                    }

                                    q++;
                                }
                            }
                            dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                            if (neg == false)
                            {
                                Pos.IsChecked = true;
                            }
                            else { Neg.IsChecked = true; }
                            //string line1=1;
                            //string line2=2;
                            //string line4=4;
                        }
                    }
                        break;
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            //var send=sender as TextBox;
            //if (send.Name == "Row")
            //{
            //    int.TryParse(Row.Text, out int row);
            //    if (row == 0) 
            //    {
            //        //MessageBox.Show("topola");
            //        Row.Text.Substring(Row.Text.Length);
            //    }


            //    //MessageBox.Show("lala");
            //}
            //else { MessageBox.Show("topola"); }
        }

        private void Radio_Click(object sender, RoutedEventArgs e)
        {
            var send = sender as RadioButton;
            if (send.Name == "Pos")
            {
                PosRan = true;
            }
            else { PosRan = false; }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //    int indRow=e.Row.GetIndex();
            //    int indCol = e.Column.DisplayIndex;
            //    //if (dataGrid.ItemsSource.[indRow,indCol]==0)

            //    mas[indRow,indCol]=Convert.ToInt32(((TextBox)e.EditingElement).Text);
            //    MessageBox.Show("lala");
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedCell = e.EditingElement as TextBox;
                if (editedCell != null)
                {
                    string newValue = editedCell.Text;

                    // Проверка, является ли значение числом
                    if (!int.TryParse(newValue, out int numericValue))
                    {
                        // Если значение не число, устанавливаем его равным 1
                        editedCell.Text = "0";
                        numericValue = 0;
                        if (trulala.Text == "")
                        {
                            trulala.Text = "ItemSource not found";
                            Delay();
                        }
                        
                    }

                    // Обновление массива
                    int rowIndex = e.Row.GetIndex();
                    int columnIndex = e.Column.DisplayIndex;

                    // Проверка, чтобы индексы не выходили за пределы массива
                    if (rowIndex < mas.GetLength(0) && columnIndex < mas.GetLength(1))
                    {
                        mas[rowIndex, columnIndex] = numericValue;
                    }

                    // Вывод массива в консоль для проверки
                    //PrintArray();
                }
            }
        }
       public async void Delay() 
        {
        await Task.Delay(2000);
            trulala.Text = "";
        }
        private void Focus(object sender, RoutedEventArgs e)
        {
            //trulala.Text = "";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
                return;
            }
        }

        private void gaga_Click(object sender, RoutedEventArgs e)
        {
            if (gaga.IsChecked == true)
            {
                dataGrid.Visibility = Visibility.Hidden;
                dataGrid.ItemsSource = null;
                mas = null;
                lala.Clear();
                Ran.Clear();
                Col.Clear();
                Row.Clear();
                Neg.IsEnabled = false;
                Pos.IsEnabled = false;
                dataGrid1.Visibility = Visibility.Visible;
                dataGrid2.Visibility = Visibility.Visible;
                //MessageBox.Show("trulalela");
            }
            else 
            {
                dataGrid1.ItemsSource = null;
                dataGrid2.ItemsSource = null;
                mas = null;
                lala.Clear();
                Neg.IsEnabled = true;
                Pos.IsEnabled = true;
                Ran.Clear();
                Col.Clear();
                Row.Clear();
                dataGrid.Visibility = Visibility.Visible;
                dataGrid1.Visibility = Visibility.Hidden;
                dataGrid2.Visibility = Visibility.Hidden;
                //MessageBox.Show("trulala");
            }
        }
    }
}
