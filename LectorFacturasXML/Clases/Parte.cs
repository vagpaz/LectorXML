using System;
using System.Collections.Generic;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo opcional para expresar las partes o componentes que integran la totalidad del concepto expresado en el
    ///     comprobante fiscal digital a través de Internet.
    /// </summary>
    internal class Parte
    {
        public Parte()
        {
            infoAduanera = new List<InformacionAduanera>();
            infoAduanera = null;
        }

        private List<InformacionAduanera> infoAduanera { get; set; }

        //Atributo requerido para expresar la clave del producto o del servicio amparado por la presente parte. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.
        private string ClaveProdServ { set; get; }
        //Atributo opcional para expresar el número de serie, número de parte del bien o identificador del producto o del servicio amparado por la presente parte. Opcionalmente se puede utilizar claves del estándar GTIN.
        private string NoIdentificacion { set; get; }
        //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por la presente parte.
        private float Cantidad { set; get; }
        //Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en la parte. La unidad debe corresponder con la descripción de la parte.
        private string Unidad { set; get; }
        //Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte.
        private string Descripcion { set; get; }
        //Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte. No se permiten valores negativos.
        private float ValorUnitario { set; get; }
        //Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte. No se permiten valores negativos.
        private float Importe { set; get; }

        internal void Cargar(XmlAttributeCollection attributes)
        {
            foreach (XmlAttribute at in attributes)
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
                    default:
                        break;
                }
            }
        }

        internal void CargarNodos(XmlNode nParte)
        {
            //throw new NotImplementedException();

            foreach (XmlNode n in nParte)
            {
                if (n.Name.ToUpper().Contains("INFORMACIONADUANERA"))
                {
                    var nuevoInfoAduanera = new InformacionAduanera();
                    nuevoInfoAduanera.Cargar(n.Attributes);
                    nuevoInfoAduanera.CargarNodos(n);
                    infoAduanera.Add(nuevoInfoAduanera);
                }
            }

        }
        //Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte.
    }
}