using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class Ubicacion
    {
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Referencia { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "calle":
                        Calle = at.Value;
                        break;
                    case "noExterior":
                        NoExterior = at.Value;
                        break;
                    case "noInterior":
                        NoInterior = at.Value;
                        break;
                    case "colonia":
                        Colonia = at.Value;
                        break;
                    case "localidad":
                        Localidad = at.Value;
                        break;
                    case "referencia":
                        Referencia = at.Value;
                        break;
                    case "municipio":
                        Municipio = at.Value;
                        break;
                    case "estado":
                        Estado = at.Value;
                        break;
                    case "pais":
                        Pais = at.Value;
                        break;
                    case "codigoPostal":
                        CodigoPostal = at.Value;
                        break;
                }
            }
        }
    }
}