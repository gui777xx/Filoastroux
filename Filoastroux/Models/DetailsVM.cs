namespace Filoastroux.Models;

public class DetailsVM
{
    public Astrologia Anterior { get; set; }
    public Astrologia Atual { get; set; }
    public Astrologia Proximo { get; set; }
    public List<Tipo> Tipos { get; set; }
}