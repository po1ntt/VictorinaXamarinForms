﻿using MyProjectStart.Models;
using MyProjectStart.Services;
using MyProjectStart.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OthersResultsView : ContentPage
    {
        public OthersResultsView()
        {
            InitializeComponent();
            this.BindingContext = new OthersResultsVM();
        }

     
        private async void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = ((CustomControls.CustomEntry)sender).Text;
            UserServices userServices = new UserServices();
            if(search == "")
            {
                ListV.ItemsSource = (await userServices.SelectUsers()).Where(p => p.RoleId == 1).ToList();
            }
            else
            {
                ListV.ItemsSource = (await userServices.SelectUsers()).Where(p => p.RoleId == 1 && p.SurName.Contains(search)).ToList();
            }
        }

       

        private async void ListV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(ListV.SelectedItem != null)
            {
                await Shell.Current.Navigation.PushAsync(new ResultsSelectedUser(((ListView)sender).SelectedItem as UserModel));
            }
            
            ((ListView)sender).SelectedItem = null;
        }
    }
}