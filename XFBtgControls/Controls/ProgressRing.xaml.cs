using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFBtgLib.Controls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressRing : ContentView
    {
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(int), typeof(ProgressRing), default(int));
        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        public ProgressRing()
        {
            InitializeComponent();


        }
    }
}