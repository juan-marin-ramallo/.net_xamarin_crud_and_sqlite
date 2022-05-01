using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taller_4_Marin
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        //Implementacion de patron de diseño SINGLETON
        public static SQLiteHelper SQLiteDB { 
            get 
            {
                if (db == null)
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"XamarinSqlite.db3"));
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
