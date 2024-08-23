public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedidos> listadoPedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listadoPedidos = listadoPedidos;
    }

    public void AgregarPedido(Pedidos pedido)
    {
        if (listadoPedidos == null)
        {
            listadoPedidos = new List<Pedidos>();
        }

        listadoPedidos.Add(pedido);
    }

    public void RemoverPedido(Pedidos pedido)
    {
        if (listadoPedidos != null)
        {
            listadoPedidos.Remove(pedido);
        }
    }



}