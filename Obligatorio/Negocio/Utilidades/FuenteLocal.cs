using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio.Utilidades
{

    public class FuenteLocal : Fuente
    {
      
        public FuenteLocal() {

            this.Id = Fuente.autonumerado;
            Fuente.autonumerado++;

        }

        public override void CrearDatabreach(string databreach)
        {
            IList<DataBreach> textos = new List<DataBreach>();

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
                

                textos.Add(new DataBreach()
                                {
                                    FuenteId = this.Id,
                                    Texto = texto,
                                    Fuente = this
                                }
                           );
            }

            using (Contexto context = new Contexto())
            {
                
                context.FuentesLocales.Add(this);

               
                foreach (DataBreach item in textos)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Unchanged;
                    context.DataBreaches.Add(item);
                    context.SaveChanges();
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
