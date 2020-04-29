using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Comprobante
    {
        public Comprobante()
        {
            CfdiRelacionados = new CfdiRelacionados();
            Emisor = new Emisor();
            Receptor = new Receptor();
            Conceptos = new Conceptos();
            Impuestos = new Impuestos();
            Complemento = new Complemento();
            Addenda = new Addenda();
        }

        public CfdiRelacionados CfdiRelacionados { set; get; }
        public Emisor Emisor { set; get; }
        public Receptor Receptor { set; get; }
        public Conceptos Conceptos { set; get; }
        public Impuestos Impuestos { set; get; }
        public Complemento Complemento { set; get; }
        public Addenda Addenda { set; get; }

        public string Version { set; get; }
        public string Serie { set; get; }
        public string Folio { set; get; }
        public string Fecha { set; get; }
        public string Sello { set; get; }
        public string FormaDePago { set; get; }
        public string NoCertificado { set; get; }
        public string Certificado { set; get; }
        public string CondicionesDePago { set; get; }
        public string SubTotal { set; get; }
        public string Descuento { set; get; }
        public string MotivoDescuento { set; get; } //Ya no está
        public string Moneda { set; get; }
        public string TipoCambio { set; get; }
        public string Total { set; get; }
        public string TipoDeComprobante { set; get; }
        public string MetodoDePago { set; get; }
        public string LugarExpedicion { set; get; }
        public string Confirmacion { set; get; }
        public string NumCtaPago { set; get; }
        public string FolioFiscalOrig { set; get; }
        public string SerieFolioFiscalOrig { set; get; }
        public string FechaFolioFiscalOrig { set; get; }
        public string MontoFolioFiscalOrig { set; get; }
        public string FolioFiscar { get; set; }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name.ToUpper())
                {
                    case "VERSION":
                        Version = at.Value;
                        break;
                    case "SERIE":
                        Serie = at.Value;
                        break;
                    case "FOLIO":
                        Folio = at.Value;
                        break;
                    case "FECHA":
                        Fecha = at.Value;
                        break;
                    case "SELLO":
                        Sello = at.Value;
                        break;
                    case "FORMADEPAGO":
                        FormaDePago = at.Value;
                        break;
                    case "NOCERTIFICADO":
                        NoCertificado = at.Value;
                        break;
                    case "CERTIFICADO":
                        Certificado = at.Value;
                        break;
                    case "CONDICIONESDEPAGO":
                        CondicionesDePago = at.Value;
                        break;
                    case "SUBTOTAL":
                        SubTotal = at.Value;
                        break;
                    case "DESCUENTO":
                        Descuento = at.Value;
                        break;
                    case "MOTIVODESCUENTO":
                        MotivoDescuento = at.Value;
                        break;
                    case "TIPOCAMBIO":
                        TipoCambio = at.Value;
                        break;
                    case "MONEDA":
                        Moneda = at.Value;
                        break;
                    case "TOTAL":
                        Total = at.Value;
                        break;
                    case "TIPODECOMPROBANTE":
                        TipoDeComprobante = at.Value;
                        break;
                    case "METODODEPAGO":
                        MetodoDePago = at.Value;
                        break;
                    case "LUGAREXPEDICION":
                        LugarExpedicion = at.Value;
                        break;
                    case "NUMCTAPAGO":
                        NumCtaPago = at.Value;
                        break;
                    case "FOLIOFISCALORIG":
                        FolioFiscalOrig = at.Value;
                        break;
                    case "SERIEFOLIOFISCALORIG":
                        SerieFolioFiscalOrig = at.Value;
                        break;
                    case "FECHAFOLIOFISCALORIG":
                        FechaFolioFiscalOrig = at.Value;
                        break;
                    case "MONTOFOLIOFISCALORIG":
                        MontoFolioFiscalOrig = at.Value;
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xComprobante)
        {
            foreach (XmlNode n in xComprobante)
            {
                if (n.Name.ToUpper().Contains("EMISOR"))
                {
                    Emisor.Cargar(n.Attributes);
                }
                else if (n.Name.ToUpper().Contains("RECEPTOR"))
                {
                    Receptor.Cargar(n.Attributes);
                }
                else if (n.Name.ToUpper().Contains("CONCEPTOS"))
                {
                    Conceptos.Cargar(n.Attributes);
                    Conceptos.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("IMPUESTOS"))
                {
                    Impuestos.Cargar(n.Attributes);
                    Impuestos.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("COMPLEMENTO"))
                {
                    Complemento.Cargar(n.Attributes);
                    Complemento.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("ADDENDA"))
                {
                }
            }
        }
    }
}