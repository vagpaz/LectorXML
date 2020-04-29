using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo requerido para precisar la información del contribuyente.
    /// </summary>
    public class Contribuyente
    {
        public Contribuyente()
        {
            Domicilio = new Ubicacion();
            ExpedidoEn = new Ubicacion();
            RegimenFiscal = new RegimenFiscal();
        }

        public Ubicacion Domicilio { set; get; }
        public Ubicacion ExpedidoEn { get; set; }
        public RegimenFiscal RegimenFiscal { set; get; }
        public string RFC { set; get; }
        public string Nombre { set; get; }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "rfc":
                        RFC = at.Value;
                        break;
                    case "nombre":
                        Nombre = at.Value;
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xEmisor)
        {
            foreach (XmlNode n in xEmisor)
            {
                if (n.Name.ToUpper().Contains("DOMICILIO"))
                    Domicilio.Cargar(n.Attributes);
                else if (n.Name.ToUpper().Contains("EXPEDIDO"))
                    ExpedidoEn.Cargar(n.Attributes);
                else if (n.Name.ToUpper().Contains("REGIMENFISCAL"))
                    RegimenFiscal.Cargar(n.Attributes);
            }
        }
    }
}