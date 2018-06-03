using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

            MainListView.ItemsSource = new List<Sessions>
            {
                new Sessions
                {
                    Image = new Image {
                        Source = "https://t2.uc.ltmcdn.com/images/9/9/3/img_como_saber_si_el_ejercicio_esta_funcionando_29399_orig.jpg", //a 600x600 picture
                        WidthRequest = 150,
                        HeightRequest = 150,
                        MinimumHeightRequest = 150,
                        MinimumWidthRequest = 150,
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.End,
                        Aspect = Aspect.AspectFill//.AspectFit//.Fill 
                    },
                    Nombre = "Session #1",
                    Tiempo = "03:00",
                    Id =1
                },
                new Sessions
                {
                    Image = new Image {
                        Source = "https://t2.uc.ltmcdn.com/images/9/9/3/img_como_saber_si_el_ejercicio_esta_funcionando_29399_orig.jpg", //a 600x600 picture
                        WidthRequest = 150,
                        HeightRequest = 150,
                        MinimumHeightRequest = 150,
                        MinimumWidthRequest = 150,
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.End,
                        Aspect = Aspect.AspectFill//.AspectFit//.Fill 
                    },
                    Nombre = "Session #4",
                    Tiempo = "04:00",
                    Id =2
                },
                new Sessions
                {
                    Image = new Image {
                        Source = "https://t2.uc.ltmcdn.com/images/9/9/3/img_como_saber_si_el_ejercicio_esta_funcionando_29399_orig.jpg", //a 600x600 picture
                        WidthRequest = 150,
                        HeightRequest = 150,
                        MinimumHeightRequest = 150,
                        MinimumWidthRequest = 150,
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.End,
                        Aspect = Aspect.AspectFill//.AspectFit//.Fill 
                    },
                    Nombre = "Session #10",
                    Tiempo = "05:00",
                    Id = 3
                    
                }
            };
            MainListView.ItemTapped += lst_ItemSelected;

        }

        public Page1(string parameter)
        {
            InitializeComponent();

            MainLabel.Text = parameter;
        }

        async private void lst_ItemSelected(object sender, ItemTappedEventArgs e)
        {           
            var selectedItem = e.Item as Sessions;
            await this.Navigation.PushAsync(new Exercice_Details(selectedItem));
            
        }
    }
}