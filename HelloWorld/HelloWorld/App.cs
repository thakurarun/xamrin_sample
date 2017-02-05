using HelloWorld.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HelloWorld
{
    public class App : Application
    {
        public App()
        {
            Dashboard dashboard = new Dashboard();
            MainPage = new NavigationPage(dashboard);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
