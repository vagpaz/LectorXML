using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo para introducir la información detallada de un bien o servicio amparado en el comprobante.
    /// </summary>
    public class Concepto
    {
        public Concepto()
        {
            InfoAduanera = new InformacionAduanera();
            CtaPredial = new CuentaPredial();
            CompConcepto = new ComplementoConcepto();
            Parte = new Parte();
        }

        private InformacionAduanera InfoAduanera { get; set; }
        private CuentaPredial CtaPredial { get; set; }
        private ComplementoConcepto CompConcepto { get; set; }
        private Parte Parte { set; get; }

        private float Cantidad { set; get; }
        //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
        private string Unidad { set; get; }
        //Atributo requerido para precisar la unidad de medida aplicable para la cantidad expresada en el concepto.
        private string NoIdentificacion { set; get; }
        //Atributo opcional para expresar el número de serie del bien o identificador del servicio amparado por el presente concepto.
        private string Descripcion { set; get; }
        //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
        private float ValorUnitario { set; get; }
        //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
        public float Importe { set; get; }
        //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto.

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "Regimen":
                        //this.conceptos = at.Value;
                        break;
                    case "cantidad":
                        Cantidad = float.Parse(at.Value);
                        break;
                    case "unidad":
                        Unidad = at.Value;
                        break;
                    case "noIdentificacion":
                        NoIdentificacion = at.Value;
                        break;
                    case "descripcion":
                        Descripcion = at.Value;
                        break;
                    case "valorUnitario":
                        ValorUnitario = float.Parse(at.Value);
                        break;
                    case "importe":
                        Importe = float.Parse(at.Value);
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xConcepto)
        {
            foreach (XmlNode n in xConcepto)
            {
                switch (n.Name)
                {
                    case "cfdi:InformacionAduanera":
                        InfoAduanera.Cargar(n.Attributes);
                        break;
                    case "CuentaPredial":
                        break;
                    case "ComplementoConcepto":
                        break;
                    case "Parte":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}