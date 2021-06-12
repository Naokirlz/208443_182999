using Negocio.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negocio.Utilidades
{

    public class FuenteLocal : Fuente
    {
      
        public string[] Breaches { get; set; }

        public FuenteLocal() {

            this.Id = Fuente.autonumerado;
            this.ttttttttt = new List<DataBreach>();
            Fuente.autonumerado++;

        }

        public  void Cargarttttttttt(string dtb, char separador)
        {
            
            //Breaches = dtb.Split('\n');
             Breaches = dtb.Split(separador);
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


                ttttttttt.Add(new DataBreach()
                {
                    FuenteId = this.Id,
                    Texto = texto,
                    Fuente = this
                }
                           );
            }



        }

        public override void CrearDatabreach(string texto)
        {

            Cargarttttttttt(texto, '\n');

            using (Contexto context = new Contexto())
            {
                
                context.FuentesLocales.Add(this);

               
                foreach (DataBreach item in ttttttttt)
                {
                    
                    context.DataBreaches.Add(item);
                    
                }

                context.SaveChanges();

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
