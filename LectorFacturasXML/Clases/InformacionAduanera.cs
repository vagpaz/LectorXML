using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class InformacionAduanera
    {
        private string NumeroPedimento { get; set; }
        //Atributo requerido para expresar el número del pedimento que ampara la importación del bien que se expresa en el siguiente formato: últimos 2 dígitos del año de validación seguidos por dos espacios, 2 dígitos de la aduana de despacho seguidos por dos espacios, 4 dígitos del número de la patente seguidos por dos espacios, 1 dígito que corresponde al último dígito del año en curso, salvo que se trate de un pedimento consolidado iniciado en el año inmediato anterior o del pedimento original de una rectificación, seguido de 6 dígitos de la numeración progresiva por aduana.

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name.ToUpper())
                {
                    case "NUMERO":
                        NumeroPedimento = at.Value;
                        break;
                    default:
                        break;
                }
            }
        }

        internal void CargarNodos(XmlNode n)
        {
            //No tiene nodos
            throw new NotImplementedException();
        }
    }
}