public class DatosCliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string refDireccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string RefDireccion { get => refDireccion; set => refDireccion = value; }

    public DatosCliente(string nombre, string direccion, string telefono, string refDireccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.refDireccion = refDireccion;
    }

    public DatosCliente() 
    {
        this.nombre = "Desconocido";
        this.direccion = "Sin dirección";
        this.telefono = "Sin teléfono";
        this.refDireccion = "Sin referencia";
    }

}