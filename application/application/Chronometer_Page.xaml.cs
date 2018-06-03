using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Chronometer_Page : ContentPage
	{
        public Timer timer;
        public Stopwatch cronometro;
        public int Ehrs, Emin, Eseg, Emilis, Chrs, Cmin, Cseg, Cmilis;
        public  int count = 1;

		public Chronometer_Page ()
		{
			InitializeComponent ();
            timer = new Timer();
            cronometro = new Stopwatch();
            timer.Elapsed += new ElapsedEventHandler(timer_myTick);

        }

        private void timer_myTick(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                labelTimer.Text = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes,
                cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds);

            });
            
        }

        private void btnStart_OnClick(object sender, EventArgs e)
        {
            timer.Enabled = true;
            cronometro.Start();
        }

        private void btnStop_OnClick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            cronometro.Stop();
        }

        private void btnLap_OnClick(object sender, EventArgs e)
        {
            if(cronometro.IsRunning)
            {
                if (count == 1)
                {
                    //first lap
                    Label lap1 = new Label();
                    Label elapsed = new Label();

                    lap1.Text = count + " " + String.Format("{0:00}:{1:00}:{2:00}:{3:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes,
                        cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds);
                    Chrs = cronometro.Elapsed.Hours;
                    Cmin = cronometro.Elapsed.Minutes;
                    Cseg = cronometro.Elapsed.Seconds;
                    Cmilis = cronometro.Elapsed.Milliseconds-1;
                    elapsed.Text = "+" + String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Chrs, Cmin,
                        Cseg, Cmilis);
                    EntriesStackLayout.Children.Add(lap1);
                    EntriesStackLayout.Children.Add(elapsed);
                }
                else
                {
                    Label lap1 = new Label();
                    Label elapsed = new Label();

                    lap1.Text = count + " " + String.Format("{0:00}:{1:00}:{2:00}:{3:00}", cronometro.Elapsed.Hours, cronometro.Elapsed.Minutes,
                        cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds);
                    Ehrs = cronometro.Elapsed.Hours;
                    Emin = cronometro.Elapsed.Minutes;
                    Eseg = cronometro.Elapsed.Seconds;

                    Emilis = cronometro.Elapsed.Milliseconds-1;
                    if (Emilis > Cmilis)
                        Emilis = Emilis - Cmilis;
                    else
                        Emilis = Cmilis - Emilis;

                    elapsed.Text = "+" + String.Format("{0:00}:{1:00}:{2:00}:{3:00}", Ehrs-Chrs, Emin-Cmin,
                       Eseg- Cseg, Emilis);
                    
                    EntriesStackLayout.Children.Add(lap1);
                    EntriesStackLayout.Children.Add(elapsed);
                }
                
                count++;
            }
        }
    }
}