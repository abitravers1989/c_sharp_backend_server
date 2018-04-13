using System;
using System.Net.Http;

namespace TwitterAPI
{
    public class HttpHelper
    {
        public HttpHelper()
        {
        }

        //Put together Url of request
        //Create tokens for header
        //attach header to request
        //make hhtp get request


        // make this return a async Task 
        public string MakeHttpRequest(string url){

            HttpClient client = new HttpClient();

            //  want the await here
            var result = client.GetAsync(url);
             


            //make hhtp get request with information given, to Api
            //return errorMessage if not 200 

            //don't need the .result part if asysnc await as this is already the result .. now have to go inside the task with Result

            if(result.Result.StatusCode != System.Net.HttpStatusCode.OK){
                return "Api did not respond";
            }

            return  "MoneySuperMarket - Helping You Make The Most Of Your Money";
            // would want to replace this with resultBody


            //just need the await when calling the async method
        }

     
    }
}
