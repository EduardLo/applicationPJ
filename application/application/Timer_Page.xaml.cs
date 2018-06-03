using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer_Page : ContentPage
	{

        public TimeSpan timer;
        public Timer time;
        public Stopwatch cronometro;
        public int Ehrs, Emin, Eseg, Emilis, Chrs, Cmin, Cseg, Cmilis;
        public int totalTime = 1;

        public Timer_Page ()
		{
			InitializeComponent ();
            cronometro = new Stopwatch();
            time = new Timer();
            time.Elapsed += new ElapsedEventHandler(timer_myTick);
            time.Interval = 1000;
            time.AutoReset = true;
		}

        private void timer_myTick(object sender, ElapsedEventArgs e)
        {
            totalTime--;
            Device.BeginInvokeOnMainThread(() =>
            {
                timer = TimeSpan.FromSeconds(totalTime);
                txtHrs.Text = timer.Hours.ToString("00");
                txtMin.Text = timer.Minutes.ToString("00");
                txtSecs.Text = timer.Seconds.ToString("00");
                
            });
            if (totalTime == 0)
            {
                time.Stop();
            }

        }

        private void btnStartCountDown_OnClick(object sender, EventArgs e)
        {
            if (!time.Enabled)
            {
                string fulltime = txtHrs.Text + ":" + txtMin.Text + ":" + txtSecs.Text;

                var hrs = (int.Parse(txtHrs.Text) * 60) * 60;
                var min = int.Parse(txtMin.Text) * 60;
                var sec = int.Parse(txtSecs.Text);

                totalTime = hrs + min + sec;
                timer = new TimeSpan();

                //timer = timer.Subtract(TimeSpan.Parse(fulltime));
                time.Enabled = true;
                btnStartCountDown.Text = "Pause";
            }
            else
            {
                time.Stop();
                time.Enabled = false;
                btnStartCountDown.Text = "Start";
            }
            
        }

        private void btnRestart_OnClick(object sender, EventArgs e)
        {
            time.Stop();
            time.Enabled = false;
            txtHrs.Text = txtMin.Text = txtSecs.Text = "00";
            btnStartCountDown.Text = "Start";
        }
    }
}