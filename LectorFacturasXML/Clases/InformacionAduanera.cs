using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class InformacionAduanera
    {
        private string numero { get; set; }
        //Atributo requerido para expresar el número del documento aduanero que ampara la importación del bien
        private DateTime fecha { get; set; }
        //Atributo requerido para expresar la fecha de expedición del documento aduanero que ampara la importación del bien. Se expresa en el formato aaaa-mm-dd
        private string aduana { get; set; }
        //Atributo opcional para precisar el nombre de la aduana por la que se efectuó la importación del bien

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "numero":
                        numero = at.Value;
                        break;
                    case "fecha":
                        fecha = Convert.ToDateTime(at.Value);
                        break;
                    case "aduana":
                        aduana = at.Value;
                        break;
                }
            }
        }
    }
}