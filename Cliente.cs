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
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.RefDireccion = refDireccion;
    }

}