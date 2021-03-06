using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa8
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

        //EMPIEZA METODO CALCULAR RANGO
        public double calcularRango(double Wk, double Xk, double Yk, double dof, List<double> DatosW, List<double> DatosX, List<double> DatosY, List<double> DatosZ, double B0, double B1, double B2, double B3)
        {
            EncontrarXdeIntegral Ex = new EncontrarXdeIntegral();
            double numeroDeDatos = Convert.ToDouble(DatosX.Count);
            double dato1 = Ex.obtenerX(.35, (numeroDeDatos - 4));
            double dato2 = calcularVarianza(DatosW, DatosX, DatosY, DatosZ, B0, B1, B2, B3);
            dato2 = Math.Sqrt(dato2);
            double XProm = DatosX.Average();
            double WProm = DatosW.Average();
            double YProm = DatosY.Average();
            double var1W = Math.Pow((Wk -WProm), 2);
            double var1X = Math.Pow((Xk - XProm), 2);
            double var1Y = Math.Pow((Yk - YProm), 2);
            double var2W = 0;
            double var2X = 0;
            double var2Y = 0;
            for(int i = 0; i < numeroDeDatos; i++)
            {
                var2W = var2W + Math.Pow((DatosW[i] - XProm), 2);
                var2X = var2X + Math.Pow((DatosX[i] - WProm), 2);
                var2Y = var2Y + Math.Pow((DatosY[i] - YProm), 2);
            }
            double var3W = var1W / var2W;
            double var3X = var1X / var2X;
            double var3Y = var1Y / var2Y;
            double var4 = 1 + (1/numeroDeDatos) + var3W + var3X + var3Y;
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

        //EMPIEZA METODO LLENAR MATRIZ
        public double[,] llenarMatriz(List<double> DatosW, List<double> DatosX, List<double> DatosY, List<double> DatosZ)
        {
            double numDatos = Convert.ToDouble(DatosW.Count);
            double n = numDatos;
            double Wi = DatosW.Sum();
            double Xi = DatosX.Sum();
            double Yi = DatosY.Sum();
            double Zi = DatosZ.Sum();
            double Wi2 = 0;
            double Xi2 = 0;
            double Yi2 = 0;
            foreach (double d in DatosW)
                Wi2 = Wi2 + Math.Pow(d, 2);
            foreach (double d in DatosX)
                Xi2 = Xi2 + Math.Pow(d, 2);
            foreach (double d in DatosY)
                Yi2 = Yi2 + Math.Pow(d, 2);
            double WiXi = 0;
            double WiYi = 0;
            double WiZi = 0;
            double XiYi = 0;
            double XiZi = 0;
            double YiZi = 0;
            for (int i = 0; i < numDatos; i++) 
            {
                WiXi = WiXi + (DatosW[i] * DatosX[i]);
                WiYi = WiYi + (DatosW[i] * DatosY[i]);
                WiZi = WiZi + (DatosW[i] * DatosZ[i]);
                XiYi = XiYi + (DatosX[i] * DatosY[i]);
                XiZi = XiZi + (DatosX[i] * DatosZ[i]);
                YiZi = YiZi + (DatosY[i] * DatosZ[i]);
            }
            double[,] a = { { n, Wi, Xi, Yi, Zi }, { Wi, Wi2, WiXi, WiYi, WiZi }, { Xi, WiXi, Xi2, XiYi, XiZi }, { Yi, WiYi, XiYi, Yi2, YiZi } };
            return a;
        }
        //TERMINA METODO LLENAR MATRIZ

        //METODO CALCULAR VARIANZA
        public double calcularVarianza(List<double> DatosW, List<double> DatosX, List<double> DatosY, List<double> DatosZ, double B0, double B1, double B2, double B3) 
        {
            double sum = 0;
            double numDatos = DatosW.Count;
            for (int i = 0; i < numDatos; i++) 
            { 
                sum = sum + Math.Pow((DatosZ[i] - B0 - (B1*DatosW[i]) - (B2*DatosX[i]) - (B3 * DatosY[i])), 2);
            }
            double res = sum / (numDatos - 4);
            return res;
        }
        //METODO CALCULAR VARIANZA

        //EMPIEZA METODO OBTENER Z
        public double obtenerZ(double Wk, double Xk, double Yk, double B0, double B1, double B2, double B3) 
        {
            double z = B0 + (Wk * B1) + (Xk * B2) + (Yk * B3);
            return z;
        }
        //TERMINA METODO OBTENERZ

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> DatosW = new List<double>();
            List<double> DatosX = new List<double>();
            List<double> DatosY = new List<double>();
            List<double> DatosZ = new List<double>();

            DatosW.Add(345); DatosW.Add(168); DatosW.Add(94); DatosW.Add(187); DatosW.Add(621); DatosW.Add(255);
            DatosX.Add(65); DatosX.Add(18); DatosX.Add(0); DatosX.Add(185); DatosX.Add(87); DatosX.Add(0);
            DatosY.Add(23); DatosY.Add(18); DatosY.Add(0); DatosY.Add(98); DatosY.Add(10); DatosY.Add(0);
            DatosZ.Add(31.4); DatosZ.Add(14.6); DatosZ.Add(6.4); DatosZ.Add(28.3); DatosZ.Add(42.1); DatosZ.Add(15.3); 

            Gauss G = new Gauss();
            Funciones F = new Funciones();
            double[,] a = F.llenarMatriz(DatosW, DatosX, DatosY, DatosZ);
            double[] r = new double[a.GetLength(0)];
            double[] resultados = new double[a.GetLength(0)];
            G.ShowMatrix(a, "Ejemplo 1");
            if (G.ResolverGauss(a, r))
                resultados = G.ShowSolution(r);
            else
                Console.WriteLine("No es un sistema de ecuaciones lineales");
            double B0 = resultados[0];
            double B1 = resultados[1];
            double B2 = resultados[2];
            double B3 = resultados[3];
            double Wk = 185; double Xk = 150; double Yk = 45;
            double z = F.obtenerZ(Wk, Xk, Yk, B0, B1, B2, B3);
            Console.WriteLine("La z = " + z);
            double rango = F.calcularRango(Wk, Xk, Yk, DatosW.Count - 4 , DatosW, DatosX, DatosY, DatosZ, B0, B1, B2, B3);
            Console.WriteLine("UPI = " + (z + rango));
            Console.WriteLine("LPI = " + (z - rango));

            Console.ReadLine();
            ////////////////////////////////////////////////////
            List<double> DatosW2 = new List<double>();
            List<double> DatosX2 = new List<double>();
            List<double> DatosY2 = new List<double>();
            List<double> DatosZ2 = new List<double>();

            DatosW2.Add(1142); DatosW2.Add(863); DatosW2.Add(1065); DatosW2.Add(554); DatosW2.Add(983); DatosW2.Add(256);
            DatosX2.Add(1060); DatosX2.Add(995); DatosX2.Add(3205); DatosX2.Add(120); DatosX2.Add(2896); DatosX2.Add(485);
            DatosY2.Add(325); DatosY2.Add(98); DatosY2.Add(23); DatosY2.Add(0); DatosY2.Add(120); DatosY2.Add(88);
            DatosZ2.Add(201); DatosZ2.Add(98); DatosZ2.Add(162); DatosZ2.Add(54); DatosZ2.Add(138); DatosZ2.Add(61);

            double[,] a2 = F.llenarMatriz(DatosW2, DatosX2, DatosY2, DatosZ2);
            double[] r2 = new double[a2.GetLength(0)];
            double[] resultados2 = new double[a2.GetLength(0)];
            G.ShowMatrix(a, "Ejemplo 1");
            if (G.ResolverGauss(a2, r2))
                resultados2 = G.ShowSolution(r2);
            else
                Console.WriteLine("No es un sistema de ecuaciones lineales");
            double B02 = resultados2[0];
            double B12 = resultados2[1];
            double B22 = resultados2[2];
            double B32 = resultados2[3];
            double Wk2 = 650; double Xk2 = 3000; double Yk2 = 155;
            double z2 = F.obtenerZ(Wk2, Xk2, Yk2, B02, B12, B22, B32);
            Console.WriteLine("La z = " + z2);
            double rango2 = F.calcularRango(Wk2, Xk2, Yk2, DatosW2.Count - 4, DatosW2, DatosX2, DatosY2, DatosZ2, B02, B12, B22, B32);
            Console.WriteLine("UPI = " + (z2 + rango2));
            Console.WriteLine("LPI = " + (z2 - rango2));

            Console.ReadLine();
            
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

namespace Programa8
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

namespace Programa8
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa8
{
    class Gauss
    {
        //EMPIEZA METODO GAUSS
        public bool ResolverGauss(double[,] a, double[] r)
        {
            double t, s;
            int i, l, j, k, m, n;

            try
            {
                n = r.Length - 1;
                m = n + 1;
                for (l = 0; l <= n - 1; l++)
                {
                    j = l;
                    for (k = l + 1; k <= n; k++)
                    {
                        if (!(Math.Abs(a[j, l]) >= Math.Abs(a[k, l]))) j = k;
                    }
                    if (!(j == l))
                    {
                        for (i = 0; i <= m; i++)
                        {
                            t = a[l, i];
                            a[l, i] = a[j, i];
                            a[j, i] = t;
                        }
                    }
                    for (j = l + 1; j <= n; j++)
                    {
                        t = (a[j, l] / a[l, l]);
                        for (i = 0; i <= m; i++) a[j, i] -= t * a[l, i];
                    }
                }
                r[n] = a[n, m] / a[n, n];
                for (i = 0; i <= n - 1; i++)
                {
                    j = n - i - 1;
                    s = 0;
                    for (l = 0; l <= i; l++)
                    {
                        k = j + l + 1;
                        s += a[j, k] * r[k];
                    }
                    r[j] = ((a[j, m] - s) / a[j, j]);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //TERMINA METODO RESOLVER GAUSS

        //EMPIEZA METODO MUESTRA SOLUCI�N
        public double[] ShowSolution(double[] r)
        {
            Console.WriteLine("Soluci�n por Eliminaci�n Gaussiana");
            double[] resultados = new double[r.GetLength(0)];
            for (int i = 0; i <= r.GetUpperBound(0); i++)
            {
                Console.WriteLine(ToStringSign(r[i]));
                resultados[i] = r[i];
            }
            Console.WriteLine("\n");
            return resultados;
        }
        //TERMINA METODO MUESTRA SOLUCI�N 

        //EMPIEZA METODO SIGNO A STRING
        static private string ToStringSign(double v)
        {
            if (v < 0) return ' ' + v.ToString(); else return "  " + v.ToString();
        }
        //TERMINA METODO SIGNO A STRING

        //EMPIEZA METODO MUESTRA MATRIZ
        public void ShowMatrix(double[,] a, string Title)
        {
            Console.WriteLine(Title + '\n');
            for (int i = 0; i <= a.GetUpperBound(0); i++)
            {
                Console.Write('|');
                for (int j = 0; j <= a.GetUpperBound(1); j++)
                {
                    Console.Write(ToStringSign(a[i, j]));
                }
                Console.Write(" | \n");
            }
            Console.WriteLine('\n');
        }
        //TERMINA METODO MUESTRA MATRIZ
    }
}
