using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppTempo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        bool IsDetailSectionOpen;
        public WeatherPage()
        {
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        void OnTodayDetailTapped(System.Object sender, System.EventArgs e)
        {
            //Open Today Section
            ToggleSection("today");
        }

        void OnWeekyDetailTapped(System.Object sender, System.EventArgs e)
        {
            //Toggle Cities Section
            ToggleSection("cities");
        }

        void ToggleSection(string section)
        {
            Animation parentAnimation;
            var element = section == "today" ? todayDetailSection : citiesDetailSection;

            if (IsDetailSectionOpen)
            {
                //Close Section
                var newBounds = new Rectangle(element.Bounds.X, (section == "today" ? citiesDetailSection : todayDetailSection).Bounds.Y, element.Bounds.Width, 80);
                element.LayoutTo(newBounds, 500, Easing.CubicOut);

                //Animate Header to its initial State
                parentAnimation = new Animation
                {
                    { 0, 1, new Animation(v => headerConatiner.HeightRequest = v, headerConatiner.HeightRequest, 100, Easing.CubicInOut) },
                    { 0, 1, new Animation(v => btnContainer.HeightRequest = v, btnContainer.HeightRequest, 160, Easing.CubicInOut) },
                    { 0, 1, new Animation(v => title.FontSize = v,  title.FontSize,  Device.GetNamedSize (NamedSize.Title, typeof(Label)), Easing.CubicInOut) }
                };


                if (section == "today")
                {

                    parentAnimation.Add(0, 1, new Animation(v => temperatureTitle.FontSize = v, 40, 65, Easing.SpringOut));
                    parentAnimation.Add(0, 1, new Animation(v => temperatureIcon.FontSize = v, 40, Device.GetNamedSize(NamedSize.Title, typeof(Label)), Easing.CubicInOut));
                }
                else
                {
                    temperatureSection.FadeTo(1, 200, Easing.Linear);
                    todayDetailBtn.FadeTo(1, 200, Easing.Linear);
                    sunSection.FadeTo(0, 200, Easing.Linear);

                }
            }
            else
            {
                //Open Toggle Section
                var newBounds = new Rectangle(element.Bounds.X, detailContainer.Bounds.Y, element.Bounds.Width, detailContainer.Bounds.Height);
                element.LayoutTo(newBounds, 600, Easing.SpringOut);

                //Animate Header to its new State
                parentAnimation = new Animation
                {
                    { 0, 1, new Animation(v => headerConatiner.HeightRequest = v, headerConatiner.HeightRequest, 75, Easing.SpringOut) },
                    { 0, 1, new Animation(v => btnContainer.HeightRequest = v, btnContainer.HeightRequest, 80, Easing.SpringOut) },
                    { 0, 1, new Animation(v => title.FontSize = v,  title.FontSize,  Device.GetNamedSize (NamedSize.Large, typeof(Label)), Easing.CubicInOut) }
                };

                if (section == "today")
                {

                    parentAnimation.Add(0, 1, new Animation(v => temperatureTitle.FontSize = v, 65, 40, Easing.CubicInOut));


                    parentAnimation.Add(0, 1, new Animation(v => temperatureIcon.FontSize = v, Device.GetNamedSize(NamedSize.Title, typeof(Label)), 40, Easing.CubicInOut));
                   
                }
                else
                {
                    temperatureSection.FadeTo(0, 200, Easing.SinIn);
                    sunSection.FadeTo(1, 200, Easing.Linear);
                    parentAnimation.Add(0, 1, new Animation(v => todayDetailBtn.Opacity = v, 1, 0, Easing.Linear, () => {
                        todayDetailBtn.IsVisible = false;
                     
                    }));
                }

            }
            parentAnimation.Commit(this, "parentAnimation", 22, 500);

            IsDetailSectionOpen = !IsDetailSectionOpen;
        }
    }
}
