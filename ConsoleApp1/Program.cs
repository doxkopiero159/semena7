using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();


        //data  source
        static void IntroToLINQ() {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            //numquery
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;
            //query execution
              foreach (int nun in numQuery)
            {
                Console.Write("{0,1}", nun);
            }
        }

        static  void DataSource()
        {

            var queruAllCustomers = from cust in context.clientes
                                    select cust;
            foreach (var  item in queruAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Filtering()
        {

            var queruAllCustomers2 = from cust in context.clientes
                                    where  cust.Ciudad == "Londres"
                                    select cust;
            foreach (var item in queruAllCustomers2)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
        static void Ordering()
        {

            var queruAllCustomers3 = from cust in context.clientes
                                    where cust.Ciudad == "London"
                                    orderby cust.NombreCompañia ascending
                                    select cust;
            foreach (var item in queruAllCustomers3)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Grouping()
        {

            var queruAllCustomersCity = from cust in context.clientes
                                        group cust by cust.Ciudad;
                                
            foreach (var customerGroup
                in queruAllCustomersCity)
            {
                Console.WriteLine(customerGroup.Key);
                foreach (clientes  customer in customerGroup)
                {
                    Console.WriteLine("   {0}", customer.NombreCompañia);
                }
            }
        }
        static void Grouping2()
        {

            var custQuery = from cust in context.clientes
                            group cust by cust.Ciudad into custGroup
                            where custGroup.Count()>2
                            orderby  custGroup.Key
                            select custGroup;

            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }
        static void Joining()
        {

            var innerJoinQuery = from cust in context.clientes
                                    join  dist in context.Pedidos on cust.idCliente equals  dist.IdCliente
                            select new { CustomerName = cust.NombreCompañia,DistributorName= dist.PaisDestinatario};

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("dataSource");
            DataSource();
          Console.Read();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Filtering");
            Filtering();
            Console.Read();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Ordering");
            Ordering();
            Console.Read();
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" Grouping");
            Grouping();
            Console.Read(); 
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" Grouping2");
            Grouping2();
            Console.Read();
            Console.WriteLine("----------------------------------");
            Console.WriteLine(" Joining");
            Joining();
            Console.Read();
        }
    }
}
