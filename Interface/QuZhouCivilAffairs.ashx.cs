using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace Interface
{
    /// <summary>
    /// QuZhouCivilAffairs1 的摘要说明
    /// </summary>
    /// 
    public class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    public class QuZhouCivilAffairs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            //context.Response.ContentType = "text/plain";
            
            Person person = new Person();
            person.Name = "GoldenEasy";
            person.Age = 25;

            string strSerializeJSON = JsonConvert.SerializeObject(person);

            try
            {
                using (quzhoucivilaffairsEntities quzhou = new quzhoucivilaffairsEntities())
                {
                    
                }

            }catch(Exception ex){
                context.Response.Write(ex.ToString());
            }


            context.Response.Write(strSerializeJSON); 

            //context.Response.Write("{id:'123'}");

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}