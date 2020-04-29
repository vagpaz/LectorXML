using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo para la información detallada de una retención de impuesto específico.
    /// </summary>
    public class Retencion
    {
        public string Impuesto { set; get; } //Atributo requerido para señalar el tipo de impuesto retenido (IVA, ISR).
        public float Importe { set; get; } //Atributo requerido para señalar el importe o monto del impuesto retenido.

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "importe":
                        Importe = float.Parse(at.Value);
                        break;
                    case "impuesto":
                        Impuesto = at.Value;
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xRetencion)
        {
            foreach (XmlNode n in xRetencion)
            {
                switch (n.Name)
                {
                    case "cfdi:Retencion":
                        //this.impuesto.Cargar(n.Attributes);
                        //this.emisor.CargarNodos(n);
                        break;
                    case "cfdi:Traslados":
                        break;
                }
            }
        }
    }
}