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
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public RegisterModel RegisterData { get; set; }
        public ICommand SaveRegisterDataCommand { get; set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterPageViewModel()
        {
            RegisterData = new RegisterModel();

            SaveRegisterDataCommand = new Command(async () =>
            {
                if (!Validations.IsnotEmpty(RegisterData.UserName))
                {
                    Result = "El nombre de usuario esta vacio";
                }
                else if (!Validations.IsnotEmpty(RegisterData.Email))
                {
                    Result = "El campo Email de usuario esta vacio";
                }
                else if (!Validations.IsnotEmpty(RegisterData.Password) || !Validations.IsnotEmpty(RegisterData.ConfirmPassword))
                {
                    Result = "Las contraseña es requerida ";
                }
                else if (!Validations.IsEqual(RegisterData.Password, RegisterData.ConfirmPassword))
                {
                    Result = "Las contraseñas no coinciden";
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                }
            });
        }

    }
}