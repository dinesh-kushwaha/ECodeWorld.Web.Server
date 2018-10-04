namespace ECodeWorld.Web.API
{
    internal class DIAutofacServiceProvider
    {
        private object container;

        public DIAutofacServiceProvider(object container)
        {
            this.container = container;
        }
    }
}