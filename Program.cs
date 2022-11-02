// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net;


public class Example
{
    private static List<string> nodeList;
    public static string Get(string url)
    {
        var web = new WebClient();
        return web.DownloadString(url);
    }
    

    public static int countNode(string id)
    {
        var model = GetNodes(id);
        var root = model[0].id.ToString();
        Example.nodeList.Add(id.ToString());
        

        //base case
        if (root == null || model.First().child_node_ids.Count() == 0)
            return 0;
       
        if(model.First().child_node_ids.Count() == 3)
        {
            return 1 + countNode(model.First().child_node_ids[0].ToString()) + countNode(model.First().child_node_ids[1].ToString()) + countNode(model.First().child_node_ids[2].ToString());
        }
        else
        {
            return 1 + countNode(model.First().child_node_ids[0].ToString()) + countNode(model.First().child_node_ids[1].ToString());
        }
    }
    public static RootObject[] GetNodes(string id)
    {
       
        Dictionary<string, Tuple<string, string>> nodes = new Dictionary<string, Tuple<string, string>>();
        String url = ($"https://nodes-on-nodes-challenge.herokuapp.com/nodes/{id}");
        
        String content = Get(url);
        var model = JsonConvert.DeserializeObject<RootObject[]>(content);
        return model;


    }
    public static void Main()
    {
        var id = "089ef556-dfff-4ff2-9733-654645be56fe";
        Example.nodeList = new List<string>();
        var value = countNode(id);
        Console.WriteLine(value);
        var top = nodeList.GroupBy(id => id).OrderByDescending(grp => grp.Count())
      .Select(grp => grp.Key).First();

        //Solution
        //Node Count: 8
        //Most common: 263a3e61-2eae-4dee-a15b-5c0dacad4db4

    }
}