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
}
