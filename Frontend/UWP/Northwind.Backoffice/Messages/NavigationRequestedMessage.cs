namespace Northwind.Backoffice.Messages
{
    internal class NavigationRequestedMessage
    {
        /// <summary>
        /// A magic string which indicates the navigation/ page to which the navigation should occur.
        /// </summary>
        /// <remarks>
        /// In later code trips, we will make this more nice by using code suggar and/or a routing class.
        /// </remarks>
        public string NavigationPath { get; internal set; }
    }
}
