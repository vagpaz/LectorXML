using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo requerido para precisar la información del contribuyente.
    /// </summary>
    public class Receptor
    {
        public Receptor() { }

        public Ubicacion Domicilio { set; get; }
        public Ubicacion ExpedidoEn { get; set; }       
        public string RFC { set; get; }
        public string Nombre { set; get; }
        public string ResidenciaFiscal { get; set; }
        public string NumRegIdTrib { get; set; }
        public string UsoCFDI { get; set; }

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
                    case "RESIDENCIAFISCAL":
                        ResidenciaFiscal = at.Value;
                        break;
                    case "NUMREGIDTRIB":
                        NumRegIdTrib = at.Value;
                        break;
                    case "USOCFDI":
                        UsoCFDI = at.Value;
                        break;
                }
            }
        }
    }
}