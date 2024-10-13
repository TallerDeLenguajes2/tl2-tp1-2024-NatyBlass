public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private int cantPedidosRealizados;
    private List<Pedidos> listadoPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int CantPedidosRealizados { get => cantPedidosRealizados; set => cantPedidosRealizados = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadete(int id, string nombre, string direccion, string telefono, int cantPedidosRealizados)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.CantPedidosRealizados = 0;
        this.ListadoPedidos = new List<Pedidos>();
    }


    public void agregarPedido(Pedidos pedido)
    {
        ListadoPedidos.Add(pedido);
    }

    public void eliminarPedido(Pedidos pedido)
    {
        ListadoPedidos.Remove(pedido);
    }

    public void cambiarEstadoPedido(int nroPedido, Pedidos.Estado nuevoEstado)
    {
        var pedido = ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
        
        if (pedido != null && pedido.Estado1 != Pedidos.Estado.Entregado)
        {
            pedido.Estado1 = nuevoEstado;
        }
        else
        {
            Console.WriteLine("Su pedido no existe o ya fue entregado.");
        }
    }

    public int GananciaDia()
    {
        int costoEnvio = 500;
        int cantPedidos = ListadoPedidos.Count();
        int ganancia = cantPedidos * costoEnvio;

        return ganancia;
    }

    





}