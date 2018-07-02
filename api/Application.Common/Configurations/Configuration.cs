namespace App.Common.Configurations
{
    using CommandHandler;
    using EventHandler;
    using System.Configuration;

    public class Configuration : System.Configuration.ConfigurationSection
    {
        private static Configuration current;
        public static Configuration Current
        {
            get
            {
                if (current == null)
                {
                    current = (Configuration)System.Configuration.ConfigurationManager.GetSection("appconfiguration");
                }

                return current;
            }
        }

        [ConfigurationProperty("settings")]
        public SettingElement Setting => (SettingElement)this["settings"];

        [ConfigurationProperty("messageBus")]
        public MessageBusElement MessageBus => (MessageBusElement)this["messageBus"];

        [ConfigurationProperty("authentication")]
        public AuthenticationElement Authentication => (AuthenticationElement)this["authentication"];

        [ConfigurationProperty("paging")]
        public PagingElement Paging => (PagingElement)this["paging"];

        [ConfigurationProperty("repository")]
        public RepositoryElement Repository => (RepositoryElement)this["repository"];

        [ConfigurationProperty("databases", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(DatabasesElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public DatabasesElement Databases => (DatabasesElement)this["databases"];

        [ConfigurationProperty("localization")]
        public LocalizationElement Localization => (LocalizationElement)this["localization"];

        [ConfigurationProperty("uitest")]
        public UITestElement UITest => (UITestElement)this["uitest"];

        [ConfigurationProperty("mail")]
        public MailElement Mail => (MailElement)this["mail"];

        [ConfigurationProperty("folder")]
        public FolderElement Folder => (FolderElement)this["folder"];

        [ConfigurationProperty("integration-test")]
        public IntegrationTestElement IntegrationTest => (IntegrationTestElement)this["integration-test"];


        [ConfigurationProperty("commandHandlerSettings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CommandHandlerSettingsElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CommandHandlerSettingsElement CommandHandlerSettings => (CommandHandlerSettingsElement)this["commandHandlerSettings"];

        [ConfigurationProperty("eventHandlers", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(EventHandlersElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public EventHandlersElement EventHandlers => (EventHandlersElement)this["eventHandlers"];

        [ConfigurationProperty("aggregates", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(AggregatesElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public AggregatesElement Aggregates => (AggregatesElement)this["aggregates"];
    }
}
