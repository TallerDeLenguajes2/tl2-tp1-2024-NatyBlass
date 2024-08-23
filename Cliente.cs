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
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        RefDireccion = refDireccion;
    }

    public DatosCliente() 
    {
        Nombre = "Desconocido";
        Direccion = "Sin dirección";
        Telefono = "Sin teléfono";
        RefDireccion = "Sin referencia";
    }

}