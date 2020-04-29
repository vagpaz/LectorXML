using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Impuesto
    {
        public Impuesto()
        { }

        public float Base { get; set; }
        public string c_Impuesto { get; set; }
        public string c_TipoFactor { get; set; }
        public string TasaOCuota { get; set; }
        public float t_Importe { get; set; }
        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name.ToUpper())
                {
                    case "BASE":
                        Base = float.Parse(at.Value);
                        break;
                    case "IMPUESTO":
                        c_Impuesto = at.Value;
                        break;
                    case "TIPOFACTOR":
                        c_TipoFactor = at.Value;
                        break;
                    case "TASAOCUOTA":
                        TasaOCuota = at.Value;
                        break;
                    case "IMPORTE":
                        t_Importe= float.Parse(at.Value);
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
