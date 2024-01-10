
namespace ReflectionTask.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MapHtmlDataAttribute : Attribute
    {

        public string FieldName
        { 
        get; set; 
        }

        public MapHtmlDataAttribute() { }
        public MapHtmlDataAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }

}
