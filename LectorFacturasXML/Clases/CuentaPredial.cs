using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{

    /// <summary>
    /// Nodo opcional para asentar el número de cuenta predial con el que fue registrado el inmueble, en el sistema catastral de la entidad federativa de que trate, o bien para incorporar los datos de identificación del certificado de participación inmobiliaria no amortizable.
    /// </summary>
    internal class CuentaPredial
    {
        //Atributo requerido para precisar el número de la cuenta predial del inmueble cubierto por el presente concepto, o bien para incorporar los datos de identificación del certificado de participación inmobiliaria no amortizable, tratándose de arrendamiento.
        private string Numero { set; get; }

        /// <summary>
        /// Asigna valor a los atributos de la clase CuentaPredial
        /// </summary>
        /// <param name="attributes"></param>
        internal void Cargar(XmlAttributeCollection attributes)
        {
            foreach (XmlAttribute at in attributes)
            {
                switch (at.Name)
                {
                    case "NUMERO":
                        Numero = at.Value;
                        break;
                }
            }
        }

        /// <summary>
        /// No implementado
        /// </summary>
        /// <param name="n"></param>
        internal void CargarNodos(XmlNode n)
        {
            //No tiene nodos
            throw new NotImplementedException();
            //foreach (XmlNode n in xConceptos)
            //{
            //    if (n.Name.ToUpper().Contains("CONCEPTO"))
            //    {
            //        var nuevoConcepto = new Concepto();
            //        nuevoConcepto.Cargar(n.Attributes);
            //        nuevoConcepto.CargarNodos(n);
            //        conceptos.Add(nuevoConcepto);
            //    }
            //}
        }
    }
}