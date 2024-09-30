public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int cantPedidosRealizados;
    private List<Pedidos> listadoPedidos = new List<Pedidos>(); //lo instancio acá

    public Cadete(int id, string nombre, string direccion, string telefono, int cantPedidosRealizados)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.cantPedidosRealizados = 0;
    }

    public string DatosDelCadete()
    {
        return $"ID: {this.id} - Nombre: {this.nombre} - Direccion: {this.direccion} - Telefono {this.telefono} - Cantidad de Pedidos: {this.cantPedidosRealizados}";
    }




}