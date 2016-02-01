using EducationSystem.Controllers;
using EducationSystem.Data;
using EducationSystem.Interfaces;
using EducationSystem.Model;

using System;
using System.Linq;
using System.Reflection;

namespace EducationSystem.Core
{
    public class UniversityEngine : IEngine
    {
        public void Run()
        {
            UniversityRepository database = new UniversityRepository();
            User user = null;

            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == null)
                {
                    break;
                }

                IRoute route = new Route(input);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, database, user) as Controller;
                var action = controllerType?.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, action);

                try
                {
                    var view = action.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.InnerException.Message;
                    Console.WriteLine(errorMessage);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            Type intType = typeof(int);

            var parameters = action.GetParameters()
                .Select<ParameterInfo, object>(
                    parameter =>
                        {
                            if (parameter.ParameterType == intType)
                            {
                                return int.Parse(route.Parameters[parameter.Name]);
                            }

                            return route.Parameters[parameter.Name];
                        });

            return parameters.ToArray();
        }
    }
}
