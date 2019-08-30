using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Tarea.Helper;
using Tarea.Models;
using Tarea.Views;
using Xamarin.Forms;

namespace Tarea.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public LoginModel UserData { get; set; }
        public ICommand SaveLoginDataCommand { get; set; }
        public ICommand ToRegistePage { get; private set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
        {
            UserData = new LoginModel();

            SaveLoginDataCommand = new Command(async () =>
            {
                if (!Validations.IsnotEmpty(UserData.UserName))
                {
                    Result = "El nombre de usuario esta vacio";
                }
                else if (!Validations.IsnotEmpty(UserData.Password))
                {
                    Result = "Inserte contraseña para continuar.";
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                }
            });

            ToRegistePage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });

        }
    }
}
