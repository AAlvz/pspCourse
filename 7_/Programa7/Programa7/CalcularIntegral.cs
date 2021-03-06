﻿//////////////////////////////////////////////
/// CLASE PARA CALCULAR INTEGRAL PROGRAMA 5
/// Programa No.    -> 5
/// *Descripcion.   -> Hace un calculo de intgral de cero a un limite. 
/// *Desarrollador. -> Alfonso Alvarez Sánchez
/// *Fecha.         -> 20 / 10 / 2011
/// Equipo          -> Individual
/// Notas           -> Calcula integral en ciertos parámetros.  
///////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa7
{
    class CalcularIntegral
    {
        //EMPIEZA METODO CALCULAR GAMMA
        public double Gamma(double numero) 
        {
            double acum;
            if (numero == 1 || numero <= 0)
            {
                bool esInt = numero % 1 == 0;
                if (esInt == true)
                {
                    acum = 1;
                }
                else {
                    acum = 1 * Math.Pow(Math.PI, .5);
                }
            }
            else 
            {
                double nuevoNum = numero - 1;
                acum = Gamma((nuevoNum));
                acum = acum * numero;
            }
            return acum;
        }
        //TERMINA METODO CALCULAR GAMMA

        //Empieza metodo cacluclar f(x)Primero
        public double fxPrimero(double dof)
        {
            double arriba = Gamma(((dof + 1) / 2)-1);
            double abajo = (Math.Pow((dof * Math.PI), 0.5)) * (Gamma((dof / 2)-1));
            double tot = arriba / abajo;
            return tot;
        }
        //TERMINA metodo cacluclar f(x)Primero

        //EMPIEZA METODO CALCULAR F(X)SEGUNDO
        public double fxSegundo(double dof, double x)
        {
            double bas = ((x*x)/dof) + 1;
            double tot = Math.Pow(bas, (-((dof+1)/2)));
            return tot;
        }
        //TEMINA METODO CALCULAR F(X)SEGUNDO

        //EMPIEZA METODO CALCULAR F(X)TOTAL
        public double fxTotal(double dof, double x)
        {
            double tot = ((fxPrimero(dof)) * (fxSegundo(dof, x)));
            return tot;
        }
        //TERMINA METODO CALCULAR F(X)TOTAL

        //EMPIEZA METODO SUMATORIA DE IMPARES
        public double sumatoriaDeImpares(double num_seg, double w, double dof)
        {
            double sum = 0;
            for(double j = 1; j <= (num_seg-1); j = j + 2)
            {
                double f = fxTotal(dof, (j*w));
                sum = sum + 4 * f * (w / 3);
            }
            return sum;
        }
        //TERMINA METODO SUMATORIA DE IMPARES

        //EMPIEZA METODO SUMATORIA DE PARES
        public double sumatoriaDePares(double num_seg, double w, double dof)
        {
            double sum = 0;
            for(double j = 2; j <= (num_seg-2); j = j + 2)
            {
                double f = fxTotal(dof, (j*w));
                sum = sum + 2*f*(w/3);
            }
            return sum;
        }
        //TERMINA METODO SUMATORIA DE PARES

        //EMPIEZA MEETODO CALCULAR TERMINOS
        public double Integra(double x, double num_seg, double dof)
        {
            double w = x / num_seg;
            double f0 = fxTotal(dof, 0);
            f0 = f0 * (w / 3);
            double pares = sumatoriaDePares(num_seg, w, dof);
            double impares = sumatoriaDeImpares(num_seg, w, dof);
            double fTot = fxTotal(dof, x);
            fTot = fTot * (w / 3);
            double sum = f0 + pares + impares + fTot;
            return sum;            
        }
        //TERMINA METODO CALCULAR TERMINOS
    }
}
