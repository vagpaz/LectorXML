using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class CfdiRelacionados
    {
        public CfdiRelacionados()
        {
            CfdiRelacionado = new CfdiRelacionado();
        }

        public CfdiRelacionado CfdiRelacionado { set; get; }

        public string TipoRelacion { set; get; }

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
                        CfdiRelacionado.Cargar(n.Attributes);
                        CfdiRelacionado.CargarNodos(n); //¿Quitar?
                        break;
                }
            }
        }
    }
}