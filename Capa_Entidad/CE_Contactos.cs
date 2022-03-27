using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Entidad
{
    public class CE_Contactos
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private int _IDContacto;

        private String _CodeContacto;

        private String _NombreContacto;

        private String _ApellidoContacto;

        public int IDContacto { get => _IDContacto; set => _IDContacto = value; }
        public string CodeContacto { get => _CodeContacto; set => _CodeContacto = value; }
        public string NombreContacto { get => _NombreContacto; set => _NombreContacto = value; }
        public string ApellidoContacto { get => _ApellidoContacto; set => _ApellidoContacto = value; }
    }
}
