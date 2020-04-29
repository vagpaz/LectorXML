using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo opcional para asentar o referir los impuestos trasladados aplicables.
    /// </summary>
    public class Traslado
    {
        public string impuesto { set; get; }
        // Atributo requerido para señalar el tipo de impuesto trasladado (IVA, IEPS)
        public float tasa { set; get; }
        //Atributo requerido para señalar la tasa del impuesto que se traslada por cada concepto amparado en el comprobante
        public float importe { set; get; } //Atributo requerido para señalar el importe del impuesto trasladado


        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "importe":
                        importe = float.Parse(at.Value);
                        break;
                    case "impuesto":
                        impuesto = at.Value;
                        break;
                    case "tasa":
                        tasa = float.Parse(at.Value);
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
                    default:
                        break;
                }
            }
        }
    }
}