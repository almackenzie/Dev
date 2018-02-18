using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColumnHeaderView : ContentView
    {
        public static readonly BindableProperty WeekdayProperty =
            BindableProperty.Create("Weekday", typeof(DayOfWeek), typeof(ColumnHeaderView), DayOfWeek.Monday);

        public DayOfWeek Weekday
        {
            get { return (DayOfWeek)GetValue(WeekdayProperty); }
            set { SetValue(WeekdayProperty, value); }
        }

        public string WeekdayShort => Weekday.ToString()[0].ToString(); 

        public ColumnHeaderView()
        {
            InitializeComponent();
        }
    }

    

}