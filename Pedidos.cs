public class Pedidos
{
    public enum Estado
    {
        Preparacion,
        EnViaje,
        Entregado,
        Cancelado
    }

    private int nro;
    private string observacion;
    private Estado estado;
    private DatosCliente cliente;

    public int Nro { get => nro; set => nro = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Estado Estado1 { get => estado; set => estado = value; }
    public DatosCliente Cliente { get => cliente; set => cliente = value; }

    public Pedidos(int nro, string observacion, DatosCliente cliente, Estado estado)
    {
        this.nro = nro;
        this.observacion = observacion;
        this.Cliente = cliente;
        this.Estado1 = estado;

    }

    public void CambiarEstadoDelPedido(Estado nuevoEstado)
    {
        this.Estado1 =  nuevoEstado;
    }
    



}
