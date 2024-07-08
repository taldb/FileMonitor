//Copyright © Dennis 2024 https://github.com/taldb
//Coding This was Hard!


class EnvironmentManager
{

    //C:\\Users\\xxxx\\db.env
    private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "db.env");

    public static void CreateEnvironment(string envName)
    {
        var environments = LoadEnvironments();
        if (!environments.ContainsKey(envName))
        {
            environments[envName] = new Dictionary<string, string>();
            SaveEnvironments(environments);
        }
    }

    public static void DeleteEnvironment(string envName)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName))
        {
            environments.Remove(envName);
            SaveEnvironments(environments);
        }
    }

    public static void AddVariable(string envName, string variableName, string value)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName))
        {
            environments[envName][variableName] = value;
            SaveEnvironments(environments);
        }
    }

    public static void DeleteVariable(string envName, string variableName)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName) && environments[envName].ContainsKey(variableName))
        {
            environments[envName].Remove(variableName);
            SaveEnvironments(environments);
        }
    }

    public static void EditVariable(string envName, string variableName, string value)
    {
        AddVariable(envName, variableName, value);
    }

    public static string ReadVariable(string envName, string variableName)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName) && environments[envName].ContainsKey(variableName))
        {
            return environments[envName][variableName];
        }
        return null;
    }

    public static List<string> GetAllEnvironments()
    {
        return LoadEnvironments().Keys.ToList();
    }

    public static void DeleteAllEnvironments()
    {
        File.Delete(FilePath);
    }

    public static List<string> GetAllVariables(string envName)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName))
        {
            return environments[envName].Keys.ToList();
        }
        return new List<string>();
    }

    public static void DeleteAllVariables(string envName)
    {
        var environments = LoadEnvironments();
        if (environments.ContainsKey(envName))
        {
            environments[envName].Clear();
            SaveEnvironments(environments);
        }
    }

    private static Dictionary<string, Dictionary<string, string>> LoadEnvironments()
    {
        var environments = new Dictionary<string, Dictionary<string, string>>();

        if (!File.Exists(FilePath))
        {
            return environments;
        }

        var lines = File.ReadAllLines(FilePath);
        string currentEnv = null;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Trim().StartsWith("//"))
            {
                continue;  // Skip empty lines or lines starting with "//"
            }

            if (!line.Contains(":"))
            {
                currentEnv = line.Trim();
                if (!environments.ContainsKey(currentEnv))
                {
                    environments[currentEnv] = new Dictionary<string, string>();
                }
            }
            else
            {
                var parts = line.Split(new[] { ':' }, 2);
                if (parts.Length == 2 && currentEnv != null)
                {
                    environments[currentEnv][parts[0].Trim()] = parts[1].Trim().Trim('"');
                }
            }
        }

        return environments;
    }

    private static void SaveEnvironments(Dictionary<string, Dictionary<string, string>> environments)
    {
        using (var writer = new StreamWriter(FilePath))
        {
            foreach (var env in environments)
            {
                writer.WriteLine(env.Key);
                foreach (var variable in env.Value)
                {
                    writer.WriteLine($"\t{variable.Key}: \"{variable.Value}\"");
                }
            }
        }
    }
}
