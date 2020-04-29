using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Nodo opcional donde se incluyen los nodos complementarios de extensión al concepto definidos por el SAT, de 
    ///     acuerdo con las disposiciones particulares para un sector o actividad específica.
    /// </summary>
    internal class ComplementoConcepto
    {
        /// <summary>
        /// No implementado
        /// </summary>
        /// <param name="attributes"></param>
        internal void Cargar(XmlAttributeCollection attributes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// No implementado
        /// </summary>
        /// <param name="n"></param>
        internal void CargarNodos(XmlNode n)
        {
            throw new NotImplementedException();
        }
    }
}