using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Timer_Interval_Page : ContentPage
	{

        public Timer workTime, restTime, rbwTime;
        public int cycles, ccycles, sets, csets;
        public int wtValue, cwtValue, rtValue, crtValue, rbsValue, crbsValue;
        public TimeSpan timer;

        public int CurrentTimer;

		public Timer_Interval_Page ()
		{
			InitializeComponent ();
            workTime = new Timer();
            restTime = new Timer();
            rbwTime = new Timer();

            workTime.Interval = 1000;
            restTime.Interval = 1000;
            rbwTime.Interval = 1000;

            workTime.Elapsed += new ElapsedEventHandler(workTime_myTick);
            restTime.Elapsed += new ElapsedEventHandler(restTime_myTick);
            rbwTime.Elapsed += new ElapsedEventHandler(rbwTime_myTick);
		}

        public void getWorkValues()
        {
            var hrs = int.Parse(txtWMinutes.Text)*60;
            var sec = int.Parse(txtWSecs.Text);

            wtValue = hrs + sec;
        }

        public void getRestValues()
        {
            var hrs = int.Parse(txtRMinutes.Text) * 60;
            var sec = int.Parse(txtRSecs.Text);

            rtValue = hrs + sec;
        }

        public void getRBWValues()
        {
            var hrs = int.Parse(txtRBSMin.Text) * 60;
            var sec = int.Parse(txtRBSSecs.Text);

            rbsValue = hrs + sec;
            crbsValue = rbsValue;
        }

        private void btnStop_OnClick(object sender, EventArgs e)
        {
            switch (CurrentTimer)
            {
                case 1:
                    workTime.Stop();
                    break;
                case 2:
                    restTime.Stop();
                    break;
                case 3:
                    rbwTime.Stop();
                    break;
            }
        }

        private void btnStartWork_OnClick(object sender, EventArgs e)
        {
            if (CurrentTimer != 0)
            {
                switch (CurrentTimer)
                {
                    case 1:
                        workTime.Start();
                        break;
                    case 2:
                        restTime.Start();
                        break;
                    case 3:
                        rbwTime.Start();
                        break;
                }
            }
            else
            {
                cycles = int.Parse(txtCycles.Text);
                ccycles = cycles;

                sets = int.Parse(txtSets.Text);
                csets = sets;

                getWorkValues();
                getRestValues();
                getRBWValues();
                startWork();
            }
            
        }

        public void startWork()
        {
            cwtValue = wtValue;
            resetValues();
            workTime.Enabled = true;
        }

        public void resetValues()
        {
            //reset values from cycles and above
            Device.BeginInvokeOnMainThread(() =>
            {
                timer = TimeSpan.FromSeconds(wtValue);
                txtWMinutes.Text = timer.Minutes.ToString("00");
                txtWSecs.Text = timer.Seconds.ToString("00");

                timer = TimeSpan.FromSeconds(rtValue);
                txtRMinutes.Text = timer.Minutes.ToString("00");
                txtRSecs.Text = timer.Seconds.ToString("00");

                
            });
        }

        private void workTime_myTick(object sender, ElapsedEventArgs e)
        {
            cwtValue--;
            CurrentTimer = 1;
            Device.BeginInvokeOnMainThread(() =>
            {
                timer = TimeSpan.FromSeconds(cwtValue);
                txtWMinutes.Text = timer.Minutes.ToString("00");
                txtWSecs.Text = timer.Seconds.ToString("00");

            });
            if (cwtValue == 0)
            {
                workTime.Stop();
                crtValue = rtValue;
                //start rest timer
                Device.BeginInvokeOnMainThread(() =>
                {
                    timer = TimeSpan.FromSeconds(rtValue);
                    txtRMinutes.Text = timer.Minutes.ToString("00");
                    txtRSecs.Text = timer.Seconds.ToString("00");
                });
                restTime.Enabled = true;
                //restTime.Start();
            }

        }

        private void restTime_myTick(object sender, ElapsedEventArgs e)
        {
            crtValue--;
            CurrentTimer = 2;
            Device.BeginInvokeOnMainThread(() =>
            {
                timer = TimeSpan.FromSeconds(crtValue);
                txtRMinutes.Text = timer.Minutes.ToString("00");
                txtRSecs.Text = timer.Seconds.ToString("00");

            });
            if (crtValue == 0)
            {
                restTime.Stop();
                //cycles --
                
                if (ccycles != 0)
                {
                    ccycles--;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        txtCycles.Text = ccycles.ToString("00");
                        timer = TimeSpan.FromSeconds(wtValue);
                        txtWMinutes.Text = timer.Minutes.ToString("00");
                        txtWSecs.Text = timer.Seconds.ToString("00");

                    });
                    startWork();
                }
                else
                {
                    //cycles = 0, so... must rest between works
                    startRestBTW();
                }
            }
        }

        private void rbwTime_myTick(object sender, ElapsedEventArgs e)
        {
            crbsValue--;
            CurrentTimer = 3;
            Device.BeginInvokeOnMainThread(() =>
            {
                timer = TimeSpan.FromSeconds(crbsValue);
                txtRBSMin.Text = timer.Minutes.ToString("00");
                txtRBSSecs.Text = timer.Seconds.ToString("00");

            });
            if (crbsValue == 0)
            {
                rbwTime.Stop();
                //sets --
                
                if (csets != 0)
                {
                    csets--;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        txtSets.Text = csets.ToString("00");
                        timer = TimeSpan.FromSeconds(rbsValue);
                        txtRBSMin.Text = timer.Minutes.ToString("00");
                        txtRBSSecs.Text = timer.Seconds.ToString("00");
                        txtCycles.Text = cycles.ToString("00");
                        ccycles = cycles;
                    });
                    startWork();
                }
                else
                {
                    //sets = 0, so... must End the game
                    //startRestBTW();
                    CurrentTimer = 0;
                }
            }
        }

        private void startRestBTW()
        {
            crbsValue = rbsValue;
            rbwTime.Enabled = true;
        }
    }
}