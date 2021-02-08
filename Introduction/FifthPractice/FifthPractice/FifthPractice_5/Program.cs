using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace FifthPractice_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var storagePath = $"C:\\Users\\{Environment.UserName}\\Documents\\ToDoApp\\Data\\Misc";

            OnStartup(storagePath);

            var objW = new ObjectivesWorker(storagePath);

            var obj = new Objective("Build a computer", new DateTime(2022, 11, 1, 13, 25, 0));
            obj.Subobjectives.AddRange(new List<Objective>() 
            { 
                new Objective("Buy a CPU", new DateTime(2022, 11, 1, 13, 25, 0), true),
                new Objective("Buy RAM", new DateTime(2022, 11, 1, 13, 25, 0), true),
                new Objective("Buy a motherboard", new DateTime(2022, 11, 1, 13, 25, 0)),
                new Objective("Buy some storage disks", new DateTime(2022, 11, 6, 13, 25, 0)),
                new Objective("Buy a PSU", new DateTime(2022, 11, 6, 13, 25, 0)),
                new Objective("Buy a graphics card", new DateTime(2022, 11, 6, 13, 25, 0), true),
                new Objective("Buy a computer case", new DateTime(2022, 11, 6, 13, 25, 0)),
                new Objective("Burn the motherboard due to my crooked hands", new DateTime(2022, 11, 6, 13, 25, 0)),
            });

            var obj1 = new Objective("Meditate for about five minutes", new DateTime(2022, 12, 2, 13, 25, 0));
            var obj2 = new Objective("Buy the gum at the shop near the house", new DateTime(2022, 6, 3, 13, 25, 0));

            objW.Objectives.AddRange(new List<Objective>(){ obj, obj1, obj2});

            objW.PushObjectivesToJsonFile();

            var objectiveExtracter = new ObjectivesWorker(storagePath);

            objectiveExtracter.Objectives = objectiveExtracter.DeserializeStorage();

            Console.WriteLine(objectiveExtracter.ToString());
        }

        static void OnStartup(string storagePath)
        {
            if (!Directory.Exists($"{storagePath}"))
                Directory.CreateDirectory($"{storagePath}");

            //var objectivesChecker = new ObjectivesWorker(storagePath);
        }        
    }


    //Нет времени реализовать изменение приоритета, когда ExpireDate приближается :(
    public enum Priority
    {
        Low = 1,
        Medium,
        High
    }
    
    public class Objective
    {
        public Guid Id { get; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public List<Objective> Subobjectives { get; set; }
        public DateTime ObjectiveFormulationDate { get; set; }
        public DateTime ExpireDate { get; set; }      
        public Priority ObjectivePriority { get; set; }
        
        public Objective(string title, DateTime expireDate, bool isDone = false)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsDone = isDone;
            Subobjectives = new List<Objective>();
            ObjectiveFormulationDate = DateTime.Now;
            ExpireDate = expireDate;            
        }

        public Objective()
        {
            Id = Guid.NewGuid();
            Title = "";
            IsDone = false;
            Subobjectives = new List<Objective>();
            ObjectiveFormulationDate = DateTime.Now;
            ExpireDate = DateTime.Now;
        }

        public override string ToString()
        {
            var completion = GetObjectiveCompletionPercents();

            var subobjecivesString = new StringBuilder();

            foreach (var item in Subobjectives)
            {
                subobjecivesString.Append($"|\n|______Subobjective {Subobjectives.IndexOf(item) + 1}. {item.ToString()}");
            }

            return $"{Title}. Formulation date: {ObjectiveFormulationDate.ToShortDateString()} Expire date: {ExpireDate.ToShortDateString()} - {completion}%\n" +
                $"{subobjecivesString.ToString()}";
        }

        public void InvertCompletionAttribute()
        {
            IsDone = IsDone ? false : true;                        
        }

        public int GetObjectiveCompletionPercents()
        {
            if (Subobjectives.Count == 0)
                return IsDone ? 100 : 0;
            else
            {
                var result = 0;

                foreach (var item in Subobjectives)
                {
                    result += Convert.ToByte(item.IsDone); 
                }

                return result / Subobjectives.Count * 100;
            }            
        }
    }

    public class ObjectivesWorker
    {
        public List<Objective> Objectives { get; set; }
        public string StorageDirectory{ get; set; } 
        public ObjectivesWorker(string storagePath)
        {
            Objectives = new List<Objective>();
            StorageDirectory = storagePath;
        }

        public string SerializeObjective(Objective objective)
        {
            if (objective != null)
            {
                return JsonSerializer.Serialize(objective);
            }

            return null;
        }

        public List<string> SerializeObjectives()
        {
            if (Objectives != null && Objectives.Count > 0)
            {
                var jsonObjectivesList = new List<string>();

                foreach (var objective in Objectives)
                {
                    JsonSerializer.Serialize(objective);
                }

                return jsonObjectivesList;
            }

            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in Objectives)
            {
                sb.Append($"Objective {Objectives.IndexOf(item) + 1}. {item.ToString()}\n");
            }

            return sb.ToString();
        }

        public void PushObjectivesToJsonFile()
        {
            foreach (var objective in Objectives)
            {
                File.WriteAllText($"{StorageDirectory}\\{objective.Id}", SerializeObjective(objective));
            }
        }

        public List<Objective> DeserializeStorage()
        {
            if (Directory.GetFiles(StorageDirectory).Length == 0)
            {
                return new List<Objective>();
            }
            else
            {
                var objectives = new List<Objective>();

                foreach (var item in Directory.GetFiles(StorageDirectory))
                {
                    objectives.Add(JsonSerializer.Deserialize<Objective>(File.ReadAllText(item)));
                }

                return objectives;
            }
        }

        public void SortObjectivesByTitle()
        {
            if (Objectives.Count == 0)
                return;

            Objectives.GroupBy(objective => objective.Title);
        }

        public void SortObjectivesByPriority()
        {
            if (Objectives.Count == 0)
                return;

            Objectives.GroupBy(objective => objective.ObjectivePriority);
        }

        public void SortObjectivesByObjectiveFormulationDate()
        {
            if (Objectives.Count == 0)
                return;

            Objectives.GroupBy(objective => objective.ObjectiveFormulationDate);
        }   
    }    
}
