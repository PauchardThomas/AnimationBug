using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AnimationBug
{
    public partial class MainPage : ContentPage
    {

        double widthScreen;
        bool loop = true;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetScreenMetrics();
            AnimateBoxView();
        }

        /// <summary>
        /// Get Screen metrics
        /// </summary>
        private void GetScreenMetrics()
        {
            var metrics = DeviceDisplay.MainDisplayInfo;
            widthScreen = metrics.Width / metrics.Density;
        }

        /// <summary>
        /// Animate boxview
        /// </summary>
        private async void AnimateBoxView()
        {
            await Task.Run(async () =>
            {
                while (loop)
                {
                    try
                    {
                        await bvAnim.TranslateTo(-widthScreen, bvAnim.TranslationY, 2000);
                        bvAnim.TranslationX = widthScreen;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            });
        }
    }
}
