using System.Collections.Generic;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Traslados
    {
        private readonly List<Traslado> traslados;

        public Traslados()
        {
            traslados = new List<Traslado>();
        }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                if (at.Name.ToUpper().Contains("REGIMEN"))
                {
                    //this.conceptos = at.Value;
                }
            }
        }

        public void CargarNodos(XmlNode xTraslados)
        {
            foreach (XmlNode n in xTraslados)
            {
                if (n.Name.ToUpper().Contains("TRASLADO"))
                {
                    var nuevoTraslado = new Traslado();
                    nuevoTraslado.Cargar(n.Attributes);
                    nuevoTraslado.CargarNodos(n); //¿Quitar?
                    traslados.Add(nuevoTraslado);
                }
            }
        }
    }
}