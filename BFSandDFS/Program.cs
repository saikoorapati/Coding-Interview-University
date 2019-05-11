using System;
using System.Collections.Generic;
using System.Collections;

namespace BFSandDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            //BFS
            BreadthFirstAlgorithm b = new BreadthFirstAlgorithm();
            Employee root = b.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = b.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);

            //DFS
            DepthFirstAlgorithm d = new DepthFirstAlgorithm();
            Employee rootD = d.BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            d.Traverse(rootD);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee emp = d.Search(root, "Eva");
            Console.WriteLine(emp == null ? "Employee not found" : emp.name);
            emp = d.Search(root, "Brian");
            Console.WriteLine(emp == null ? "Employee not found" : emp.name);
            emp = d.Search(root, "Soni");
            Console.WriteLine(emp == null ? "Employee not found" : emp.name);
        }

        public class Employee
        {
            public string name { get; set; }
            public Employee(string name)
            {
                this.name = name;
            }

            System.Collections.Generic.List<Employee> EmployeeList = new System.Collections.Generic.List<Employee>();

            public void isEmployeeOf(Employee p)
            {
                EmployeeList.Add(p);
            }

            public override string ToString()
            {
                return name;
            }

            public List<Employee> Employees
            {
                get
                {
                    return EmployeeList;
                }
            }
        }

        public class BreadthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee EVA = new Employee("Eva");
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);

                return Eva;
            }

            public void Traverse(Employee root)
            {
                Queue<Employee> TraveralOrder = new Queue<Employee>();

                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();

                Q.Enqueue(root);
                S.Add(root);

                while(Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    TraveralOrder.Enqueue(e);

                    foreach(Employee emp in e.Employees)
                    {
                        if(!S.Contains(emp))
                        {
                            Q.Enqueue(emp);
                            S.Add(emp);
                        }
                    }
                }
                while (TraveralOrder.Count > 0)
                {
                    Employee e = TraveralOrder.Dequeue();
                    Console.WriteLine(e);
                }
            }
            public Employee Search(Employee root, string nameToSearchFor)
            {
                Queue<Employee> Q = new Queue<Employee>();
                HashSet<Employee> S = new HashSet<Employee>();
                Q.Enqueue(root);
                S.Add(root);

                while (Q.Count > 0)
                {
                    Employee e = Q.Dequeue();
                    if (e.name == nameToSearchFor)
                        return e;
                    foreach (Employee friend in e.Employees)
                    {
                        if (!S.Contains(friend))
                        {
                            Q.Enqueue(friend);
                            S.Add(friend);
                        }
                    }
                }
                return null;
            }
        }

        public class DepthFirstAlgorithm
        {
            public Employee BuildEmployeeGraph()
            {
                Employee Eva = new Employee("Eva");
                Employee Sophia = new Employee("Sophia");
                Employee Brian = new Employee("Brian");
                Eva.isEmployeeOf(Sophia);
                Eva.isEmployeeOf(Brian);

                Employee Lisa = new Employee("Lisa");
                Employee Tina = new Employee("Tina");
                Employee John = new Employee("John");
                Employee Mike = new Employee("Mike");
                Sophia.isEmployeeOf(Lisa);
                Sophia.isEmployeeOf(John);
                Brian.isEmployeeOf(Tina);
                Brian.isEmployeeOf(Mike);

                return Eva;
            }

            public void Traverse(Employee root)
            {
                Console.WriteLine(root.name);

                for(int i=0; i<root.Employees.Count;i++)
                {
                    Traverse(root.Employees[i]);
                }

            }
            public Employee Search(Employee root, string nameToSearchFor)
            {
                if (nameToSearchFor == root.name)
                    return root;

                Employee personFound = null;
                for (int i = 0; i < root.Employees.Count; i++)
                {
                    personFound = Search(root.Employees[i], nameToSearchFor);
                    if (personFound != null)
                        break;
                }
                return personFound;
            }
        }
        }
}
