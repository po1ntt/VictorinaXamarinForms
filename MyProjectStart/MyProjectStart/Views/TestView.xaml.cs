﻿using MyProjectStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProjectStart.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjectStart.ViewsModel;

namespace MyProjectStart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestView : ContentPage
    {
      
       
        TestViewModel cvm;
        public TestView(TestsModel tests)
        {
            cvm = new TestViewModel(tests);
            InitializeComponent();
            this.BindingContext = cvm;
           
        }

        private void Button_test_clicked(object sender, EventArgs e)
        {
            string textanswer = ((Button)sender).Text;


            var data = cvm.QestionsByTest.ToList();

            foreach(var item in data)
            {
                if(textanswer == item.quest_rightanswer)
                {
                    ((Button)sender).BackgroundColor = Color.Green;
                    textanswer = null;
                }
                else
                {
                    ((Button)sender).BackgroundColor = Color.Red;
                }
                
            }
            
        }
    }
}