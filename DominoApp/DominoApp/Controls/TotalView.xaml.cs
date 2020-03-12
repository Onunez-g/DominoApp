using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DominoApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TotalView : ContentView
    {
        public TotalView()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ThemTotalScoreProperty =
            BindableProperty.Create("ThemTotalScore", typeof(int), typeof(TotalView), 0);
        public int ThemTotalScore
        {
            get { return (int)GetValue(ThemTotalScoreProperty); }
            set { SetValue(ThemTotalScoreProperty, value); }
        }
        public static readonly BindableProperty WeTotalScoreProperty =
            BindableProperty.Create("WeTotalScore", typeof(int), typeof(TotalView), 0);
        public int WeTotalScore
        {
            get { return (int)GetValue(WeTotalScoreProperty); }
            set { SetValue(WeTotalScoreProperty, value); }
        }
    }
}