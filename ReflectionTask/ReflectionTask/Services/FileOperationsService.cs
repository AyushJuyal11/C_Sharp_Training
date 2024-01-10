using System.Reflection;
using ReflectionTask.Models;
using ReflectionTask.CustomAttributes; 

namespace ReflectionTask.Services
{
    public class FileOperationsService
    {
        public static void PopulateDataToFile<T>(T classobj, string path , string pathoutput) where T : class
        {
            string data = File.ReadAllText(path);

            Type t = classobj.GetType();
            PropertyInfo[] props = t.GetProperties();

            foreach (PropertyInfo pi in props)
            {
                data = data.Replace(pi.GetCustomAttribute<MapHtmlDataAttribute>().FieldName , pi.GetValue(classobj).ToString());
            }

            File.WriteAllText(pathoutput, data);
        }
    }
}
