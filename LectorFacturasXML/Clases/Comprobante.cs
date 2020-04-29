using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Comprobante
    {
        public Comprobante()
        {
            Emisor = new Contribuyente();
            Receptor = new Contribuyente();
            Conceptos = new Conceptos();
            Impuestos = new Impuestos();
            Complemento = new Complemento();
        }

        public Contribuyente Emisor { set; get; }
        public Contribuyente Receptor { set; get; }
        public Conceptos Conceptos { set; get; }
        public Impuestos Impuestos { set; get; }
        public Complemento Complemento { set; get; }

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
        public string MotivoDescuento { set; get; }
        public string TipoCambio { set; get; }
        public string Moneda { set; get; }
        public string Total { set; get; }
        public string TipoDeComprobante { set; get; }
        public string MetodoDePago { set; get; }
        public string LugarExpedicion { set; get; }
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
                switch (at.Name)
                {
                    case "version":
                        Version = at.Value;
                        break;
                    case "serie":
                        Serie = at.Value;
                        break;
                    case "folio":
                        Folio = at.Value;
                        break;
                    case "fecha":
                        Fecha = at.Value;
                        break;
                    case "sello":
                        Sello = at.Value;
                        break;
                    case "formaDePago":
                        FormaDePago = at.Value;
                        break;
                    case "noCertificado":
                        NoCertificado = at.Value;
                        break;
                    case "certificado":
                        Certificado = at.Value;
                        break;
                    case "condicionesDePago":
                        CondicionesDePago = at.Value;
                        break;
                    case "subTotal":
                        SubTotal = at.Value;
                        break;
                    case "descuento":
                        Descuento = at.Value;
                        break;
                    case "motivoDescuento":
                        MotivoDescuento = at.Value;
                        break;
                    case "TipoCambio":
                        TipoCambio = at.Value;
                        break;
                    case "Moneda":
                        Moneda = at.Value;
                        break;
                    case "total":
                        Total = at.Value;
                        break;
                    case "tipoDeComprobante":
                        TipoDeComprobante = at.Value;
                        break;
                    case "metodoDePago":
                        MetodoDePago = at.Value;
                        break;
                    case "LugarExpedicion":
                        LugarExpedicion = at.Value;
                        break;
                    case "NumCtaPago":
                        NumCtaPago = at.Value;
                        break;
                    case "FolioFiscalOrig":
                        FolioFiscalOrig = at.Value;
                        break;
                    case "SerieFolioFiscalOrig":
                        SerieFolioFiscalOrig = at.Value;
                        break;
                    case "FechaFolioFiscalOrig":
                        FechaFolioFiscalOrig = at.Value;
                        break;
                    case "MontoFolioFiscalOrig":
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
                    Emisor.CargarNodos(n);
                }
                else if (n.Name.ToUpper().Contains("RECEPTOR"))
                {
                    Receptor.Cargar(n.Attributes);
                    Receptor.CargarNodos(n);
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