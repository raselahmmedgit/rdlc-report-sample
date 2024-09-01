using System.Collections.Generic;

namespace lab.RDLCReportSample.FlashMessage
{
    /// <summary>
    /// Defines a contract for serializing flash messages to and from a string based format.
    /// </summary>
    public interface IFlashMessageSerializer
    {

        List<FlashMessageModel> Deserialize(string data);

        string Serialize(IList<FlashMessageModel> messages);
    }
}
