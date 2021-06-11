using Negocio.Persistencia;
using System;
using System.Collections.Generic;

namespace Negocio.Utilidades
{
    public class FuenteLocal : Fuente
    {
        public FuenteLocal() { }

        public override void CrearDatabreach(string databreach)
        {

            Breaches = databreach.Split('\n');

            foreach (string fila in Breaches)
            {
                string texto = fila.TrimEnd('\r');

                string sinEspacios = texto.Replace(" ", "");
                bool soloNum = true;
                foreach (char digito in sinEspacios)
                {
                    if (!Validaciones.EsNumero(digito)) soloNum = false;
                }
                if (soloNum) texto = sinEspacios;
            }

            using (Contexto context = new Contexto())
            {
                context.DataBreaches.Add(this);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        //public int BuscarPasswordOContraseniaEnFuente(string buscado)
        //{
        //    int cantidadAparaceEnFuente = 0;
        //    foreach (var item in contraseniasYTarjetasVulnerables)
        //    {
        //        if (item.Equals(buscado)) cantidadAparaceEnFuente++;
        //    }
        //    return cantidadAparaceEnFuente;
        //}

        //public void AgregarPasswordOContraseniaVulnerable(string passwordOContraseniaVulnerable)
        //{
        //    if(passwordOContraseniaVulnerable.Length > 50) 
        //    {
        //        throw new ExcepcionLargoTexto("El largo de texto debe ser menor a 50 caracteres.");
        //    }
        //    contraseniasYTarjetasVulnerables.Add(passwordOContraseniaVulnerable);
        //}


    }
}
