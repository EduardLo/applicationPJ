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
	public partial class Exercice_Details : ContentPage
	{
		public Exercice_Details ()
		{
			InitializeComponent ();


            
        }

        public Exercice_Details(Sessions Exercise)
        {
            InitializeComponent();
            MainLabel.Text = Exercise.Nombre;
            this.Title = Exercise.Nombre;
            switch (Exercise.Id)
            {
                case 1:
                    MainListView.ItemsSource = new List<Ejercicios>
                    {
                        new Ejercicios
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
                            Nombre = "Ejercicio #1",
                            Tiempo = "03:00"
                        },
                        new Ejercicios
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
                            Nombre = "Ejercicio #3",
                            Tiempo = "04:00"
                        }
                    };
                    break;
                case 2:
                    MainListView.ItemsSource = new List<Ejercicios>
                    {
                        new Ejercicios
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
                            Nombre = "Ejercicio #1",
                            Tiempo = "03:00"
                        },
                        new Ejercicios
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
                            Nombre = "Ejercicio #3",
                            Tiempo = "04:00"
                        },
                        new Ejercicios
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
                            Nombre = "Ejercicio #2",
                            Tiempo = "05:00"
                        }
                    };
                    break;
                case 3:
                    MainLabel.Text = "Opsss No Exercises Available!";
                    break;
            }
            
        }
    }
}