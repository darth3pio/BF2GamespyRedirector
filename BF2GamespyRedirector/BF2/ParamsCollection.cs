using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BF2GamespyRedirector
{
    public class ParamsCollection
    {
        /// <summary>
        /// A Key / Value collection containing all set Params
        /// </summary>
        public Dictionary<string, string> Collection { get; }

        /// <summary>
        /// Contains a list of Temporary Keys that will be excluded from being saved in the User Settings
        /// </summary>
        public List<string> TempKeys { get; } = new List<string>()
        {
            "playerName",
            "playerPassword",
            "joinServer",
            "port",
            "password"
        };

        /// <summary>
        /// Creates a new instance of ParamsCollection
        /// </summary>
        /// <param name="ParamString"></param>
        public ParamsCollection(string ParamString)
        {
            // Initialize internal collection
            Collection = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Reload(ParamString);
        }

        /// <summary>
        /// Clears this collection and rebuilds the internal dictionary with the provided params string
        /// </summary>
        /// <param name="ParamString"></param>
        public void Reload(string ParamString)
        {
            Collection.Clear();

            // Parse the Params string
            if (!String.IsNullOrWhiteSpace(ParamString))
            {
                Regex Reg = new Regex(@"\+(?<name>[a-z]+)[\s]+(?<value>[a-z0-9.<>=_-]+)", RegexOptions.IgnoreCase);
                foreach (Match M in Reg.Matches(ParamString))
                    AddOrSet(M.Groups["name"].Value, M.Groups["value"].Value);
            }
        }

        /// <summary>
        /// Adds or Sets a parameter
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void AddOrSet(string Key, string Value)
        {
            // We dont accept null values!
            if (String.IsNullOrWhiteSpace(Value)) return;

            // Set the new value
            Collection[Key] = Value;
        }

        /// <summary>
        /// Gets the value of the specified key, or null if unset
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string GetValue(string Key)
        {
            return (Collection.ContainsKey(Key)) ? Collection[Key] : null;
        }

        /// <summary>
        /// Removes the given key and its value from this params collection
        /// </summary>
        /// <param name="v"></param>
        public bool Remove(string key)
        {
            return Collection.Remove(key);
        }

        /// <summary>
        /// Removes all Parameters that contain the Key in the TempKeys list
        /// </summary>
        public void ClearTempParams()
        {
            foreach (string Key in TempKeys)
                Collection.Remove(Key);
        }

        /// <summary>
        /// Removes all stored params
        /// </summary>
        public void Clear()
        {
            Collection.Clear();
        }

        /// <summary>
        /// Returns the string of parameters to pass onto the Battlefield 2 exe
        /// </summary>
        /// <param name="IncludeTempKeys">Include temporary keys?</param>
        /// <returns></returns>
        public string BuildString(bool IncludeTempKeys = false)
        {
            StringComparer Comparer = StringComparer.InvariantCultureIgnoreCase;
            StringBuilder builder = new StringBuilder();

            // Iterate through each param
            foreach (KeyValuePair<string, string> Param in Collection)
            {
                // Remove Temp Keys
                if (!IncludeTempKeys && TempKeys.Contains(Param.Key, Comparer))
                {
                    continue;
                }

                // Add item to the final string to be returned
                builder.AppendFormat("+{0} {1} ", Param.Key, Param.Value);
            }

            return builder.ToString().TrimEnd();
        }

        public override string ToString()
        {
            return BuildString();
        }
    }
}
