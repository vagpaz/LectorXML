using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Complemento
    {
        public Complemento()
        {
            Timbre = new TimbreFiscalDigital();
        }

        public TimbreFiscalDigital Timbre { set; get; }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
                switch (at.Name)
                {
                    case "cantidad":
                        //this.cantidad = float.Parse(at.Value);
                        break;
                }
        }

        public void CargarNodos(XmlNode xComplemento)
        {
            foreach (XmlNode n in xComplemento)
            {
                switch (n.Name)
                {
                    case "tfd:TimbreFiscalDigital":
                        Timbre.Cargar(n.Attributes);
                        Timbre.CargarNodos(n); //¿Quitar?
                        break;
                }
            }
        }
    }
}