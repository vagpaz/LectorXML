using System.Collections.Generic;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo requerido para enlistar los conceptos cubiertos por el comprobante.
    /// </summary>
    public class Conceptos
    {
        public List<Concepto> conceptos;

        public Conceptos()
        {
            conceptos = new List<Concepto>();
        }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "Regimen":
                        //this.conceptos = at.Value;
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xConceptos)
        {
            foreach (XmlNode n in xConceptos)
            {
                if (n.Name.ToUpper().Contains("CONCEPTO"))
                {
                    var nuevoConcepto = new Concepto();
                    nuevoConcepto.Cargar(n.Attributes);
                    nuevoConcepto.CargarNodos(n);
                    conceptos.Add(nuevoConcepto);
                }
            }
        }


        //Constructor
    }
}