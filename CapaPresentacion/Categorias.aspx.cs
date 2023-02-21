using CapaEntidad;
using CapaLogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class Categorias : System.Web.UI.Page
    {
        //creamos un objeto de la clase CategoriaLogica que se encuentra en la
        //capa de logica negocios
        private CategoriaLogica Logica = new CategoriaLogica();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Cargamos los valores de la consulata en nuestro GridView
            GridViewCategorias.DataSource = Logica.ListaCategorias();
            GridViewCategorias.DataBind(); //se ejecuta el origen de datos
        }

        //Creamos funcion para el evento oclick del boton guadar
        protected void ButtonGuadarCategoria_Click(object sender, EventArgs e)
        {
            //verficamos que las si las entradas estan vacias
            if (TextBoxNombreCategoria.Text == "" || TextBoxDescripcionCategoria.Text == "")
            {
                return;
            }

            Categoria model = new Categoria
            {
                NombreCategoria = TextBoxNombreCategoria.Text,
                DescripcionCategoria = TextBoxDescripcionCategoria.Text
            };

            //varificamos el resultado
            bool resultado =  Logica.AgregarCategoria(model);

            if (resultado)
            {
                //refrescamos nuestra pagina
                Page_Load(sender, e);
            }
        }
    }
}