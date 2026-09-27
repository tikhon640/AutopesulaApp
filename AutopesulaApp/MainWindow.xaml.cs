using System;
using System.Collections.ObjectModel;
using System.Windows;
using AutopesulaApp.Enums;
using AutopesulaApp.Helpers;
using AutopesulaApp.Models;

namespace AutopesulaApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<WashOrder> orders =
            new ObservableCollection<WashOrder>();

        public MainWindow()
        {
            InitializeComponent();

            Title = Properties.Resources.WindowTitle;

            cmbProgram.ItemsSource = Enum.GetValues(typeof(WashProgram));

            dgOrders.ItemsSource = orders;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClient.Text))
            {
                MessageBox.Show(Properties.Resources.ErrorName);
                return;
            }

            if (cmbProgram.SelectedItem == null)
            {
                MessageBox.Show(Properties.Resources.ErrorProgram);
                return;
            }

            WashProgram program =
                (WashProgram)cmbProgram.SelectedItem;

            WashOrder order = new WashOrder
            {
                ClientName = txtClient.Text,
                Program = program,
                Price = WashCalculator.CalculatePrice(program),
                Duration = WashCalculator.CalculateDuration(program)
            };

            orders.Add(order);

            txtClient.Clear();
            cmbProgram.SelectedIndex = -1;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem is WashOrder selected)
            {
                if (cmbProgram.SelectedItem == null)
                {
                    MessageBox.Show(Properties.Resources.ErrorProgram);
                    return;
                }

                selected.ClientName = txtClient.Text;

                WashProgram program =
                    (WashProgram)cmbProgram.SelectedItem;

                selected.Program = program;
                selected.Price = WashCalculator.CalculatePrice(program);
                selected.Duration = WashCalculator.CalculateDuration(program);

                dgOrders.Items.Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItem is WashOrder selected)
            {
                orders.Remove(selected);
            }
        }
    }
}