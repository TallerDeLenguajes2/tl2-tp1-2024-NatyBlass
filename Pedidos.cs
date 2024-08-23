public class Pedidos
{
    public enum Estado
    {
        Preparacion,
        EnViaje,
        Entregado
    }

    private int nro;
    private string observacion;
    private Estado estado;
    private DatosCliente cliente;

    public int Nro { get => nro; set => nro = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Estado EstadoPedido { get => estado; set => estado = value; }
    public DatosCliente Cliente { get => cliente; set => cliente = value; }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"La direccion del cliente {cliente.Nombre} es {cliente.Direccion}");
    }

    public void verDatosDelCliente()
    {
        Console.WriteLine("=========DATOS DEL CLIENTE=========");
        Console.WriteLine($"Nombre: {cliente.Nombre}");
        Console.WriteLine($"Direccion: {cliente.Direccion}");
        Console.WriteLine($"Referencia: {cliente.RefDireccion}");
        Console.WriteLine($"Telefono: {cliente.Telefono}");
    }




}
