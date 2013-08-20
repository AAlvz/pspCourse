using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa7
{
    class Program
    {
        static void Main(string[] args)
        {
            //PUREBAS
            //Crear cada lista para cada datos
            List<double> DatosProxy = new List<double>();
            List<double> DatosPlan = new List<double>();
            List<double> DatosActual = new List<double>();
            List<double> DatosHoras = new List<double>();
            //Asignar el primer valor como null a cada lsita
            //Datos del Proxy
            DatosProxy.Add(130);
            DatosProxy.Add(650);
            DatosProxy.Add(99);
            DatosProxy.Add(150);
            DatosProxy.Add(128);
            DatosProxy.Add(302);
            DatosProxy.Add(95);
            DatosProxy.Add(945);
            DatosProxy.Add(368);
            DatosProxy.Add(961);
            //Datos de Planeadas
            DatosPlan.Add(163);
            DatosPlan.Add(765);
            DatosPlan.Add(141);
            DatosPlan.Add(166);
            DatosPlan.Add(137);
            DatosPlan.Add(355);
            DatosPlan.Add(136);
            DatosPlan.Add(1206);
            DatosPlan.Add(433);
            DatosPlan.Add(1130);
            //datos de Actuales
            DatosActual.Add(186);
            DatosActual.Add(699);
            DatosActual.Add(132);
            DatosActual.Add(272);
            DatosActual.Add(291);
            DatosActual.Add(331);
            DatosActual.Add(199);
            DatosActual.Add(1890);
            DatosActual.Add(788);
            DatosActual.Add(1601);
            //Datosde Horas
            DatosHoras.Add(15.0);
            DatosHoras.Add(69.9);
            DatosHoras.Add(6.5);
            DatosHoras.Add(22.4);
            DatosHoras.Add(28.4);
            DatosHoras.Add(65.9);
            DatosHoras.Add(19.4);
            DatosHoras.Add(198.7);
            DatosHoras.Add(38.8);
            DatosHoras.Add(138.2);

            Funciones F = new Funciones();
            double Correlacion = F.obtenerCorrelacion(DatosProxy, DatosActual);
            Console.WriteLine("Correlaci�n: " + Correlacion);
            Console.WriteLine("Correlaci�n cuadrada: " + Math.Pow(Correlacion, 2));
            double X = F.calcularX(DatosProxy, DatosActual);
            double cola = F.calcularCola(X, DatosProxy.Count);
            Console.WriteLine("Cola: " + "{0:#.#####e+00}", cola);
            double B0 = F.obtenerBeta0(DatosProxy, DatosActual);
            Console.WriteLine("Beta0: " + B0);
            double B1 = F.obtenerBeta1(DatosProxy, DatosActual);
            Console.WriteLine("Beta1: " + B1);
            double Yk = F.calcularYk(386, DatosProxy, DatosActual);
            Console.WriteLine("Yk: " + Yk);
            double Rango = F.calcularRango(386, (DatosProxy.Count - 2), DatosProxy, DatosActual);
            Console.WriteLine("Rango: " + Rango);
            double UPI = F.calcularUPI(386, DatosProxy, DatosActual, (DatosProxy.Count - 2));
            Console.WriteLine("UPI: " + UPI);
            double LPI = F.calcularLPI(386, DatosProxy, DatosActual, (DatosProxy.Count - 2));
            Console.WriteLine("LPI: " + LPI);
            Console.ReadLine();

            double Correlacion2 = F.obtenerCorrelacion(DatosProxy, DatosHoras);
            Console.WriteLine("Correlaci�n: " + Correlacion2);
            Console.WriteLine("Correlaci�n cuadrada: " + Math.Pow(Correlacion2, 2));
            double X2 = F.calcularX(DatosProxy, DatosHoras);
            double cola2 = F.calcularCola(X2, DatosProxy.Count);
            Console.WriteLine("Cola: " + "{0:#.#####e+00}", cola2);
            double B02 = F.obtenerBeta0(DatosProxy, DatosHoras);
            Console.WriteLine("Beta0: " + B02);
            double B12 = F.obtenerBeta1(DatosProxy, DatosHoras);
            Console.WriteLine("Beta1: " + B12);
            double Yk2 = F.calcularYk(386, DatosProxy, DatosHoras);
            Console.WriteLine("Yk: " + Yk2);
            double Rango2 = F.calcularRango(386, (DatosProxy.Count - 2), DatosProxy, DatosHoras);
            Console.WriteLine("Rango: " + Rango2);
            double UPI2 = F.calcularUPI(386, DatosProxy, DatosHoras, (DatosProxy.Count - 2));
            Console.WriteLine("UPI: " + UPI2);
            double LPI2 = F.calcularLPI(386, DatosProxy, DatosHoras, (DatosProxy.Count - 2));
            Console.WriteLine("LPI: " + LPI2);
            Console.ReadLine();
            //FIN PRUEBAS
        }
    }
}
//////////////////////////////////////////////
/// CLASE PARA ENCONTRAR X DE UNA INTEGRAL
/// Programa No.    -> 6
/// *Descripcion.   -> Encuentra la X necesaria del resultado de una integral 
/// *Desarrollador. -> Alfonso Alvarez S�nchez
/// *Fecha.         -> 28 / 10 / 2011
/// Equipo          -> Individual
/// Notas           -> Calcula la x en una integral  
///////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa7
{
    class EncontrarXdeIntegral
    {
        //EMPIEZA METODO OBTENERX
        //public double terminos(double x, double num_seg, double dof)
        public double obtenerX(double pBusc, double dof)
        {
            CalcularIntegral C = new CalcularIntegral();
            double x = 1;
            double var = .5;
            double num_seg = 10;
            double p = C.Integra(x, num_seg, dof);
            //while ((p - .00001) != pBusc || (p + .00001) != pBusc || c < 20)
            while (Math.Round(p, 5) != pBusc)
            {
                while(p < pBusc)
                {
                    x = x + var;
                    p = C.Integra(x, num_seg, dof);
                }
                if(p > pBusc)
                {
                    var = var/2;
                    while(p > pBusc)
                    {
                        x = x - var;
                        p = C.Integra(x, num_seg, dof);
                    }
                    var = var/2;
                }else
                {
                    var = var/2;
                }
                
            }
            return Math.Round(x, 5);
        }
        //TERMINA METODO OBTENERX
        
    }
}
//////////////////////////////////////////////
/// CLASE PARA CALCULAR INTEGRAL PROGRAMA 5
/// Programa No.    -> 5
/// *Descripcion.   -> Hace un calculo de intgral de cero a un limite. 
/// *Desarrollador. -> Alfonso Alvarez S�nchez
/// *Fecha.         -> 20 / 10 / 2011
/// Equipo          -> Individual
/// Notas           -> Calcula integral en ciertos par�metros.  
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
            if (numero == 1 || numero < 0)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa7
{
    class Funciones
    {
        //EMPIEZA METODO OBTENER BETA0
        public double obtenerBeta0(List<double> DatosX, List<double> DatosY)
        {
            double dato1 = DatosY.Average(); //promedio de variables en la lista de DatosY
            double dato2 = ((obtenerBeta1(DatosX, DatosY)) * DatosX.Average());
            double beta0 = dato1 - dato2;
            return beta0;
        }
        //TERMINA METODO OBTENER BETA0

        // EMPIEZA METODO OBTENER BETA1
        public double obtenerBeta1(List<double> DatosX, List<double> DatosY)
        {
            double dato1 = sumaDeMultiplicacion(DatosX, DatosY);
            double dato2 = ((DatosX.Count) * (DatosX.Average() * DatosY.Average()));
            double dato3 = sumatoriaCuadrada(DatosX);
            double dato4 = (Math.Pow(DatosX.Average(), 2) * DatosX.Count);
            double beta1 = ((dato1 - dato2) / (dato3 - dato4));
            return beta1;
        }
        // TERMINA METODO OBTENER BETA1

        // EMPIEZA METODO SUMATORIA DE MULTIPLICACION
        public double sumaDeMultiplicacion(List<double> DatosX, List<double> DatosY)
        {
            double c = 0;
            for (int i = 0; i < DatosX.Count; i++)
            {
                c = c + (DatosX[i] * DatosY[i]);
            }
            return c;
        }
        // TERMINA METODO SUMATORIA DE MULTIPLICACION

        //EMPIEZA METODO SUMATORIA CUADRADA
        public double sumatoriaCuadrada(List<double> lst)
        {
            double c = 0;
            int i = 0;
            //while (lst[i+1] != null)
            while(i < lst.Count)
            {
                c = c + (Math.Pow(lst[i], 2));
                i++;
            }
            //c = c + (Math.Pow(lst[i], 2));
            return c;
        }
        //TERMINA METODO SUMATORIA CUADRADA

        //EMPIEZA METODO CALCULAR YK
        public double calcularYk(double Xk, List<double> DatosX, List<double> DatosY) 
        {
            return (obtenerBeta0(DatosX, DatosY) + (obtenerBeta1(DatosX, DatosY) * Xk));
        }
        //TERMINA METODO CALCULAR YK

        //EMPIEZA METODO CALCULAR COLA
        public double calcularCola(double x, double numeroDeDatos) //esta x se calcula con calcular X
        {
            CalcularIntegral C = new CalcularIntegral();
            double valorP = C.Integra(x, 10, numeroDeDatos - 2);
            double cola = (1 - (2 * valorP));
            return cola;
        }
        //TERMINA METODO CALCULAR COLA

        //EMPIEZA METODO OBTENER CORRELACION
        public double obtenerCorrelacion(List<double> DatosX, List<double> DatosY)
        {
            double dato1 = ((sumaDeMultiplicacion(DatosX, DatosY)) * DatosX.Count);
            double dato2 = (DatosX.Sum() * DatosY.Sum());
            double dato3 = ((DatosX.Count * (sumatoriaCuadrada(DatosX))) - (Math.Pow(DatosX.Sum(), 2)));
            double dato4 = ((DatosY.Count * (sumatoriaCuadrada(DatosY))) - (Math.Pow(DatosY.Sum(), 2)));
            double dato5 = dato1 - dato2;
            double dato6 = Math.Sqrt(dato3 * dato4);
            double correlacion = dato5 / dato6;
            return correlacion;
        }
        //TERMINA METODO OBTENER CORRELACION

        //EMPIEZA METODO CALCULAR DESVIACION ESTANDAR
        public double calcularDesvEstandar(List<double> DatosX, List<double> DatosY)
        {
            double sumatoria = 0;
            double Beta0 = obtenerBeta0(DatosX, DatosY);
            double Beta1 = obtenerBeta1(DatosX, DatosY);
            double cantidad = DatosX.Count;
            for (int j = 0; j < cantidad; j++)
            {
                sumatoria = sumatoria + Math.Pow((DatosY[j] - Beta0 - (Beta1*DatosX[j])), 2);
            }
            double desviacion = Math.Sqrt((sumatoria / (DatosX.Count - 2)));

            return desviacion;
        }
        //TERMINA METODO CALCULARDESVIACIONESTANDAR

        //EMPIEZA METODO CALCULAR X
        public double calcularX(List<double> DatosX, List<double> DatosY)
        {
            double dato1 = Math.Abs(obtenerCorrelacion(DatosX, DatosY));
            double dato2 = Math.Sqrt((DatosX.Count - 2));
            double dato3 = Math.Pow(dato1, 2);
            double dato4 = Math.Sqrt(1-dato3);
            double x = (dato1*dato2)/(dato4);
            return x;
        }
        //TERMINA METODO CALCULAR X

        //EMPIEZA METODO CALCULAR RANGO
        public double calcularRango(double Xk, double dof, List<double> DatosX, List<double> DatosY)
        {
            EncontrarXdeIntegral Ex = new EncontrarXdeIntegral();
            double numeroDeDatos = Convert.ToDouble(DatosX.Count);
            double dato1 = Ex.obtenerX(.35, (numeroDeDatos - 2));
            double dato2 = calcularDesvEstandar(DatosX, DatosY);
            double XProm = DatosX.Average();
            double var1 = Math.Pow((Xk -XProm), 2);
            double var2 = 0;
            for(int i = 0; i < numeroDeDatos; i++)
            {
                var2 = var2 + Math.Pow((DatosX[i] - XProm), 2);
            }
            double var3 = var1 / var2;
            double var4 = 1 + (1/numeroDeDatos) + var3;
            double dato3 = Math.Sqrt(var4);
            double Rango = dato1*dato2*dato3;
            return Rango;
        }
        //TERMINA METODO CALCULAR RANGO

        //EMPIEZA METODO CALCULAR UPI
        public double calcularUPI(double Xk, List<double> DatosX, List<double> DatosY, double dof)
        {
            double Yk = calcularYk(Xk, DatosX, DatosY);
            double rango = calcularRango(Xk, dof, DatosX, DatosY);
            double UPI = Yk + rango;
            return UPI;
        }
        //TERMINA METODO CALCULAR UPI

        //EMPIEZA METODO CALCULAR UPI
        public double calcularLPI(double Xk, List<double> DatosX, List<double> DatosY, double dof)
        {
            double Yk = calcularYk(Xk, DatosX, DatosY);
            double rango = calcularRango(Xk, dof, DatosX, DatosY);
            double LPI = Yk - rango;
            return LPI;
        }
        //TERMINA METODO CALCULAR UPI

    }
}
