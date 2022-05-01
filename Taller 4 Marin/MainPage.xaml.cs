using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taller_4_Marin
{
    public partial class MainPage : ContentPage
    {
        Persona persona;

        public MainPage()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            refrescarListViewPersona();
        }

        private async void refrescarListViewPersona() {
            List<Persona> listaPersonas = await App.SQLiteDB.consultarPersonas();

            if (listaPersonas != null)
                listViewPersonas.ItemsSource = listaPersonas;
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                persona = new Persona();
                persona.Nombre = txtNombre.Text;
                                
                if(await App.SQLiteDB.insertar_actualizar_persona(persona) > 0)
                    await DisplayAlert("Mensaje de exito", "Persona agregada exitosamente", "OK");
                else
                    await DisplayAlert("Mensaje de advertencia", "Problema al agregar persona", "OK");
                
                txtNombre.Text = "";

                refrescarListViewPersona();
            }
            else
                await DisplayAlert("Mensaje de advertencia", "Por favor ingrese el nombre", "OK");
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdPersona.Text)) {
                persona = await App.SQLiteDB.consultarPersona(Convert.ToInt32(txtIdPersona.Text));

                if (persona != null)    
                    txtNombre.Text = persona.Nombre;
                else
                    await DisplayAlert("Mensaje de advertencia", "No existe persona con ese codigo", "OK");
            }
            else
                await DisplayAlert("Mensaje de advertencia", "Por favor ingrese el codigo", "OK");
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (persona != null) { 
                persona.Nombre = txtNombre.Text;

                if(await App.SQLiteDB.insertar_actualizar_persona(persona) > 0)
                    await DisplayAlert("Mensaje de exito", "Persona actualizada exitosamente", "OK");
                else
                    await DisplayAlert("Mensaje de advertencia", "Problema al actualizar persona", "OK");

                txtIdPersona.Text = String.Empty;
                txtNombre.Text = String.Empty;

                refrescarListViewPersona();
            }
            else
                await DisplayAlert("Mensaje de advertencia", "Por favor consulte primero a una persona", "OK");
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (persona != null)
            {
                if(await App.SQLiteDB.eliminar_persona(persona) > 0)
                    await DisplayAlert("Mensaje de exito", "Persona eliminada exitosamente", "OK");
                else
                    await DisplayAlert("Mensaje de advertencia", "Problema al eliminar persona", "OK");

                txtIdPersona.Text = String.Empty;
                txtNombre.Text = String.Empty;

                refrescarListViewPersona();
            }
            else
                await DisplayAlert("Mensaje de advertencia", "Por favor consulte primero a una persona", "OK");
        }
    }
}
