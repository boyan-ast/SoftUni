using System;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy : ISpy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = GetTypeOfClass(className);

            FieldInfo[] classSelectedFields = classType
                .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] classNonPublicMethods = classType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in classSelectedFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo privateGetMethod in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{privateGetMethod.Name} have to be public!");
            }

            foreach (MethodInfo publicSetMethod in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicSetMethod.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] methodsInfo = classType.GetMethods(
                BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.Static | BindingFlags.NonPublic);

            MethodInfo[] getMethods = methodsInfo.Where(m => m.Name.StartsWith("get")).ToArray();
            MethodInfo[] setMethods = methodsInfo.Where(m => m.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo getMethod in getMethods)
            {
                sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
            }

            foreach (MethodInfo setMethod in setMethods)
            {
                sb.AppendLine($"{setMethod.Name} will set field of {setMethod.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = GetTypeOfClass(className);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] privateMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo privateMethodInfo in privateMethodsInfo)
            {
                sb.AppendLine(privateMethodInfo.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type hackerType = GetTypeOfClass(className);

            FieldInfo[] fieldsInfo = hackerType.GetFields(
                BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {hackerType.FullName}");

            object classInstance = Activator.CreateInstance(hackerType, new object[] { });

            foreach (string fieldName in fieldsNames)
            {
                var selectedField = fieldsInfo.FirstOrDefault(f => f.Name == fieldName);

                if (selectedField != null)
                {
                    sb.AppendLine($"{selectedField.Name} = {selectedField.GetValue(classInstance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private Type GetTypeOfClass(string className)
        {
            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.FullName == className);

            if (type == null)
            {
                throw new ArgumentException("Invalid Class Name Provided!");
            }

            return type;
        }
    }
}
