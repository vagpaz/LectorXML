using System.Collections.Generic;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Retenciones
    {
        private readonly List<Retencion> retenciones;

        public Retenciones()
        {
            retenciones = new List<Retencion>();
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
                    default:
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xRetenciones)
        {
            foreach (XmlNode n in xRetenciones)
            {
                switch (n.Name)
                {
                    case "cfdi:Retencion":
                        var nuevoRetencion = new Retencion();
                        nuevoRetencion.Cargar(n.Attributes);
                        nuevoRetencion.CargarNodos(n); // ¿Quitar?
                        retenciones.Add(nuevoRetencion);
                        break;
                }
            }
        }
    }
}