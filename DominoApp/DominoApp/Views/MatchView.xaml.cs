﻿using DominoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DominoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchView : ContentPage
    {
        public MatchView()
        {
            InitializeComponent();
            BindingContext = new MatchViewModel();
        }
    }
}