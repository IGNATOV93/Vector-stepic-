using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Vector_stepic_
{
    public class MainClass
    {
        public static void Main()
        {
            var test = MadeDepartament.WriteInputDep(); test.Add(new Departament(test));
            MadeDepartament.Print(test);
        }
    }

    public class MadeDepartament
    {
        public static List<Departament> WriteInputDep()
        {
            List<List<string>> list_of_strings_departaments = new List<List<string>>();
            for (int i = 1; i < 5; i++)
            {
                List<string> dep = new List<string>();
                string intput = Console.ReadLine();

                dep.AddRange(InputParser(intput).Split(' '));
                dep.Remove(dep[0]);
                dep.RemoveRange(dep.Count - 4, 3);
                list_of_strings_departaments.Add(dep);
            }
            return MadeDep(list_of_strings_departaments);
        }

        public static string InputParser(string input)
        {
            
            return input
                .Replace(":", "")
                .Replace(",", "");
        }
        public static List<Departament> MadeDep(List<List<string>> list_of_strings_departaments)
        {
            List<Departament> Departament = new List<Departament>();
            for (int i = 0; i < 4; i++)
            {
                List<Employee> departament = new List<Employee>();
                string namedep = list_of_strings_departaments[i][0];
                for (int j = 0; j < list_of_strings_departaments[i].Count; j++)
                {
                    if (j == 0) j++;
                    int count;
                    string employee = list_of_strings_departaments[i][j];
                    bool director = false;
                    if (list_of_strings_departaments[i].Count - 1 == j)
                    {
                        count = 1;
                        director = true;
                        employee = "1*" + employee;
                    }
                    else
                    {
                        count = Convert.ToInt32(employee.Substring(0, employee.IndexOf('*')));
                    }
                    int rang = Convert.ToInt32(employee[employee.Length - 1].ToString());


                    employee = Regex.Replace(employee, "[0-9]", "");
                    if (employee == "*manager") departament.Add(new Manager(count, rang, director));
                    if (employee == "*marketer") departament.Add(new Marketer(count, rang, director));
                    if (employee == "*engineer") departament.Add(new Engineer(count, rang, director));
                    if (employee == "*analyst") departament.Add(new Analyst(count, rang, director));
                }
                Departament.Add(new Departament(departament, namedep));
            }
            return Departament;
        }

        public static void Print(List<Departament> alldeps)
        {
            Console.WriteLine("{0,-16}{1,-16}{2,-12}{3,-9}{4,-13}{5,-10}", "Департамент", "Сотрудников", "Тугрики", "Кофе", "Страницы", "Тугр./стр.");
            Console.WriteLine("----------------------------------------------------------------------------");
            int numberDep = 0;
            foreach (var i in alldeps)
            {
                numberDep++;
                Console.WriteLine("{0,-16}{1,-16}{2,-12}{3,-9}{4,-13}{5}", i.Name, i.CountEmploees, i.Tugriks, i.CountsСoffe, i.Pages, i.AveragePricePage);
                if (numberDep == 4) Console.WriteLine("----------------------------------------------------------------------------");
            }
        }
    }

    public class Departament
    {
        private string _name;
        public string Name
        {
            set => _name = value[0].ToString().ToUpper() + value.Substring(1);
            get => _name;
        }

        public int CountEmploees { set; get; }
        public int Tugriks { set; get; }
        public int CountsСoffe { set; get; }
        public int Pages { set; get; }

        private double averagePricePage;
        public double AveragePricePage
        {
            get => Math.Round((double)Tugriks / Pages, 2, MidpointRounding.AwayFromZero);
            protected set { }
        }

        public Departament(List<Employee> departament, string name) //Constructor onedeps

        {
            Name = name;
            foreach (var i in departament)
            {
                CountEmploees += i.CountsEmploees;
                CountsСoffe += i.CountsСoffe;
                Tugriks += i.Allprice;
                Pages += i.PageCounts;

            }
            averagePricePage = AveragePricePage;
        }

        public Departament(List<Departament> allDepartaments) //Constructor alldeps
        {
            Name = "Всего";
            foreach (var i in allDepartaments)
            {
                CountEmploees += i.CountEmploees;
                CountsСoffe += i.CountsСoffe;
                Tugriks += i.Tugriks;
                Pages += i.Pages;
            }
            averagePricePage = AveragePricePage;
        }
    }

    public abstract class Employee
    {
        private bool _dirOrNotdir;
        public bool DirOrnotdir
        {
            set => _dirOrNotdir = value;
            get => _dirOrNotdir;
        }

        private int _allprice;
        public int Allprice
        {
            set => _allprice = value;
            get => _allprice;
        }

        private int _countsEmploees;
        public int CountsEmploees { set; get; }

        private int _rang;

        private double _ratio = 1;
        public double Ratio
        {
            get
            {
                if (_dirOrNotdir) _ratio = 1.5;
                switch (_rang)
                {
                    case 1: return _ratio *= 1;
                    case 2: return _ratio *= 1.25;
                    case 3: return _ratio *= 1.5;
                }

                return _ratio;
            }
            set { }
        }

        private int _countСoffe;
        public int CountsСoffe
        {
            get => _countСoffe;
            protected set
            {
                if (!_dirOrNotdir) _countСoffe = value;
                else _countСoffe = value * 2;
            }
        }

        private int _pageCounts;
        public int PageCounts
        {
            get => _pageCounts;
            set
            {
                if (!_dirOrNotdir) _pageCounts = value;
                else _pageCounts = 0;
            }
        }

        public Employee(int countsEmploees, int rang, bool dirOrnotdir)
        {
            CountsEmploees = countsEmploees;
            _rang = rang;
            DirOrnotdir = dirOrnotdir;
            Ratio = _ratio;
            PageCounts = _pageCounts;
        }
    }

    public class Manager : Employee
    {
        public Manager(int countsEmploees, int rang, bool dirOrnotdir) : base(countsEmploees, rang, dirOrnotdir)
        {
            Allprice = (int)Math.Round(Ratio * 50000 * countsEmploees, MidpointRounding.AwayFromZero);
            CountsСoffe = countsEmploees * 20;
            PageCounts = countsEmploees * 200; //
        }
    }

    public class Marketer : Employee
    {
        public Marketer(int countsEmploees, int rang, bool dirOrnotdir) : base(countsEmploees, rang, dirOrnotdir)
        {
            Allprice = (int)Math.Round(Ratio * 40000 * countsEmploees, MidpointRounding.AwayFromZero);
            CountsСoffe = countsEmploees * 15;
            PageCounts = countsEmploees * 150;
        }
    }

    public class Engineer : Employee
    {
        public Engineer(int countsEmploees, int rang, bool dirOrnotdir) : base(countsEmploees, rang, dirOrnotdir)
        {
            Allprice = (int)Math.Round(Ratio * 20000 * countsEmploees, MidpointRounding.AwayFromZero);
            CountsСoffe = countsEmploees * 5;
            PageCounts = countsEmploees * 50;
        }
    }

    public class Analyst : Employee
    {
        public Analyst(int countsEmploees, int rang, bool dirOrnotdir) : base(countsEmploees, rang, dirOrnotdir)
        {
            Allprice = (int)Math.Round(Ratio * 80000 * countsEmploees, MidpointRounding.AwayFromZero);
            CountsСoffe = countsEmploees * 50;
            PageCounts = countsEmploees * 5;
        }
    }

}




