﻿using MyProjectStart.Models;
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
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public CategoryView(Cathegory cathegory)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(cathegory);
            this.BindingContext = cvm;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTest = e.CurrentSelection.FirstOrDefault() as TestsModel;
            if (selectedTest == null)
                return;
            await Shell.Current.Navigation.PushModalAsync(new TestView(selectedTest));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}