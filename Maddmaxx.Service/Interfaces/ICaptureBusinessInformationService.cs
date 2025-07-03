using System.Threading.Tasks;
using Shared;

namespace Maddmaxx.Service.Interfaces;
public interface ICaptureBusinessInformationService
{
    Task<BusinessInfoReply> CaptureBusinessInformation(BusinessInfoRequest request);
}
