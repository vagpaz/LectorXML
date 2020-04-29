using System;
using System.Xml;

namespace LectorFacturasXML.Clases
{
    /// <summary>
    ///     Complemento requerido para el Timbrado Fiscal Digital que da valides a un Comprobante Fiscal Digital.
    /// </summary>
    public class TimbreFiscalDigital
    {
        public string SelloSat { set; get; }
        //Atributo requerido para contener el sello digital del Timbre Fiscal Digital, al que hacen referencia las reglas de resolución miscelánea aplicable. El sello deberá ser expresado cómo una cadena de texto en formato Base 64.
        public string NoCertificadoSat { set; get; }
        //Atributo requerido para expresar el número de serie del certificado del SAT usado para el Timbre.
        public string SelloCfd { set; get; }
        //Atributo requerido para contener el sello digital del comprobante fiscal, que será timbrado. El sello deberá ser expresado cómo una cadena de texto en formato Base 64.
        public DateTime FechaTimbrado { set; get; }
        //Atributo requerido para expresar la fecha y hora de la generación del timbre.
        public string Uuid { set; get; }
        //Atributo requerido para expresar los 36 caracteres del UUID de la transacción de timbrado.
        public string Version { set; get; }
        //Atributo requerido para la expresión de la versión del estándar del Timbre Fiscal Digital.

        public void Cargar(XmlAttributeCollection atributos)
        {
            foreach (XmlAttribute at in atributos)
            {
                switch (at.Name)
                {
                    case "version":
                        Version = at.Value;
                        break;
                    case "UUID":
                        Uuid = at.Value.ToUpper();
                        break;
                    case "FechaTimbrado":
                        FechaTimbrado = Convert.ToDateTime(at.Value);
                        break;
                    case "selloCFD":
                        SelloCfd = at.Value;
                        break;
                    case "noCertificadoSAT":
                        NoCertificadoSat = at.Value;
                        break;
                    case "selloSAT":
                        SelloSat = at.Value;
                        break;
                    case "x":
                        //this.totalImpuestosTrasladados = float.Parse(at.Value);
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