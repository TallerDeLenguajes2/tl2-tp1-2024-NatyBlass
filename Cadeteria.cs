using System.Runtime.CompilerServices;
using System.IO; // ESTO ME SIRVE PARA LEER ARCHIVOS Y PROCESARLOS
using System.Linq; 
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes = new List<Cadete>();
    public List<Cadete> ListadoCadetes { get => listadoCadetes;}

    //Este constructor lo hice con la lupita
    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
    }

    
}