using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    public class CfdiRelacionado
    {
        public CfdiRelacionado()
        {
        }
        public string UUID { set; get; }

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {

                    case "UUID":
                        UUID = at.Value.ToUpper();
                        break;
                }
            }
        }

        public void CargarNodos(XmlNode xTimbre)
        {
            foreach (XmlNode n in xTimbre)
            {
                switch (n.Name)
                {
                    case "cfdi:Retenciones":
                        //this.retenciones.Cargar(n.Attributes);  //¿Quitar?
                        //this.retenciones.CargarNodos(n);
                        break;
                    case "cfdi:Traslados":
                        //this.traslados.Cargar(n.Attributes); //¿Quitar?
                        //this.traslados.CargarNodos(n);
                        break;
                }
            }
        }
    }
}