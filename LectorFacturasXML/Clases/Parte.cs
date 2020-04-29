using System.Collections.Generic;

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

        private float cantidad { set; get; }
        //Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por la presente parte.
        private string unidad { set; get; }
        //Atributo opcional para precisar la unidad de medida aplicable para la cantidad expresada en la parte.
        private string noIdentificacion { set; get; }
        //Atributo opcional para expresar el número de serie del bien o identificador del servicio amparado por la presente parte.
        private string descripcion { set; get; }
        //Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte.
        private float valorUnitario { set; get; }
        //Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte.
        private float importe { set; get; }
        //Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte.
    }
}