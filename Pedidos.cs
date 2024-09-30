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

    public Pedidos(string nombre, string direccion, string telefono, string refDireccion)
    {
        this.cliente = new DatosCliente(nombre, direccion, telefono, refDireccion);
    }

    

}
