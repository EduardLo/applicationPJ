using BottomBar.XamarinForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace application.views
{
    class MainNavigation : BottomBarPage
    {
        public MainNavigation()
        {
            InitPages();
        }
        private void InitPages()
        {
            this.FixedMode = true;
            this.BarTheme = BarThemeTypes.Light;
            this.BarTextColor = Color.FromRgb(222, 198, 157);

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            Children.Add(new NavigationPage(new HomePage())
            {
                Title = "",
                Icon = "ic_action_home.png",
                BarTextColor = Color.Red
            });

            Children.Add(new NavigationPage(new Page2())
            {
                Title = "",
                Icon = "ic_recents.png",
                BarTextColor = Color.FromHex("DEC69D")
            });

            Children.Add(new NavigationPage(new Page1())
            {
                //list of sessions
                Title = "",
                Icon = "ic_favorites.png",
                BarTextColor = Color.FromHex("DEC69D")
            });

        }
    }
}
