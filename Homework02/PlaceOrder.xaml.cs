﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Homework02
{
    /// <summary>
    /// Interaction logic for PlaceOrder.xaml
    /// </summary>
    public partial class PlaceOrder : Window
    {
        Model model;
        public PlaceOrder(Model model)
        {
            this.model = model;
            InitializeComponent();
            cmbTicket.Text = "Choose ticket type.";
            cmbTicket.ItemsSource = model.PriceList;
        }

        private void ReturnToMenu(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu(model);
            m.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(cmbTicket.SelectedIndex > -1)
            {
                string selection = cmbTicket.SelectedItem.ToString().Split(",")[0];

                if(selection == "Children" && model.UserRating == "R"){
                    Underage u = new Underage(model);
                    u.Show();
                    this.Close();
                }
                else
                {
                    model.addTicket(selection);
                    Menu m = new Menu(model);
                    this.Close();
                    m.Show();
                }
            }
        }
    }
}
