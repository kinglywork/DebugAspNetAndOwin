// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Microsoft.Owin.Hosting.Utilities
{
    /// <summary>
    /// Loads settings from various locations.
    /// </summary>
    public static class SettingsLoader
    {
        private static IDictionary<string, string> _fromConfigImplementation;

        /// <summary>
        /// Load settings from the AppSettings section of the config file.
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> LoadFromConfig()
        {
            return LazyInitializer.EnsureInitialized(
                ref _fromConfigImplementation,
                () => new FromConfigImplementation());
        }

        /// <summary>
        /// Load settings from the AppSettings section of the config file.
        /// </summary>
        /// <param name="settings"></param>
        public static void LoadFromConfig(IDictionary<string, string> settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            IDictionary<string, string> config = LoadFromConfig();

            foreach (var pair in config)
            {
                // Don't overwrite programmatically supplied settings.
                string ignored;
                if (!settings.TryGetValue(pair.Key, out ignored))
                {
                    settings.Add(pair);
                }
            }
        }

        /// <summary>
        /// Load settings from a flat text file.
        /// </summary>
        /// <param name="settingsFile"></param>
        /// <returns></returns>
        public static IDictionary<string, string> LoadFromSettingsFile(string settingsFile)
        {
            var settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            LoadFromSettingsFile(settingsFile, settings);
            return settings;
        }

        /// <summary>
        /// Load settings from a flat text file.
        /// </summary>
        /// <param name="settingsFile"></param>
        /// <param name="settings"></param>
        public static void LoadFromSettingsFile(string settingsFile, IDictionary<string, string> settings)
        {
            if (settingsFile == null)
            {
                throw new ArgumentNullException("settingsFile");
            }
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            using (var streamReader = new StreamReader(settingsFile))
            {
                while (true)
                {
                    string line = streamReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (line.StartsWith("#", StringComparison.Ordinal) ||
                        string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    int delimiterIndex = line.IndexOf('=');

                    // Error handling for missing =, name, or value
                    if (delimiterIndex <= 0)
                    {
                        throw new ArgumentException(Resources.Exception_ImproperlyFormattedSettingsFile);
                    }

                    string name = line.Substring(0, delimiterIndex).Trim();
                    string value = line.Substring(delimiterIndex + 1).Trim();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException(Resources.Exception_ImproperlyFormattedSettingsFile);
                    }

                    // Empty values are ok.

                    // Don't overwrite programmatically supplied settings.
                    string ignored;
                    if (!settings.TryGetValue(name, out ignored))
                    {
                        settings[name] = value;
                    }
                }
            }
        }

        private class FromConfigImplementation : IDictionary<string, string>
        {
            private readonly NameValueCollection _appSettings;

            public FromConfigImplementation()
            {
                Type configurationManagerType = Type.GetType("System.Configuration.ConfigurationManager, System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                PropertyInfo appSettingsProperty = configurationManagerType.GetProperty("AppSettings");
                _appSettings = (NameValueCollection)appSettingsProperty.GetValue(null, new object[0]);
            }

            public int Count
            {
                get { throw new System.NotImplementedException(); }
            }

            public bool IsReadOnly
            {
                get { throw new System.NotImplementedException(); }
            }

            public ICollection<string> Keys
            {
                get { throw new System.NotImplementedException(); }
            }

            public ICollection<string> Values
            {
                get { throw new System.NotImplementedException(); }
            }

            public string this[string key]
            {
                get { return _appSettings[key]; }
                set { throw new System.NotImplementedException(); }
            }

            public bool TryGetValue(string key, out string value)
            {
                value = _appSettings[key];
                return value != null;
            }

            #region Implementation of IEnumerable

            public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
            {
                foreach (string key in _appSettings.Keys)
                {
                    yield return new KeyValuePair<string, string>(key, _appSettings[key]);
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            #endregion

            #region Implementation of ICollection<KeyValuePair<string,string>>

            public void Add(KeyValuePair<string, string> item)
            {
                throw new System.NotImplementedException();
            }

            public void Clear()
            {
                throw new System.NotImplementedException();
            }

            public bool Contains(KeyValuePair<string, string> item)
            {
                throw new System.NotImplementedException();
            }

            public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
            {
                throw new System.NotImplementedException();
            }

            public bool Remove(KeyValuePair<string, string> item)
            {
                throw new System.NotImplementedException();
            }

            #endregion

            #region Implementation of IDictionary<string,string>

            public bool ContainsKey(string key)
            {
                throw new System.NotImplementedException();
            }

            public void Add(string key, string value)
            {
                throw new System.NotImplementedException();
            }

            public bool Remove(string key)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }
    }
}
