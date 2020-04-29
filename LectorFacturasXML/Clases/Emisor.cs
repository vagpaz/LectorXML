using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo requerido para precisar la información del contribuyente.
    /// </summary>
    public class Emisor
    {
        public Emisor(){}

        public string RegimenFiscal { set; get; }
        public string RFC { set; get; }
        public string Nombre { set; get; }


        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name.ToUpper())
                {
                    case "RFC":
                        RFC = at.Value;
                        break;
                    case "NOMBRE":
                        Nombre = at.Value;
                        break;
                    case "REGIMENFISCAL":
                        RegimenFiscal = at.Value;
                        break;
                }
            }
        }
    }
}