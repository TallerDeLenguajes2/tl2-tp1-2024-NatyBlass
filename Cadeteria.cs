public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes1 { get => ListadoCadetes; set => ListadoCadetes = value; }


    //Este constructor lo hice con la lupita
    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        ListadoCadetes = listadoCadetes;
    }
}