using System.IO;
using System.Text.Json;
public abstract class AccesoADatos
{
    public abstract Cadeteria CargarDatosCadeteria(string nomArchivo);
    public abstract List<Cadete> CargarDatosCadetes(string nomArchivo);
}

public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarDatosCadeteria(string nomArchivo)
    {
        Cadeteria cadeteria = null;

        string[] lineas = File.ReadAllLines(nomArchivo);
        string[] datosCad = lineas[1].Split(',');

        cadeteria = new Cadeteria(datosCad[0], datosCad[1]); 

        return cadeteria;
    }

    public override List<Cadete> CargarDatosCadetes(string nomArchivo)
    {
        List<Cadete> listaCadetes = new List<Cadete>();

        string[] lineas = File.ReadAllLines(nomArchivo);

        foreach(string linea in lineas.Skip(1)) //skip salta un numero especifico de elementos
        {
            string[] dato = linea.Split(',');
            Cadete cadete = new Cadete(
                int.Parse(dato[0]),
                dato[1],
                dato[2],
                dato[3]
            );

            listaCadetes.Add(cadete);
        }

        return listaCadetes;
    }
}

public class AccesoJson : AccesoADatos
{
    public override Cadeteria CargarDatosCadeteria(string nomArchivo)
    {
        string json = File.ReadAllText(nomArchivo);

        return JsonSerializer.Deserialize<Cadeteria>(json);
    }

    public override List<Cadete> CargarDatosCadetes(string nomArchivo)
    {
        string json = File.ReadAllText(nomArchivo);
        return JsonSerializer.Deserialize<List<Cadete>>(json);
    }
}