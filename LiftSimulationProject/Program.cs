using System;
using System.Windows.Forms;
using View;

namespace LiftSimulationProject
{
    // непотокобезопасный
   public class MyApplicationContext : ApplicationContext
    {
        private static int count = 0;

        private static MyApplicationContext myContext;

        private MyApplicationContext()
        {
            if (myContext == null)
            {
                createStartUpForm().Show();

                myContext = this;
            }
        }

        public static MyApplicationContext GetCurrentContext()
        {
            if (myContext == null)
            {
                return new MyApplicationContext();
            }
            else return myContext;
        }

        public void OnFormClosed(object sender, EventArgs e)
        {
            count--;
            if (count == 0)
            {
                ExitThread();
            }
        }

        public static FormStartUp createStartUpForm()
        {
            FormStartUp formStartUp = new FormStartUp();
            count++;
            return formStartUp;
        }
        public static FormMonitoring createMonitoringForm()
        {
            FormMonitoring formMonitoring = new FormMonitoring();
            count++;
            return formMonitoring;
        }
        public static FormInteriorObservation createInteriorObservationForm()
        {
            FormInteriorObservation formInteriorObservation = new FormInteriorObservation(AdditionalSystemConfiguration.LiftConfigData.NumberOfFloors);
            count++;
            return formInteriorObservation;
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MyApplicationContext.GetCurrentContext());
        }
    }
}
