using System;
using Composition.Entities.Enuns;
using Composition.Entities;

namespace Composition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de Empregados");
            Console.Write("Departamento: ");
            string department = Console.ReadLine();
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nível: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário Base: ");

            Department depart = new Department(department);
            double baseSalary = double.Parse(Console.ReadLine());

            Worker worker = new Worker(name, level, baseSalary, depart);

            Console.WriteLine();
            Console.Write("Quantos contratos para o empregado: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"Entre com o #{i} contrato: ");
                Console.Write("Informe a data do contrato: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Informe o valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Informe a quantidade de horas: ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);

            }
            Console.WriteLine();
            Console.Write("Entre com o mês e o ano para calcular o salário: ");
            string income = Console.ReadLine();
            int month = int.Parse(income.Substring(0, 2));
            int year = int.Parse(income.Substring(3));
            Console.WriteLine("Nome: "+ worker.Name);
            Console.WriteLine("Departamento: " + worker.Depart.Name);
            Console.WriteLine("Nível: " + worker.Level);
            Console.WriteLine("Salário: " + worker.Income(year, month).ToString("C"));
        }
    }
}
