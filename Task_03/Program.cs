using System;
using System.Collections.Generic;

namespace TaskThree
{

    /// Задача - перепишите данный код так, чтобы он работал через коллекции C#, вместо конструкции switch



    public enum ActionType
    {
        Create,

        Read,

        Update,

        Delete
        
    }

    class Program
    {
        private static readonly Dictionary<ActionType, Action<ActionType>> actions = new Dictionary<ActionType, Action<ActionType>>()
        {
            { ActionType.Create, CreateMethod },
            { ActionType.Read, ReadMethod},
            { ActionType.Update, UpdateMethod },
            { ActionType.Delete, DeleteMethod}
        };

        static void Main(string[] args)
        {
            var type = ActionType.Read;

            if (actions.TryGetValue(type, out Action<ActionType> act))
            {
                act.Invoke(type);
                Console.Read();
            }
            else
                throw new ArgumentOutOfRangeException();
            }

        private static void CreateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void ReadMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void UpdateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void DeleteMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }        
}
