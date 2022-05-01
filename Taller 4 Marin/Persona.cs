using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Taller_4_Marin
{
    public class Persona
    {
        [PrimaryKey,AutoIncrement]
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
    }
}
