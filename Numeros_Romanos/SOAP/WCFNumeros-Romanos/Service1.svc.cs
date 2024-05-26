using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFNumeros_Romanos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public int TransformarNumero(string numero)
        {
            numero = numero.ToUpper();

            Dictionary<string, int> tabela = new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };

            int result = 0;
            int repeatCount = 1;

            for (int i = 0; i < numero.Length; i++)
            {
                if (!tabela.TryGetValue(numero[i].ToString(), out int current))
                {
                    return 0;
                }

                if (i < numero.Length - 1)
                {
                    if (!tabela.TryGetValue(numero[i + 1].ToString(), out int next))
                    {
                        return 0;
                    }

                    if (numero[i] == numero[i + 1])
                    {
                        repeatCount++;
                        if (repeatCount > 3)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        repeatCount = 1;
                    }

                    if (current < next)
                    {
                        result -= current;
                    }
                    else
                    {
                        result += current;
                    }
                }
                else
                {
                    result += current;
                }
            }
            return result;
        }
    }
}
