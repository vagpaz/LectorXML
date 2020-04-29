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
            Retenciones = new Retenciones();
            Traslados = new Traslados();
        }

        public Retenciones Retenciones { get; set; }
        public Traslados Traslados { get; set; }
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
                    case "TotalImpuestosRetenidos":
                        totalImpuestosRetenidos = float.Parse(at.Value);
                        break;
                    case "TotalImpuestosTrasladados":
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
                    Retenciones.Cargar(n.Attributes); //¿Quitar?
                    Retenciones.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("TRASLADO"))
                {
                    Traslados.Cargar(n.Attributes); //¿Quitar?
                    Traslados.CargarNodos(n);
                }
            }
        }
    }
}