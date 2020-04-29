using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo requerido para capturar los impuestos aplicables.
    /// </summary>
    public class Impuestos
    {
        public Impuestos()
        {
            retenciones = new Retenciones();
            traslados = new Traslados();
        }

        public Retenciones retenciones { get; set; }
        public Traslados traslados { get; set; }
        public float totalImpuestosRetenidos { set; get; }
        //Atributo opcional para expresar el total de los impuestos retenidos que se desprenden de los conceptos expresados en el comprobante fiscal digital a través de Internet.
        public float totalImpuestosTrasladados { set; get; }
        //Atributo opcional para expresar el total de los impuestos trasladados que se desprenden de los conceptos expresados en el comprobante fiscal digital a través de Internet.

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "totalImpuestosRetenidos":
                        totalImpuestosRetenidos = float.Parse(at.Value);
                        break;
                    case "totalImpuestosTrasladados":
                        totalImpuestosTrasladados = float.Parse(at.Value);
                        break;
                    default:
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xImpuestos)
        {
            foreach (XmlNode n in xImpuestos)
            {
                if (n.Name.ToUpper().Contains("RETENCIONES"))
                {
                    retenciones.Cargar(n.Attributes); //¿Quitar?
                    retenciones.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("TRASLADO"))
                {
                    traslados.Cargar(n.Attributes); //¿Quitar?
                    traslados.CargarNodos(n);
                }
            }
        }
    }
}