namespace App.Common.Configurations
{
    using System.Configuration;

    public class DatabasesElement : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringElement)element).Name;
        }

        public ConnectionStringElement this[int index]
        {
            get
            {
                return (ConnectionStringElement)this.BaseGet(index);
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }

        public new ConnectionStringElement this[string name]
        {
            get
            {
                return (ConnectionStringElement)this.BaseGet(name);
            }
        }

        public int IndexOf(ConnectionStringElement url)
        {
            return this.BaseIndexOf(url);
        }

        public void Add(ConnectionStringElement url)
        {
            this.BaseAdd(url);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            this.BaseAdd(element, false);
        }

        public void Remove(ConnectionStringElement url)
        {
            if (this.BaseIndexOf(url) >= 0)
            {
                this.BaseRemove(url.Name);
            }
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        public System.Collections.Generic.IList<ConnectionStringElement> ToList()
        {
            System.Collections.Generic.IList<ConnectionStringElement> items = new System.Collections.Generic.List<ConnectionStringElement>();
            object[] keys = this.BaseGetAllKeys();
            foreach (object key in keys)
            {
                var item = (ConnectionStringElement)this.BaseGet(key);
                items.Add(item);
            }

            return items;
        }
    }

    public class ConnectionStringElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name => (string)this["name"];

        [ConfigurationProperty("database")]
        public string Database => (string)this["database"];

        [ConfigurationProperty("server")]
        public string Server => (string)this["server"];

        [ConfigurationProperty("port")]
        public int Port => (int)this["port"];

        [ConfigurationProperty("userName")]
        public string UserName => (string)this["userName"];

        [ConfigurationProperty("password")]
        public string Password => (string)this["password"];

        [ConfigurationProperty("dbType")]
        public RepositoryType DbType => (RepositoryType)this["dbType"];

        [ConfigurationProperty("default")]
        public bool IsDefault => (bool)this["default"];
    }
}
