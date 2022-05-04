using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public class TodoItem

    {
        [Newtonsoft.Json.JsonProperty("id")] 
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("done")]
        public bool IsDone { get; set; }

        public static implicit operator List<object>(TodoItem v)
        {
            throw new NotImplementedException();
        }
    }
}
