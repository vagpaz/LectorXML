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
            Impuestos = new Impuestos();
            InfoAduanera = new InformacionAduanera();
            CtaPredial = new CuentaPredial();
            CompConcepto = new ComplementoConcepto();
            Parte = new Parte();
        }

        private Impuestos Impuestos { get; set; }
        private InformacionAduanera InfoAduanera { get; set; }
        private CuentaPredial CtaPredial { get; set; }
        private ComplementoConcepto CompConcepto { get; set; }
        private Parte Parte { set; get; }



        //Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
        private string ClaveProdServ { set; get; }
        //Atributo opcional para expresar el número de serie del bien o identificador del servicio amparado por el presente concepto.
        private string NoIdentificacion { set; get; }
        //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
        private float Cantidad { set; get; }
        //Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
        private string ClaveUnidad { set; get; }
        //Atributo requerido para precisar la unidad de medida aplicable para la cantidad expresada en el concepto.
        private string Unidad { set; get; }
        //Atributo requerido para precisar la descripción del bien o servicio cubierto por el presente concepto.
        private string Descripcion { set; get; }
        //Atributo requerido para precisar el valor o precio unitario del bien o servicio cubierto por el presente concepto.
        private float ValorUnitario { set; get; }
        //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto.
        public float Importe { set; get; }
        //Atributo opcional para representar el importe de los descuentos aplicables al concepto. No se permiten valores negativos.
        public float Descuento { set; get; }
        


        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name.ToUpper())
                {
                    case "CLAVEPRODSERV":
                        ClaveProdServ = at.Value;
                        break;
                    case "NOIDENTIFICACION":
                        NoIdentificacion = at.Value;
                        break;
                    case "CANTIDAD":
                        Cantidad = float.Parse(at.Value);
                        break;
                    case "CLAVEUNIDAD":
                        ClaveUnidad = at.Value;
                        break;
                    case "UNIDAD":
                        Unidad = at.Value;
                        break;
                    case "DESCRIPCION":
                        Descripcion = at.Value;
                        break;
                    case "VALORUNITARIO":
                        ValorUnitario = float.Parse(at.Value);
                        break;
                    case "IMPORTE":
                        Importe = float.Parse(at.Value);
                        break;
                    case "DESCUENTO":
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xConcepto)
        {
            foreach (XmlNode n in xConcepto)
            {
                switch (n.Name.ToUpper())
                {
                    case "CFDI:IMPUESTOS":
                        Impuestos.Cargar(n.Attributes);
                        Impuestos.CargarNodos(n);   //No estan cargando, hay que pasarle los impuestos del concepto.
                        break;
                    case "CFDI:INFORMACIONADUANERA":
                        InfoAduanera.Cargar(n.Attributes);
                        InfoAduanera.CargarNodos(n);
                        break;
                    case "CUENTAPREDIAL":
                        CtaPredial.Cargar(n.Attributes);
                        CtaPredial.CargarNodos(n);
                        break;
                    case "COMPLEMENTOCONCEPTO":
                        CompConcepto.Cargar(n.Attributes);
                        CompConcepto.CargarNodos(n);
                        break;
                    case "PARTE":
                        Parte.Cargar(n.Attributes);
                        Parte.CargarNodos(n);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}