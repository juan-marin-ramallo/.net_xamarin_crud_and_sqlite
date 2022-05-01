using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Taller_4_Marin
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection conexionDB;

        public SQLiteHelper(String rutaDB)
        {
            conexionDB = new SQLiteAsyncConnection(rutaDB);
            conexionDB.CreateTableAsync<Persona>().Wait();
        }

        //Insertar y Actualizar
        public Task<int> insertar_actualizar_persona(Persona persona) {
            if (persona.IdPersona != 0)
                return conexionDB.UpdateAsync(persona);
            else
                return conexionDB.InsertAsync(persona);
        }

        //Eliminar
        public Task<int> eliminar_persona(Persona persona) { 
            return conexionDB.DeleteAsync(persona);
        }

        //Consultar Persona
        public Task<Persona> consultarPersona(int idPersona) {
            Task<Persona> persona = conexionDB.Table<Persona>().Where(p => p.IdPersona == idPersona).FirstOrDefaultAsync();
            return persona;
        }

        public Task<List<Persona>> consultarPersonas() { 
            return conexionDB.Table<Persona>().ToListAsync();
        }
    }
}
