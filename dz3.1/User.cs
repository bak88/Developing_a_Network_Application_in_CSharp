using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace dz3._1
{
    internal class User
    {
        [JsonIgnore]
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public bool IsCancelled
        {
            get
            {
                return CancellationTokenSource.IsCancellationRequested;
            }
        }

        public User(string name, string text)
        {
            Name = name;
            Text = text;
            Date = DateTime.Now;
            CancellationTokenSource = new CancellationTokenSource();

        }
        public User() { }
        public override string ToString() { return $"{Name}:- {Text} --- {Date}"; }
        internal static User? FromJson(string message)
        {
            return JsonSerializer.Deserialize<User>(message);
        }

        internal string ToJson()
        {
            try { return JsonSerializer.Serialize(this); }

            catch { Console.WriteLine("Can't parse JSON"); return String.Empty; }

        }
    }
}
