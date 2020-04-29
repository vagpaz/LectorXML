using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class RegimenFiscal
    {
        public string regimenFiscal;

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                if (at.Name == "Regimen")
                    regimenFiscal = at.Value;
            }
        }
    }
}