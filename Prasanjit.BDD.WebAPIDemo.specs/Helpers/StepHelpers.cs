using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Prasanjit.BDD.WebAPIDemo.specs.Helpers
{
    public class StepHelpers
    {
        public static List<KeyValuePair<string, string>> SetPostData<T>(T testClass)
        {
            var postData = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo property in testClass.GetType().GetProperties())
            {
                if (property.GetValue(testClass, null) != null)
                {
                    postData.Add(new KeyValuePair<string, string>(property.Name.ToString(), property.GetValue(testClass, null).ToString()));
                }
            }
            return postData;
        }

        public static HttpClient SetupHttpClient()
        {
            var client = new HttpClient();
           
            return client;
        }

    }
}
