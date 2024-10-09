public class Program
{

    static List<Pedidos> pedidosPend = new List<Pedidos>();

    static void Main(string [] args)
    {

        CargarDatos cargaDeDatos= new CargarDatos();
        Cadeteria cadeteria = cargaDeDatos.CargarDatosCadeteria("assets/Cadeteria.csv"); // .../.../.../assets/Cadeteria.csv -RUTA PARA DEBUGUEAR-
        List<Cadete> listaCadetes = cargaDeDatos.CargarDatosCadetes("assets/Cadetes.csv"); // .../.../.../assets/Cadetes.csv -RUTA PARA DEBUGUEAR-

        cadeteria.CargarListaCadete(listaCadetes);


    }

}