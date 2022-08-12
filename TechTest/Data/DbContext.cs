using Newtonsoft.Json;

namespace TechTest.Data
{
    /// <summary>
    /// Psuedo DbContext that conceptually represents a document database
    /// </summary>
    public class DbContext
    {
        public static string Product { get; set; }


        public List<T> Get<T>()
        {
            var name = typeof(T).Name;
            var propertyInfo = this.GetType().GetProperty(name);
            var values = (string)propertyInfo.GetValue(this, null);
            List<T> list = null;
            if(values != null)
                list = JsonConvert.DeserializeObject<List<T>>(values);
            return list;
        }

        public void SaveChanges<T>(List<T> data)
        {
            var name = typeof(T).Name;
            var propertyInfo = this.GetType().GetProperty(name);
            var dataString = JsonConvert.SerializeObject(data);
            propertyInfo.SetValue(this, dataString);
        }


    }
}
