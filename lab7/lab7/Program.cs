using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lab7
{
    class Program
    {
        static List<Worker> workers = new List<Worker>()
            {
                new Worker(1, "Kent", 23),
                new Worker(2, "Oswald", 27),
                new Worker(3, "Allen", 24),
                new Worker(4, "Song", 25),
                new Worker(5, "Lang", 23),
                new Worker(6, "Manson", 26),
                new Worker(7, "Kingston", 27),
                new Worker(8, "Tennant", 25),
                new Worker(9, "Jones", 24),
                new Worker(10, "Tyler", 23),
                new Worker(11, "Noble", 27),
                new Worker(12, "Pond", 26),
                new Worker(13, "Williams", 25),
                new Worker(14, "Green", 24),
                new Worker(15, "Carter", 23),
                new Worker(16, "Jackson", 27),
                new Worker(17, "Cameron", 26),
                new Worker(18, "House", 27),
                new Worker(19, "Alto", 24),
                new Worker(20, "O'Neill", 23)
            };

        static List<Department> deps = new List<Department>()
        {
            new Department(23, "Literature"),
            new Department(24, "Programming"),
            new Department(25, "Music"),
            new Department(26, "Painting"),
            new Department(27, "Science"),
        };

        static List<workers_department> w_d = new List<workers_department>()
            {
                new workers_department(1 , 23),
                new workers_department(2 , 27),
                new workers_department(3 , 24),
                new workers_department(4 , 25),
                new workers_department(5 , 23),
                new workers_department(6 , 26),
                new workers_department(7 , 27),
                new workers_department(8 , 25),
                new workers_department(9 , 24),
                new workers_department(10 , 23),
                new workers_department(11 , 27),
                new workers_department(12 , 26),
                new workers_department(13 , 25),
                new workers_department(14 , 24),
                new workers_department(15 , 23),
                new workers_department(16 , 27),
                new workers_department(17 , 26),
                new workers_department(18 , 27),
                new workers_department(19 , 24),
                new workers_department(20 , 23)
            };

        
           




        static void Main(string[] args)
        {
            Console.WriteLine("\n Связь 1:M\n");
            Console.WriteLine("\nСписок работников и отделов, отсортированный по отделу ");

            var que1 = from x in workers
                       orderby x.ID_Dep descending, x.ID_W descending
                       select x;
            foreach (var x in que1) Console.WriteLine(x);


            Console.WriteLine("\nСписок работников чьи фамилии начинаются с 'A': ");

            var que2 = from x in workers
                       where x.Surname[0] is 'A'
                       orderby x.Surname ascending, x.ID_W descending
                       select x;
            foreach (var x in que2)
                Console.WriteLine(x);


            Console.WriteLine("\nСписок отделв и количество работников в каждом: ");

            var que3 = from x in deps
                       join y in workers on x.ID_Dep equals y.ID_Dep into temp
                       from t in temp
                       select new { Department = x.Name_Dep, ID = x.ID_Dep, count = temp.Count() };
            que3 = que3.Distinct();
            foreach (var x in que3)
                Console.WriteLine(x);


            Console.WriteLine("\nA Список отделов в которых фамилии всех работников начинаются с 'A': ");
            var que4 = from x in workers
                       join y in que2 on x.ID_Dep equals y.ID_Dep into temp
                       from t in temp
                       select new { ID_of_Department = x.ID_Dep, count = temp.Count() };
            que4 = que4.Distinct();
            var que4_2 = from x in que3
                         from y in que4
                         where (x.count == y.count) && (x.ID == y.ID_of_Department)
                         select new { ID_of_Department = x.ID };
            que4_2 = que4_2.Distinct();
            foreach (var x in que4_2)
                Console.WriteLine(x);

            Console.WriteLine("\n\nСписок отделов в которых " +
                 "хотябы у одного сотрудника фамилия начинается с 'A': ");
            var que5 = from x in workers
                       where x.Surname[0] is 'A'
                       select new { v1 = x.ID_Dep };
            que5 = que5.Distinct();
            var que5_2 = from x in deps
                         from y in que5
                         where x.ID_Dep == y.v1
                         select new { v1 = x.Name_Dep };
            que5_2 = que5_2.Distinct();
            foreach (var x in que5_2)
                Console.WriteLine(x);

            Console.WriteLine("\n Связь M:M\n");

            Console.WriteLine("Все отделы и работники в каждом отделе: ");
            var que6_1 = from y in deps
                         join l in w_d on y.ID_Dep equals l.ID_Dep into temp2
                         from t2 in temp2
                         select new { id = y.ID_Dep, name = y.Name_Dep };
            que6_1 = que6_1.Distinct();
            foreach (var y in que6_1)
            {
                Console.WriteLine("\n\n" + y+ "\n");
                var que6_2 = from x in w_d
                             where (y.id == x.ID_Dep)
                             select new { id_w = x.ID_W };
                que6_2 = que6_2.Distinct();
                var que6_3 = from t in workers
                             from t2 in que6_2
                             where t2.id_w == t.ID_W
                             select new { id = t.ID_W, surname = t.Surname};
                que6_3 = que6_3.Distinct();
                foreach (var t in que6_3)
                    Console.WriteLine(t);
            }

            Console.WriteLine("\n\nСписок отделов и количчетво работников в каждом ");
            var que7_1 = from x in deps
                     join l in w_d on x.ID_Dep equals l.ID_Dep into temp2
                     from t2 in temp2
                     select new { id = x.ID_Dep, name = x.Name_Dep };
            que7_1 = que7_1.Distinct();
            foreach (var x in que7_1)
            {
                Console.WriteLine("\n" + x);
                int N=0;
                var que7_2 = from y in w_d
                             where (x.id == y.ID_Dep)
                             select new { id_w = y.ID_W };
                que7_2 = que7_2.Distinct();
                foreach (var t2 in que7_2)
                    foreach (var t in workers)
                        if (t2.id_w == t.ID_W)
                             N++;
                Console.WriteLine("Number of workers " + N);
            }

            Console.WriteLine("\nPlease press any key to continue");
                Console.Read();

            }
        }
    }

